using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameContent.NetModules;
using Terraria.ID;
using Terraria.Net;
using TerrariaApi.Server;
using TShockAPI;

namespace ShowPowerMenu;

[ApiVersion(2, 1)]
public class Plugin : TerrariaPlugin
{
    public override string Name => "显示力量菜单";
    public override string Author => "hufang360";
    public override string Description => "允许建筑师临时启用力量菜单";
    public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

    /// <summary>
    /// 配置文件
    /// </summary>
    Config Con;

    static string ConDir = Path.Combine(TShock.SavePath, "ShowPowerMenu");
    static string ConFile = Path.Combine(ConDir, "config.json");
    bool ConIsLoad = false;

    static string PermAdmin = "showpowermenu";

    public Plugin(Main game) : base(game)
    {
    }

    public override void Initialize()
    {
        Commands.ChatCommands.Add(new Command(Manage, "showpowermenu", "spm") { HelpText = "显示力量菜单" });
    }


    /// <summary>
    /// 指令管理
    /// </summary>
    void Manage(CommandArgs args)
    {
        if (TShock.ServerSideCharacterConfig.Settings.Enabled && args.Player.Group.Name == TShock.Config.Settings.DefaultGuestGroupName)
        {
            args.Player.SendErrorMessage("游客无法使用本指令");
            return;
        }

        Load();

        if (args.Parameters.Count == 0)
        {
            if (!args.Player.RealPlayer)
            {
                args.Player.SendErrorMessage("显示力量菜单在游戏内进行操作！输入/spm help查看其它可用指令。");
                return;
            }

            if (Con.names.Contains(args.Player.Name))
            {
                Enable(args.Player);
            }
            else
            {
                args.Player.SendErrorMessage("你不是建筑师！");
            }
            return;
        }
        else
        {
            if (!args.Player.HasPermission(PermAdmin))
            {
                args.Player.SendErrorMessage("你没有权限操作，如果你是建筑师，直接输入 /spm 就能显示力量菜单！");
                return;
            }
        }

        void Help()
        {
            List<string> lines = new()
            {
                "/spm, 为自己显示力量菜单",
                "/spm add <玩家名>, 将玩家添加建筑师名单",
                "/spm del <玩家名>, 将玩家移出建筑师名单",
                "/spm list, 查看建筑师名单",
            };
            args.Player.SendInfoMessage(string.Join("\n", lines));
        }

        string playerName;
        switch (args.Parameters[0].ToLowerInvariant())
        {
            case "help":
            case "h":
                Help();
                break;

            case "add":
                if (args.Parameters.Count < 2)
                {
                    args.Player.SendInfoMessage("请输入玩家名，用法：/spm add <玩家名>");
                    return;
                }
                playerName = args.Parameters[1];
                if (!Con.names.Contains(playerName))
                {
                    Con.names.Add(playerName);
                    Save();
                    args.Player.SendSuccessMessage($"已将玩家 {playerName} 添加到建筑师名单！");
                }
                else
                {
                    args.Player.SendInfoMessage($"玩家 {playerName} 已在建筑师名单当中！");
                }
                break;

            case "del":
            case "remove":
                if (args.Parameters.Count < 2)
                {
                    args.Player.SendInfoMessage("请输入玩家名，用法：/spm del <玩家名>");
                    return;
                }
                playerName = args.Parameters[1];
                if (Con.names.Contains(playerName))
                {
                    Con.names.Remove(playerName);
                    Save();
                    var li = TShock.Players.Where(p => p != null && p.Active && p.Name == playerName);
                    foreach (var p in li)
                    {
                        p.Disconnect($"{args.Player.Name} 关闭了你的力量菜单，请重新上线！");
                    }
                    args.Player.SendSuccessMessage($"已将玩家 {playerName} 移出建筑师名单，为了数据安全已将其踢下线！");
                }
                else
                {
                    args.Player.SendInfoMessage($"玩家 {playerName} 不在建筑师名单当中，无需移除！");
                }
                break;


            case "list":
                var lines = Utils.WarpLines(Con.names);
                if (lines.Count == 0)
                {
                    args.Player.SendInfoMessage("白名单是空的！");
                    return;
                }
                lines.Insert(0, "建筑师名单:");
                args.Player.SendInfoMessage(string.Join("\n", lines));
                break;

            case "reload":
                Load(true);
                args.Player.SendSuccessMessage("[显示力量菜单]配置已重载！");
                break;

            default:
                args.Player.SendErrorMessage("指令输入错误，请输入 /spm help 查看帮助");
                break;
        }
    }


    /// <summary>
    /// 允许显示力量菜单
    /// </summary>
    /// <param name="op"></param>
    void Enable(TSPlayer op)
    {
        // 修改成旅行模式
        op.TPlayer.difficulty = 3;
        op.SendData(PacketTypes.PlayerInfo);

        if (Con.SendResearch)
        {

            // 发送物品研究数据
            for (int i = 0; i < ItemID.Count; i++)
            {
                var response = NetCreativeUnlocksModule.SerializeItemSacrifice(i, 9999);
                NetManager.Instance.SendToClient(response, op.Index);
            }

            op.SendSuccessMessage("已显示力量菜单，全物品研究已单独为你解锁！(*^▽^*)");
        }
        else
        {
            op.SendSuccessMessage("已显示力量菜单！(*^▽^*)");

        }
    }


    /// <summary>
    /// 加载配置
    /// </summary>
    void Load(bool force = true)
    {
        if (!ConIsLoad || force)
        {
            if (File.Exists(ConFile))
            {
                Con = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConFile));
            }
            else
            {
                // 创建文件夹
                if (!Directory.Exists(ConDir))
                {
                    Directory.CreateDirectory(ConDir);
                }

                // 创建配置文件
                Con = new Config();
                File.WriteAllText(ConFile, JsonConvert.SerializeObject(Con, Formatting.Indented));
            }

            ConIsLoad = true;
        }
    }

    /// <summary>
    /// 保存配置
    /// </summary>
    void Save()
    {   // 创建文件夹
        if (!Directory.Exists(ConDir))
        {
            Directory.CreateDirectory(ConDir);
        }
        File.WriteAllText(ConFile, JsonConvert.SerializeObject(Con, Formatting.Indented));
    }

}



/// <summary>
/// 配置文件
/// </summary>
public class Config
{
    // 建筑师白名单
    public List<string> names = new();

    // 是否发送全物品研究
    public bool SendResearch = true;
}



public class Utils
{
    /// <summary>
    /// 将字符串换行
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="column">列数，1行显示多个</param>
    /// <returns></returns>
    public static List<string> WarpLines(List<string> lines, int column = 5)
    {
        List<string> li1 = new();
        List<string> li2 = new();
        foreach (var line in lines)
        {
            if (li2.Count % column == 0)
            {
                if (li2.Count > 0)
                {
                    li1.Add(string.Join(", ", li2));
                    li2.Clear();
                }
            }
            li2.Add(line);
        }
        if (li2.Any())
        {
            li1.Add(string.Join(", ", li2));
        }
        return li1;
    }
}