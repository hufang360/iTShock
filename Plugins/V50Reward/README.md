# V50Reward - 疯四奖

TShock 插件，每周四玩家可领取一次奖励。

## 功能

- 每周四 `/v50` 领取奖励，每周限领一次
- 支持自定义随机奖池，连续领取从池中随机抽取
- 可配置物品前缀、数量、个人提示、全服广播、再来一瓶

## 命令

| 命令 | 权限 | 说明 |
|------|------|------|
| `/v50` | `v50reward.claim` | 领取周四奖励 |
| `/v50 reload` | `v50reward.admin` | 重载配置文件 |
| `/v50 reset` | `v50reward.admin` | 重置所有玩家领取记录 |
| `/v50 reset <玩家名>` | `v50reward.admin` | 重置指定玩家记录 |

## 权限

```
v50reward.claim    # 领奖权限（所有玩家）
v50reward.admin    # 管理权限（重载/重置）
```

## 安装

1. 将 `V50Reward.dll` 放入 TShock 的 `ServerPlugins/` 目录
2. 重启服务器，首次启动会自动生成配置文件和数据文件

## 配置

配置文件路径：`TShock存档目录/V50Reward/config.json`

```json
{
  "RewardDays": [4],
  "MaxRewardsPerWeek": 1,
  "SkipDefault": true,
  "DefaultReward": {
    "netID": 73,
    "prefix": 0,
    "stack": 50
  },
  "RandomPool": [
    { "netID": 2290, "prefix": 0, "stack": 50 },
    { "netID": 2002, "prefix": 0, "stack": 50 },
    { "netID": 2,    "prefix": 0, "stack": 50, "Tip": "服主也穷得吃土..." },
    { "netID": 2674, "prefix": 0, "stack": 50 },
    { "netID": 2675, "prefix": 0, "stack": 10 },
    { "netID": 2676, "prefix": 0, "stack": 5 },
    { "netID": 5395, "prefix": 0, "stack": 50, "Broadcast": true, "Tip": "恭喜{player}喜提{item} {stack}个，服主真的特别爱你，你为什么流泪~" },
    { "netID": 5275, "prefix": 0, "stack": 1, "Tip": "喜提快乐水一瓶！", "ReRollChance": 0.1, "ReRollStack": 1 },
    { "netID": 4031, "prefix": 0, "stack": 1 },
    { "netID": 4024, "prefix": 0, "stack": 1 },
    { "netID": 4016, "prefix": 0, "stack": 1 },
    { "netID": 4035, "prefix": 0, "stack": 1 },
    { "netID": 4032, "prefix": 0, "stack": 1 },
    { "netID": 4015, "prefix": 0, "stack": 1 }
  ]
}
```

### 配置项说明

| 字段 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `RewardDays` | int[] | `[4]` | 可领取的星期几（0=周日,1=周一,...,6=周六），支持多天如 `[3,4]` 表示周三和周四 |
| `MaxRewardsPerWeek` | int | `1` | 每周可领取次数 |
| `SkipDefault` | bool | `true` | `true` 时所有玩家直接从 RandomPool 抽取；`false` 时首次/断档给 DefaultReward |
| `DefaultReward` | ItemData | 50金币 | SkipDefault=false 时，首次/断档领取的奖励 |
| `RandomPool` | ItemData[] | 见上方 | 随机奖池，每次从中随机抽取一个 |

### ItemData 字段

| 字段 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `netID` | int | - | 物品 ID（ Terraria item netID） |
| `prefix` | int | 0 | 物品前缀（0 = 无前缀） |
| `stack` | int | 1 | 物品数量 |
| `Tip` | string | `""` | 个人提示，支持占位符 |
| `Broadcast` | bool | `false` | `true` 时全服广播 |
| `ReRollChance` | double | 0 | 再来一瓶概率（0.0 ~ 1.0） |
| `ReRollStack` | int | 0 | 再来一瓶时额外给的数量 |

### Tip 占位符

| 占位符 | 说明 |
|--------|------|
| `{player}` | 玩家名 |
| `{item}` | 物品名（自动获取） |
| `{stack}` | 物品数量 |

当 `Broadcast = true` 且 `Tip` 不为空时，Tip 同时作为广播内容模板。

### 默认随机奖池物品

| 物品 | netID | 数量 | 特殊效果 |
|------|-------|------|----------|
| 鲈鱼 | 2290 | 50 | - |
| 蠕虫 | 2002 | 50 | - |
| 土块 | 2 | 50 | 个人提示 |
| 学徒诱饵 | 2674 | 50 | - |
| 熟手诱饵 | 2675 | 10 | - |
| 大师诱饵 | 2676 | 5 | - |
| 臭臭 | 5395 | 50 | 全服广播 |
| 可咂可乐 | 5275 | 1 | 再来一瓶（10%） |
| 烤鸟 | 4031 | 1 | - |
| 烤松鼠 | 4024 | 1 | - |
| 鸡块 | 4016 | 1 | - |
| 鲜虾三明治 | 4035 | 1 | - |
| 烤鸭 | 4032 | 1 | - |
| 汉堡 | 4015 | 1 | - |

## 数据

玩家领取记录保存在：`TShock存档目录/V50Reward/data.json`

以玩家名为 key，记录上次领取的周号（ISO 8601），用于判断连续领取和本周是否已领。

## 领取逻辑

```
1. 检查是否周四 → 否则提示
2. 检查是否连续领取（上周领过）
3. 切换周时重置领取计数
4. 本周已达 MaxRewardsPerWeek 上限 → 提示
5. SkipDefault=true 或 连续领取 → 从 RandomPool 随机抽取
6. 否则 → 给予 DefaultReward
7. 领取计数 +1，保存数据
```

## 构建

```bash
dotnet build
```

需要在 `references/` 目录下放置 TShock 的 DLL：
- `OTAPI.dll`
- `TerrariaServer.dll`
- `TShockAPI.dll`

或通过 NuGet 引用 TShock 包。
