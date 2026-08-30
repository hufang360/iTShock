
记录和tshock有关的内容，转载部分官方文档，自己写的插件，以及保存代码量小，且不怎么更新的小插件。
<br>

## 1.4.5.7 和 1.4.5.8
> 2026-08-20 05:09:03  1.4.5.7发布

> 2026-08-24 02:47:12  1.4.5.8发布


### 8月25日
解决“使用物品电弧涌动攻击敌怪会触发一个BUFF，然后玩家立即被踢出，显示:踢出，对NPC异常地添加了BUFF”。

- Linux版本：[TShock-1.4.5.8-linux-x64-hf-0825.zip](https://github.com/hufang360/iTShock/releases/download/1.4.5.7/TShock-1.4.5.8-linux-x64-hf-0825.zip)
- Windows版本：[TShock-1.4.5.8-win-x64-hf-0825.zip](https://github.com/hufang360/iTShock/releases/download/1.4.5.7/TShock-1.4.5.8-win-x64-hf-0825.zip)


### 8月24日

基于 OTAPI v3.3.14 重新编译，支持泰拉1.4.5.8，让AI做的适配，仅供尝鲜。

- Linux版本：[TShock-1.4.5.8-linux-x64-hf-0824.zip](https://github.com/hufang360/iTShock/releases/download/1.4.5.7/TShock-1.4.5.8-linux-x64-hf-0824.zip)
- Windows版本：[TShock-1.4.5.8-win-x64-hf-0824.zip](https://github.com/hufang360/iTShock/releases/download/1.4.5.7/TShock-1.4.5.8-win-x64-hf-0824.zip)
  > (这次为了压缩体积，zip里面不含 TShock.Installer 文件)

### 插件更新

- [ShowMe-v1.3-1457.dll](https://github.com/hufang360/TShockShowMe/releases/download/v1.3/ShowMe-v1.3-1457.dll)
  （修复 1.4.5.7 下 Item.active → IsAir 的 API 变更）

- [FishShop-v1.6-1457.dll](https://github.com/hufang360/TShockFishShop/releases/download/v1.6/FishShop-v1.6-1457.dll)
  （允许生成 “6160 锐刺”、“6170 附魔计时器”、“6171 宝石法杖”）

- [WorldModify-v1.6.1-1458.dll](https://github.com/hufang360/TShockWorldModify/releases/download/v1.6.1/WorldModify-v1.6.1-1458.dll)
  - 修复 `/igen world` 指令，重建地图失败问题
  - 修复 `/wm s` 指令，切换世界特性不成功问题
  - 新增 `/wm s ml/nl/gl`指令，可以用来开关新增加的两个彩蛋种子特性。
    - ml = moreLightning = Electric boogaloo
    - nl = noLightning = Calm before the storm",
    - gl = 绿色闪电 = moreLightning+noLightning",
  - 修复 `/wm re unlock`指令，不失效问题
  - 新增 `/npc shi` 指令，可以切换NPC的嬗变状态

- [Search-v1.4.0-1458.dll](https://github.com/hufang360/TShockSearch/releases/download/1.4.0/Search-v1.4.0-1458.dll)
  - 新增 `/shimmer` 指令，可查询物品的嬗变信息，指令简写 `/shi`
    - 嬗变：该物品扔进微光后变成什么（含月总后解锁提示）；
    - 分解：扔进微光后还原成哪些合成材料（带数量图标，含击败骷髅王/石巨人后解锁提示）；
    - 嬗变而来：哪些物品扔进微光会变成它，数量多时自动分页；

## docker快速开服

```shell
docker run -it --name tshock \
  -p 7777:7777 \
  -v ./data/tshock/:/tshock \
  -v ./data/worlds/:/worlds \
  -v ./data/plugins/:/plugins \
  ghcr.io/pryaxis/tshock:latest \
  -lang 7 \
  -world /worlds/world.wld \
  -autocreate 3 \
  -difficulty 2
```

- `-lang 7`, 中文。
- `-autocreate`, 世界大小，1=小, 2=中, 3=大。
- `-difficulty`, 世界难度，0=普通, 1=专家, 2=大师, 3=旅行。

```shell
# 进入控制台
# - 按 Ctrl+P，Ctrl+Q 退出
docker attach tshock

# 查看日志
# - 按 Ctrl+C 退出
docker logs -f tshock
```

- 参考连接：
  - [tshock命令行参数](https://github.com/Pryaxis/TShock/wiki/Command-line-parameters)
  - [tshock官方镜像](https://github.com/Pryaxis/TShock/pkgs/container/tshock/416082073?tag=latest)
  - 个人常用的插件, 见本仓库 [dlls](./dlls/)
    <br>

---

## 我写过的插件

### 常用

- 🔐 [AutoRegister](https://github.com/hufang360/TShockAutoRegister), 自动注册
- 🚀 [FastDeploy](https://github.com/hufang360/TShockFastDeploy), 快速开服, TShock4.x也能用
- 🌍 [WorldModify](https://github.com/hufang360/TShockWorldModify), 世界修改器, v1.4beta版本开始支持TShock5.0和泰拉1.4.4.x
- 👥 [PlayerManager](https://github.com/hufang360/TShockPlayerManager), 玩家管理
- 🐟 [FishShop](https://github.com/hufang360/TShockFishShop), 鱼店
- 🔍 [Search](https://github.com/hufang360/TShockSearch), 查一查
- 🔎 [ShowMe](https://github.com/hufang360/TShockShowMe), 找箱子, .net4.x 项目，TShock4.x也能用
- 📦 [ChestTool](https://github.com/hufang360/TShockChestTool), 箱子小工具

### 更多

这部分不怎么更新

- 💎 [Pylon](https://github.com/hufang360/TShockPylon), 指令晶塔
- 📋 [Clipboard](https://github.com/hufang360/TShockClipboard), 图格剪贴板
- 🎬 [TileAnimate](https://github.com/hufang360/TShockTileAnimate), 图格动画
- 🔧 [TDB](https://github.com/hufang360/TDB), TShock调试小助手
- 🎒 [CheckBag](https://github.com/hufang360/TShockCheckBag), 检查背包
- 📺 [TerrariaBLive](https://github.com/hufang360/TerrariaBLive), 直播插件, 原项目由ArsiIksait编写，可以把哔哩哔哩直播间的弹幕发到游戏里
- 🌋 [Quake](https://github.com/hufang360/TShockQuake), 大地动
- 🍀 [GoodLucky](https://github.com/hufang360/TShockGoodLucky), 好运来, .net4.x 项目
- 🗑️ [TrashMan](https://github.com/hufang360/TShockTrashMan), 垃圾佬
- 🛒 [MoreShopItem](https://github.com/hufang360/TShockMoreShopItem), 更多商店物品, TShock4.x也能用，商品数据跟1.4.4x不完全一样需要更新
- 🚫👾 [DisableNPC](https://github.com/hufang360/TShockDisableNPC), 禁NPC
- 🚫🎣 [DisableFishing](https://github.com/hufang360/TShockDisableFishing), 禁钓鱼

### 弃坑

- 📚 [GoodStudy](https://github.com/hufang360/TShockGoodStudy), 好好学习, 已弃坑
- 🌙 [LongNight](https://github.com/hufang360/TShockLongNight), 永夜, 已弃坑
- 💀 [DeathCounter](https://github.com/hufang360/TShockDeathCounter), 死亡统计, 已弃坑
- 👑 [DoubleBoss](https://github.com/hufang360/TShockDoubleBoss), 好事成双, 已弃坑
- 🌌 [AllowFirstFractal](https://github.com/hufang360/TShockAllowFirstFractal), 让服务端允许生成"第一分形", 鱼店插件默认包含此功能

### 非独立项目

代码量小，不怎么更新，保存在本仓库内。

- 🎯 [hfToy](./Plugins/TShockhfToy1), 射弹发射器, [hfToy1.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/hfToy1.dll)
- 🤔 [BossOrNurse](./Plugins/TShockBossOrNurse), Boss还是护士, [BossOrNurse.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/BossOrNurse.dll)
- 🇨🇳 [Lang7](./Plugins/TShockLang7), 将服务器语言设置成中文, [Lang7.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/Lang7.dll)
- ⚡ [ShowPowerMenu](./Plugins/TShockShowPowerMenu), 显示力量菜单, [ShowPowerMenu.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/ShowPowerMenu.dll)
- ⚡ [V50Reward](./Plugins/V50Reward), 疯四奖, [V50Reward.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/V50Reward.dll)

<br>

<br/>

---

<br/>

<br/>

- [tshock文档搬运](./docs/4.4.0/说明.md)
