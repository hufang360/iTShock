using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Terraria;
using Terraria.ID;
using TerrariaApi.Server;
using TShockAPI;

namespace V50Reward
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {
        public override string Name => "V50Reward";
        public override string Author => "MiMo · hufang360";
        public override Version Version => GetPluginVersion();
        public override string Description => "疯四奖";

        // 版本号取 csproj <Version>（如 1.1.0），不用 4 段补零的 AssemblyVersion
        private static Version GetPluginVersion()
        {
            var attr = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            string value = attr?.InformationalVersion?.Split('+')[0] ?? "1.0.0";
            return Version.TryParse(value, out var v) ? v : new Version(1, 0, 0);
        }

        const string PermReward = "v50reward.claim";
        const string PermAdmin = "v50reward.admin";

        private static string SaveDir;
        private static string DataPath;
        private static string ConfigPath;
        private static ConcurrentDictionary<string, PlayerData> PlayerDataDict = new();
        private static PluginConfig Config = new();

        public Plugin(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command(PermReward, V50Command, "v50") { HelpText = "/v50 领奖 | /v50 help | /v50 reload | /v50 reset [玩家]" });

            SaveDir = Path.Combine(TShock.SavePath, "V50Reward");
            DataPath = Path.Combine(SaveDir, "data.json");
            ConfigPath = Path.Combine(SaveDir, "config.json");

            if (!Directory.Exists(SaveDir))
                Directory.CreateDirectory(SaveDir);

            LoadConfig();
            LoadData();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SaveData();
            }
            base.Dispose(disposing);
        }

        private static void V50Command(CommandArgs args)
        {
            var player = args.Player;
            if (player == null)  // 服务器控制台不处理领奖
                return;

            if (args.Parameters.Count > 0)
            {
                switch (args.Parameters[0].ToLower())
                {
                    case "reload":
                        HandleReload(args);
                        return;
                    case "reset":
                        HandleReset(args);
                        return;
                    case "help":
                    case "?":
                        HandleHelp(args);
                        return;
                    default:
                        // 未知子命令展示帮助，避免误领取
                        HandleHelp(args);
                        return;
                }
            }

            // /v50 — 领取奖励
            HandleReward(args);
        }

        private static void HandleHelp(CommandArgs args)
        {
            string days = string.Join("、", Config.RewardDays.Select(DayName));
            args.Player.SendInfoMessage("[i:4016] V50Reward 疯四奖 帮助：");
            args.Player.SendInfoMessage("[i:4016] /v50 — 领取今日奖励");
            args.Player.SendInfoMessage("[i:4016] /v50 help — 查看本帮助");
            args.Player.SendInfoMessage("[i:4016] /v50 reload — 重载配置（管理员）");
            args.Player.SendInfoMessage("[i:4016] /v50 reset — 重置所有玩家领取记录（管理员）");
            args.Player.SendInfoMessage("[i:4016] /v50 reset <玩家名> — 重置指定玩家记录（管理员）");
            args.Player.SendInfoMessage($"[i:4016] 本周可领取日：{days}，每周限领 {Config.MaxRewardsPerWeek} 次。");
        }

        private static void HandleReward(CommandArgs args)
        {
            var player = args.Player;

            // 周编号：1=周一 ... 7=周日（DateTime.DayOfWeek 中 周日=0，需转换）
            int today = (int)DateTime.UtcNow.DayOfWeek;
            if (today == 0) today = 7;
            if (!Config.RewardDays.Contains(today))
            {
                string days = string.Join("、", Config.RewardDays.Select(d => DayName(d)));
                player.SendErrorMessage($"[i:4016] 今天不可领取，可领取日：{days}");
                return;
            }

            string key = player.Name;

            var data = PlayerDataDict.GetOrAdd(key, _ => new PlayerData());
            string currentWeek = GetWeekKey();
            string lastWeek = GetLastWeekKey();

            // 判断是否连续领取（上周领过，在重置前检查）
            bool consecutive = data.RewardedWeek == lastWeek;

            // 切换周时重置计数
            if (data.RewardedWeek != currentWeek)
            {
                data.RewardedWeek = currentWeek;
                data.RewardCount = 0;
            }

            // 本周已达上限
            if (data.RewardCount >= Config.MaxRewardsPerWeek)
            {
                player.SendErrorMessage($"[i:4016] 本周已领取 {Config.MaxRewardsPerWeek} 次，下次周四再来吧！");
                return;
            }

            var rnd = new Random();

            if (Config.SkipDefault || consecutive)
            {
                var pool = Config.RandomPool;
                var pick = pool[rnd.Next(pool.Count)];
                GiveReward(player, pick, rnd);
            }
            else
            {
                GiveReward(player, Config.DefaultReward, rnd);
            }

            data.RewardCount++;
            SaveData();
        }

        private static void GiveReward(TSPlayer player, ItemData item, Random rnd)
        {
            string itemName = GetItemName(item.netID);

            player.GiveItem(item.netID, item.stack, item.prefix);
            player.SendSuccessMessage($"[i:4016] 获得 {item.stack} 个{itemName}！");

            // 再来一瓶：额外再给一份
            if (item.ReRollChance > 0 && rnd.NextDouble() < item.ReRollChance)
            {
                player.GiveItem(item.netID, item.ReRollStack, item.prefix);
                player.SendSuccessMessage($"[i:4016] 再来一瓶！额外获得 {item.ReRollStack} 个{itemName}！");
                Broadcast($"[i:4016] {player.Name} 开{itemName}时，喜提再来一罐！");
            }

            // 个人提示
            string tip = item.Tip;
            if (!string.IsNullOrEmpty(tip))
            {
                tip = tip.Replace("{player}", player.Name)
                         .Replace("{item}", itemName)
                         .Replace("{stack}", item.stack.ToString());
                player.SendSuccessMessage($"[i:4016] {tip}");
            }

            // 全服广播
            if (item.Broadcast)
            {
                string msg;
                if (!string.IsNullOrEmpty(item.Tip))
                {
                    msg = item.Tip.Replace("{player}", player.Name)
                                  .Replace("{item}", itemName)
                                  .Replace("{stack}", item.stack.ToString());
                }
                else
                {
                    msg = $"恭喜 {player.Name}，喜提 {item.stack} 个{itemName}！";
                }
                Broadcast($"[i:4016] {msg}");
            }
        }

        private static void Broadcast(string msg)
        {
            foreach (var p in TShock.Players)
            {
                if (p != null && p.Active)
                    p.SendInfoMessage(msg);
            }
        }

        private static void NotifyAdmins(string msg)
        {
            foreach (var p in TShock.Players)
            {
                if (p != null && p.Active && p.HasPermission("tshock.admin"))
                    p.SendErrorMessage(msg);
            }
        }

        private static void HandleReload(CommandArgs args)
        {
            if (!args.Player.HasPermission(PermAdmin))
            {
                args.Player.SendErrorMessage("你没有权限执行此命令！");
                return;
            }
            LoadConfig();
            args.Player.SendSuccessMessage("[i:4016] V50Reward 配置已重载！");
        }

        private static void HandleReset(CommandArgs args)
        {
            if (!args.Player.HasPermission(PermAdmin))
            {
                args.Player.SendErrorMessage("你没有权限执行此命令！");
                return;
            }

            // /v50 reset [玩家名]
            if (args.Parameters.Count < 2)
            {
                PlayerDataDict.Clear();
                SaveData();
                args.Player.SendSuccessMessage("[i:4016] 已重置所有玩家的领取记录！");
                return;
            }

            string targetName = args.Parameters[1];
            if (PlayerDataDict.TryRemove(targetName, out _))
            {
                SaveData();
                args.Player.SendSuccessMessage($"[i:4016] 已重置 {targetName} 的领取记录！");
            }
            else
            {
                args.Player.SendErrorMessage($"[i:4016] 未找到玩家 {targetName} 的记录！");
            }
        }

        private static string GetItemName(int netID)
        {
            try
            {
                var item = new Item();
                item.netDefaults(netID);
                return item.Name;
            }
            catch
            {
                return $"物品#{netID}";
            }
        }

        private static string DayName(int day) => day switch
        {
            1 => "周一",
            2 => "周二",
            3 => "周三",
            4 => "周四",
            5 => "周五",
            6 => "周六",
            7 => "周日",
            _ => $"未知({day})"
        };

        private static string GetWeekKey() => GetWeekKey(DateTime.UtcNow);

        private static string GetLastWeekKey() => GetWeekKey(DateTime.UtcNow.AddDays(-7));

        private static string GetWeekKey(DateTime date)
        {
            // ISO 周号跨年时要使用 ISO 年（如 12月31日 属于次年 W01）
            int year = System.Globalization.ISOWeek.GetYear(date);
            int week = System.Globalization.ISOWeek.GetWeekOfYear(date);
            return $"{year}-W{week:D2}";
        }

        private static void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    var json = File.ReadAllText(ConfigPath);
                    Config = JsonConvert.DeserializeObject<PluginConfig>(json) ?? new PluginConfig();
                }
                else
                {
                    Config = new PluginConfig();
                    SaveConfig();
                }
            }
            catch (Exception ex)
            {
                TShock.Log.Error("V50Reward: 加载配置失败 - " + ex.Message);
                NotifyAdmins("[i:4016] V50Reward 配置加载失败，已使用默认配置！");
                Config = new PluginConfig();
            }

            if (SanitizeRewardDays())
            {
                TShock.Log.Info("V50Reward: RewardDays 配置已自动清洗（去重 / 0=周日兼容 / 过滤无效值），正在保存修复后的配置...");
                SaveConfig();
            }
        }

        /// <summary>
        /// 清洗可领取日：周编号规范为 1=周一 ... 7=周日，
        /// 兼容旧写法 0=周日、去除重复、剔除 1~7 之外的无效值。
        /// 返回 true 表示配置发生了修正。
        /// </summary>
        private static bool SanitizeRewardDays()
        {
            if (Config.RewardDays == null)
                Config.RewardDays = new List<int>();

            var normalized = new List<int>();
            var seen = new HashSet<int>();
            bool changed = false;

            foreach (var day in Config.RewardDays)
            {
                int value = day == 0 ? 7 : day;   // 兼容旧写法 0=周日
                if (value < 1 || value > 7)
                {
                    changed = true;
                    TShock.Log.Info($"V50Reward: 忽略无效的领取日 {day}（有效为 1~7，周日为 7）");
                    continue;
                }
                if (seen.Add(value))
                {
                    normalized.Add(value);
                }
                else
                {
                    changed = true;
                    TShock.Log.Info($"V50Reward: 去除重复的领取日 {day}");
                }
            }

            Config.RewardDays = normalized;
            return changed;
        }

        private static void SaveConfig()
        {
            try
            {
                var json = JsonConvert.SerializeObject(Config, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                TShock.Log.Error("V50Reward: 保存配置失败 - " + ex.Message);
                NotifyAdmins("[i:4016] V50Reward 配置保存失败！");
            }
        }

        private static void LoadData()
        {
            try
            {
                if (File.Exists(DataPath))
                {
                    var json = File.ReadAllText(DataPath);
                    PlayerDataDict = new ConcurrentDictionary<string, PlayerData>(
                        JsonConvert.DeserializeObject<Dictionary<string, PlayerData>>(json)
                        ?? new Dictionary<string, PlayerData>());
                }
            }
            catch (Exception ex)
            {
                TShock.Log.Error("V50Reward: 加载数据失败 - " + ex.Message);
                NotifyAdmins("[i:4016] V50Reward 数据加载失败，已重置玩家数据！");
                PlayerDataDict = new ConcurrentDictionary<string, PlayerData>();
            }
        }

        private static void SaveData()
        {
            try
            {
                var json = JsonConvert.SerializeObject(PlayerDataDict, Formatting.Indented);
                File.WriteAllText(DataPath, json);
            }
            catch (Exception ex)
            {
                TShock.Log.Error("V50Reward: 保存数据失败 - " + ex.Message);
                NotifyAdmins("[i:4016] V50Reward 数据保存失败！");
            }
        }

        private class PluginConfig
        {
            public List<int> RewardDays { get; set; } = [4]; // 默认周四 (1=周一,2=周二,...,7=周日)
            public int MaxRewardsPerWeek { get; set; } = 1;
            public bool SkipDefault { get; set; } = true;
            public ItemData DefaultReward { get; set; } = new ItemData { netID = ItemID.GoldCoin, prefix = 0, stack = 50 };

            public List<ItemData> RandomPool { get; set; } =
            [
                // 钓鱼
                new ItemData { netID = 2290, prefix = 0, stack = 50 },                                                        // 鲈鱼
                new ItemData { netID = 2002, prefix = 0, stack = 50 },                                                        // 蠕虫

                // 土块泥块
                new ItemData { netID = 2,    prefix = 0, stack = 50, Tip = "服主也穷得吃土[i:2]..." },                           // 土块

                // 诱饵
                new ItemData { netID = 2674, prefix = 0, stack = 50 },                                                        // 学徒诱饵
                new ItemData { netID = 2675, prefix = 0, stack = 10 },                                                        // 熟手诱饵
                new ItemData { netID = 2676, prefix = 0, stack = 5 },                                                         // 大师诱饵

                // 臭臭（全服广播）
                new ItemData { netID = 5395, prefix = 0, stack = 50, Broadcast = true, Tip = "恭喜{player}喜提{item} {stack}个，服主真的特别爱你，你为什么流泪~" },  // 臭臭

                // 1级食物
                new ItemData { netID = 5275, prefix = 0, stack = 1,  Tip = "喜提快乐水一瓶！", ReRollChance = 0.1, ReRollStack = 1 },  // 可咂可乐（再来一瓶）
                new ItemData { netID = 4031, prefix = 0, stack = 1 },                                                         // 烤鸟
                new ItemData { netID = 4024, prefix = 0, stack = 1 },                                                         // 烤松鼠

                // 2级食物
                new ItemData { netID = 4016, prefix = 0, stack = 1 },                                                         // 鸡块
                new ItemData { netID = 4035, prefix = 0, stack = 1 },                                                         // 鲜虾三明治

                // 3级食物
                new ItemData { netID = 4032, prefix = 0, stack = 1 },                                                         // 烤鸭
                new ItemData { netID = 4015, prefix = 0, stack = 1 },                                                         // 汉堡
            ];
        }

        private class ItemData
        {
            public int netID { get; set; }
            public int prefix { get; set; }
            public int stack { get; set; }
            public string Tip { get; set; } = "";
            public bool Broadcast { get; set; }
            public double ReRollChance { get; set; }
            public int ReRollStack { get; set; }
        }

        private class PlayerData
        {
            public string RewardedWeek { get; set; } = "";
            public int RewardCount { get; set; } = 0;
        }
    }
}
