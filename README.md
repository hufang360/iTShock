
记录和tshock有关的内容，转载部分官方文档，自己写的插件，以及保存代码量小，且不怎么更新的小插件。
<br>

# docker快速开服
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


# 我写过的插件

## 常用
- 🔐 [AutoRegister](https://github.com/hufang360/TShockAutoRegister), 自动注册
- 🚀 [FastDeploy](https://github.com/hufang360/TShockFastDeploy), 快速开服, TShock4.x也能用
- 🌍 [WorldModify](https://github.com/hufang360/TShockWorldModify), 世界修改器, v1.4beta版本开始支持TShock5.0和泰拉1.4.4.x
- 👥 [PlayerManager](https://github.com/hufang360/TShockPlayerManager), 玩家管理
- 🐟 [FishShop](https://github.com/hufang360/TShockFishShop), 鱼店
- 🔍 [Search](https://github.com/hufang360/TShockSearch), 查一查
- 🔎 [ShowMe](https://github.com/hufang360/TShockShowMe), 找箱子, .net4.x 项目，TShock4.x也能用
- 📦 [ChestTool](https://github.com/hufang360/TShockChestTool), 箱子小工具


## 更多
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

## 弃坑
- 📚 [GoodStudy](https://github.com/hufang360/TShockGoodStudy), 好好学习, 已弃坑
- 🌙 [LongNight](https://github.com/hufang360/TShockLongNight), 永夜, 已弃坑
- 💀 [DeathCounter](https://github.com/hufang360/TShockDeathCounter), 死亡统计, 已弃坑
- 👑 [DoubleBoss](https://github.com/hufang360/TShockDoubleBoss), 好事成双, 已弃坑
- 🌌 [AllowFirstFractal](https://github.com/hufang360/TShockAllowFirstFractal), 让服务端允许生成"第一分形", 鱼店插件默认包含此功能


## 非独立项目
代码量小，不怎么更新，保存在本仓库内。
- 🎯 [hfToy](./Plugins/TShockhfToy1), 射弹发射器, [hfToy1.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/hfToy1.dll)
- 🤔 [BossOrNurse](./Plugins/TShockBossOrNurse), Boss还是护士, [BossOrNurse.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/BossOrNurse.dll)
- 🇨🇳 [Lang7](./Plugins/TShockLang7), 将服务器语言设置成中文, [Lang7.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/Lang7.dll)
- ⚡ [ShowPowerMenu](./Plugins/TShockShowPowerMenu), 显示力量菜单, [ShowPowerMenu.dll](https://github.com/hufang360/iTShock/raw/master/Plugins/ShowPowerMenu.dll)

<br>

<br/>

---

<br/>

<br/>


- [tshock文档搬运](./docs/4.4.0/说明.md)