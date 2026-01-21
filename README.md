
记录和tshock有关的内容，转载部分官方文档，自己写的插件，以及保存代码量小，且不怎么更新的小插件。
<br>

# docker快速开服
```shell
docker run -it --name tshock \
  -p 7777:7777 \
  -v /root/S1/tshock/:/tshock \
  -v /root/S1/worlds/:/worlds \
  -v /root/S1/plugins/:/plugins \
  ghcr.io/pryaxis/tshock:latest \
  -world /worlds/world.wld \
  -lang 7 \
  -autocreate 3 \
  -difficulty 2
```
- `-lang 7`, 中文。
- `-autocreate`, 世界大小，1=小, 2=中, 3=大。
- `-difficulty`, 世界难度，0=普通, 1=专家, 2=大师, 3=旅行。


```shell
# 查看日志
# - 按 Ctrl+C 退出查看
docker logs -f tshock

# 进入控制台
# - 看不到旧的日志
# - 先敲一个enter键，然后输入要执行的指令
# - 先按 Ctrl+P，再按 Ctrl+Q 退出
docker attach tshock
```

- 参考连接：
  - [tshock命令行参数](https://github.com/Pryaxis/TShock/wiki/Command-line-parameters)
  - [tshock官方镜像](https://github.com/Pryaxis/TShock/pkgs/container/tshock/416082073?tag=latest)
  - [个人常用的插件](./dlls/2509/) 
<br>


# 我写过的插件

## 常用

| 项目名 | 链接 | 兼容TShock5.0 | 备注 |
| --- | --- | --- | --- |
| 自动注册 | https://github.com/hufang360/TShockAutoRegister | ✅ | fork别人的，然后做了修改 |
| 快速开服 | https://github.com/hufang360/TShockFastDeploy | ✅ | TShock4.x也能用 |
| 世界修改器 | https://github.com/hufang360/TShockWorldModify | ✅ | v1.4beta版本开始支持TShock5.0和泰拉1.4.4.x |
| 玩家管理 | https://github.com/hufang360/TShockPlayerManager | ✅ | |
| 鱼店 | https://github.com/hufang360/TShockFishShop | ✅ | |
| 查一查 | https://github.com/hufang360/TShockSearch  | ✅ | |
| 箱子小工具 | https://github.com/hufang360/TShockChestTool  | ✅ | |
| 找箱子 | https://github.com/hufang360/TShockShowMe | ✅ | .net4.x 项目，TShock4.x也能用 |


## 更多
这部分不怎么更新

| 项目名 | 链接 | 兼容TShock5.0 | 备注 |
| --- | --- | --- | --- |
| 指令晶塔 | https://github.com/hufang360/TShockPylon | ✅ | |
| 图格剪贴板 | https://github.com/hufang360/TShockClipboard | ✅ | |
| 图格动画 | https://github.com/hufang360/TShockTileAnimate | ✅ | |
| TShock调试小助手 | https://github.com/hufang360/TDB | ✅ | |
| 检查背包 | https://github.com/hufang360/TShockCheckBag  | ✅ | |
| 直播插件 | https://github.com/hufang360/TerrariaBLive  | ✅ | 原项目由ArsiIksait编写，可以把哔哩哔哩直播间的弹幕发到游戏里 |
| 大地动 | https://github.com/hufang360/TShockQuake | ✅ |
| 好运来 | https://github.com/hufang360/TShockGoodLucky | ✅ | .net4.x 项目，请下载 [GoodLucky-v1.1-TShock5.0Beta.dll](https://github.com/hufang360/TShockGoodLucky/releases/download/v1.1/GoodLucky-v1.1-TShock5.0Beta.dll) |
| 垃圾佬 | https://github.com/hufang360/TShockTrashMan | ✅ | |
| 更多商店物品 | https://github.com/hufang360/TShockMoreShopItem  | ✅ | TShock4.x也能用，商品数据跟1.4.4x不完全一样需要更新 |
| 禁NPC | https://github.com/hufang360/TShockDisableNPC  | ✅ |  |
| 禁钓鱼 | https://github.com/hufang360/TShockDisableFishing | ✅ |

## 弃坑
| 项目名 | 链接 | 兼容TShock5.0 | 备注 |
| --- | --- | --- | --- |
| 好好学习 | https://github.com/hufang360/TShockGoodStudy | - | 已弃坑 |
| 永夜 | https://github.com/hufang360/TShockLongNight | - | 已弃坑 |
| 死亡统计 | https://github.com/hufang360/TShockDeathCounter | - | 已弃坑 |
| 好事成双 | https://github.com/hufang360/TShockDoubleBoss | - | 已弃坑 |
| 让服务端允许生成“第一分形” | https://github.com/hufang360/TShockAllowFirstFractal  | 已弃坑 | 鱼店插件默认包含此功能 |


## 非独立项目 
代码量小，不怎么更新，保存在本仓库内。
| 项目名 | 源码 | 插件下载 | 备注 |
| --- | --- | --- | --- |
| hfToy-射弹发射器 | [源码](./Plugins/TShockhfToy1) | [插件下载](https://github.com/hufang360/MyTShock/raw/master/Plugins/Lang7.dll) | |
| hfToy-射弹发射器 | [源码](./Plugins/TShockhfToy1) | [插件下载](https://github.com/hufang360/MyTShock/raw/master/Plugins/Lang7.dll) | |
| Boss还是护士 | [源代码](./Plugins/TShockBossOrNurse) | [插件下载](https://github.com/hufang360/MyTShock/raw/master/Plugins/BossOrNurse.dll) | |
| Lang7，将服务器语言设置成中文 | [源代码](./Plugins/TShockLang7) | [插件下载](https://github.com/hufang360/MyTShock/raw/master/Plugins/Lang7.dll) | |
| ShowPowerMenu，显示力量菜单 | [源代码](./Plugins/TShockShowPowerMenu) | [插件下载](https://github.com/hufang360/MyTShock/raw/master/Plugins/ShowPowerMenu.dll) | |

<br>

<br/>

---

<br/>

<br/>


- [tshock文档搬运](./docs/4.4.0/说明.md)