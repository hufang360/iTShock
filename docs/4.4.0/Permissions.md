---
title: Permissions
url: https://www.yuque.com/hufang/tmp/ts-permissions
---

原始网址：<https://tshock.readme.io/docs/permissions>

All commands can be found in their raw format[here](https://github.com/NyxStudios/TShock/blob/general-devel/TShockAPI/Commands.cs).All permissions can be found in their raw format[here](https://github.com/NyxStudios/TShock/blob/general-devel/TShockAPI/Permissions.cs). <a name="GUO4Y"></a>

## Account Permissions

<a name="Thn4P"></a>

### Register Account

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.account.register |
| Description | The user can register an account in-game. |
| Commands | /register |

<a name="ZABzQ"></a>

### Login To Account

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.account.login |
| Description | The user can login to an account in-game. |
| Commands | /login |

<a name="wrQZx"></a>

### Logout Of Account

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.account.logout |
| Description | The user can logout of an account in-game. |
| Commands | /logout |

<a name="kQwzr"></a>

### Change Account Password

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.account.changepassword |
| Description | The user can change password in-game. |
| Commands | /password |

<a name="Dsnaa"></a>

## Administrative Permissions

<a name="YJIUM"></a>

### Antibuild

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.antibuild |
| Description | The user can set build protection status. |
| Commands | /antibuild |

<a name="C6119"></a>

### Ban Manager

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.ban |
| Description | The user can add/remove player bans. |
| Commands | /ban |

<a name="DFhqx"></a>

### Broadcast

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.broadcast |
| Description | The user can broadcast messages. |
| Commands | /broadcast |

<a name="pDIJI"></a>

### Group Manager

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.group |
| Description | The user can manage groups. |
| Commands | /group |

<a name="DBDxf"></a>

### Item Bans

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.itemban |
| Description | The user can manage item bans. |
| Commands | /itemban |

<a name="Z4Xel"></a>

### Kick

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.kick |
| Description | The user can kick others. |
| Commands | /kick |

<a name="PBzfI"></a>

### Mute

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.mute |
| Description | The user can mute/unmute players. |
| Commands | /mute |

<a name="gpLnu"></a>

### Ban Immunity

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.noban |
| Description | Prevents user from being banned. |

<a name="OxhAC"></a>

### Kick Immunity

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.nokick |
| Description | Prevents user from being kicked. |

<a name="x4TLH"></a>

### Projectile Bans

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.projectileban |
| Description | The user can manage projectile bans. |
| Commands | /projectileban |

<a name="cnA8i"></a>

### Region Manager

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.region |
| Description | The user can manage regions. |
| Commands | /region |

<a name="Tw6jg"></a>

### Save SSC

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.savessi |
| Description | The user can save server side character states. This is called 'savessi' because SSI is server side inventories, the previous name for this feature. |
| Commands | /overridessc, /savessc |

<a name="ySdfN"></a>

### See Player IDs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.seeplayerids |
| Description | The user can see player IDs when using /who. |

<a name="gzuFL"></a>

## Su (Substitute User)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock. |
| Description | The user can elevate their group to superadmin for 10 minutes. |
| Commands | /su |

<a name="malSU"></a>

### Tempgroup

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.tempgroup |
| Description | The user can change other players' group temporarily. |
| Commands | /tempgroup |

<a name="vDX0d"></a>

### Tile Bans

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.tileban |
| Description | The user can manage tile bans. |
| Commands | /tileban |

<a name="X5mAs"></a>

### User

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.superadmin.user |
| Description | The user can manage player accounts. |
| Commands | /user |

<a name="CTpLE"></a>

### User Info

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.userinfo |
| Description | The user can get other players' info. |
| Commands | /userinfo |

<a name="Dbc6S"></a>

### View Logs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.viewlogs |
| Description | The user can view certain log messages in-game. |
| Commands | /displaylogs |

<a name="phOVs"></a>

### Warp Manager

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.admin.warp |
| Description | The user can manage warps. |
| Commands | /warp |

<a name="nGSPl"></a>

## Buff Permissions

<a name="WkXZk"></a>

### Buff (Self)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.buff.self |
| Description | The user can buff self. |
| Commands | /buff |

<a name="wiw6V"></a>

### Buff (Others)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.buff.others |
| Description | The user can buff others. |
| Commands | /gbuff |

<a name="hrHVd"></a>

## Configuration Permissions

<a name="WUEw2"></a>

### Dump Reference Data

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.cfg.createdumps |
| Description | The user can create references files of Terraria IDs and the permission matrix in the server folder. |
| Commands | /dump-reference.data |

<a name="mNZfv"></a>

### Maintenance

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.cfg.maintenance |
| Description | The user can restart/turn off the server and receive update notifications. |
| Commands | /checkupdates, /off, /off-nosave, /restart, /version |

<a name="CSP2R"></a>

### Password

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.cfg.password |
| Description | The user can change the server password. |
| Commands | /serverpassword |

<a name="Q9SfS"></a>

### Reload

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.cfg.reload |
| Description | The user can reload the server's configuration file. |
| Commands | /reload |

<a name="joWUs"></a>

### Whitelist

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.cfg.whitelist |
| Description | The user can manage the whitelist. |
| Commands | /whitelist |

<a name="qANGk"></a>

## Ignore Permissions

<a name="yyaKU"></a>

### Ignore Damage

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.damage |
| Description | The user is immune to damage hack detection. |

<a name="yWQSF"></a>

### Ignore Drop Banned Items

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.dropbanneditem |
| Description | The user can drop banned items without automatic removal. |

<a name="j5Qcj"></a>

### Ignore HP

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.hp |
| Description | The user is immune to HP hack detection. |

<a name="MDlhL"></a>

### Ignore Item Stack

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.itemstack |
| Description | The user is immune to hacked item-stack detection. |

<a name="n4lyi"></a>

### Ignore Liquid Placement

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.liquid |
| Description | The user is immune to place-liquid abuse detection. |

<a name="II2M6"></a>

### Ignore MP

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.mp |
| Description | The user is immune to mana hack detection. |

<a name="Hjmoe"></a>

### Ignore No-Clip

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.noclip |
| Description | The user is immune to no-clip detection. |

<a name="COMM8"></a>

### Ignore Paint

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.paint |
| Description | The user is immune to paint abuse detection. |

<a name="f8n8U"></a>

### Ignore Place Tile

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.placetile |
| Description | The user is immune to place-tile abuse detection. |

<a name="JIefB"></a>

### Ignore Projectile

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.projectile |
| Description | The user is immune to projectile abuse detection. |

<a name="qUU5H"></a>

### Ignore Remove Tile

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.removetile |
| Description | The user is immune to kill-tile abuse detection. |

<a name="ZG5Et"></a>

### Ignore SendTileSquare

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.sendtilesquare |
| Description | The user is allowed unrestricted use of SendTileSquare. |

<a name="mQckt"></a>

### Ignore SSC

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ignore.ssc |
| Description | The user is immune to SSC item management. |

<a name="jKJ3U"></a>

## Item Permissions

<a name="s8Ixu"></a>

### Give Item

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.item.give |
| Description | The user can give items to other players. |
| Commands | /give |

<a name="jKLqY"></a>

### Spawn Item

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.item.spawn |
| Description | The user can spawn items. |
| Commands | /item |

<a name="w0vwj"></a>

### Use Banned Items

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.item.usebanned |
| Description | The user can use banned items. |

<a name="pfTqe"></a>

## Journey Permissions

<a name="bPfwb"></a>

### Freeze Biome Spread

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.biomespreadfreeze |
| Description | User can use Creative UI to freeze the world's biome spread. |

<a name="trYv5"></a>

### Freeze Rain

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.rain.freeze |
| Description | User can use Creative UI to freeze the rain strength/speed. |

<a name="NTChn"></a>

### Freeze Time

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.time.freeze |
| Description | User can use Creative UI to freeze time. |

<a name="hjTGE"></a>

### Freeze Wind

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.wind.freeze |
| Description | User can use Creative UI to freeze the wind strength/speed. |

<a name="PgYsj"></a>

### Godmode

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.godmode |
| Description | User can use Creative UI to to toggle character godmode. |

<a name="Adxhy"></a>

### Placement Range

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.placementrange |
| Description | User can use Creative UI to toggle increased placement range. |

<a name="C5ZoL"></a>

### Research

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.research |
| Description | User can contribute research by sacrificing items. Requires SSC. |

<a name="KFXJW"></a>

### Set Difficulty

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.setdifficulty |
| Description | User can use Creative UI to set world difficulty/mode. |

<a name="masYD"></a>

### Set Rain Speed

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.rain.strength |
| Description | User can use Creative UI to set world rain strength/speed. |

<a name="f0d5u"></a>

### Set Spawnrate

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.setspawnrate |
| Description | User can use Creative UI to set the NPC spawn rate of the world. |

<a name="NmZD8"></a>

### Set Time

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.time.set |
| Description | User can use Creative UI to set world time. |

<a name="hEAVe"></a>

### Set Time Speed

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.time.setspeed |
| Description | User can use Creative UI to set world time speed. |

<a name="kZSwO"></a>

### Set Wind Speed

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.journey.wind.strength |
| Description | User can use Creative UI to set world wind strength/speed. |

<a name="V2kqN"></a>

## NPC Permissions

<a name="HaorW"></a>

### Butcher NPCs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.butcher |
| Description | The user can butcher NPCs. |
| Commands | /butcher |

<a name="d5NY9"></a>

### Clear Angler Quests

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.clearanglerquests |
| Description | The user can clear the list of players whom have completed an angler quest for the day. |
| Commands | /clearangler |

<a name="qChy2"></a>

### Hurt Town NPCs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.hurttown |
| Description | The user can hurt town NPCs. |

<a name="TO3JU"></a>

### Max NPC Spawns

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.maxspawns |
| Description | The user can change the maximum NPC spawns. |
| Commands | /maxspawns |

<a name="CaAfY"></a>

### Rename NPC

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.rename |
| Description | The user can rename town NPCs. |
| Commands | /renamenpc |

<a name="bX2le"></a>

### Spawn Bosses

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.spawnboss |
| Description | The user can spawn bosses. |
| Commands | /spawnboss |

<a name="RgIPI"></a>

### Spawn Mob

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.spawnmob |
| Description | The user can spawn mobs. |
| Commands | /spawnmob |

<a name="eG98r"></a>

### Spawn Pets

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.spawnpets |
| Description | The user can spawn pets. |

<a name="XyVg2"></a>

### Spawn Rate

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.spawnrate |
| Description | The user can change the NPC spawn rate. |
| Commands | /spawnrate |

<a name="riZj7"></a>

### Start DD2

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.startdd2 |
| Description | The user can start the Old One's Army event. |

<a name="patAI"></a>

### Start Invasion

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.startinvasion |
| Description | The user can start invasions using items. |

<a name="DfOGH"></a>

### Summon Bosses

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.npc.summonboss |
| Description | The user can summon bosses using items. |

<a name="mg9gR"></a>

## REST Permissions

<a name="zc4pb"></a>

### Ban

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.ban |
| Description | REST user can ban players. |

<a name="Ew4hi"></a>

### Bans - Manage

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.bans.manage |
| Description | REST user can manage bans. |

<a name="dErwe"></a>

### Bans - View

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.bans.view |
| Description | REST user can get detailed information about bans. |

<a name="LPO86"></a>

### Butcher

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.butcher |
| Description | REST user can butcher NPCs. |

<a name="evI5Q"></a>

### Cause Events

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.causeevents |
| Description | REST user can cause certain events (bloodmoon, meteor). |

<a name="ucBvL"></a>

### Command

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.command |
| Description | REST user can attempt to run raw tShock commands. |

<a name="Zqsen"></a>

### Configuration

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.cfg |
| Description | REST user can reload the configuration file, save the world, and set auto-save settings. |

<a name="HqhLr"></a>

### Groups - Manage

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.groups.manage |
| Description | REST user can manage groups. |

<a name="fLqjv"></a>

### Groups - View

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.groups.view |
| Description | REST user can get detailed information about groups. |

<a name="dZobm"></a>

### Kick

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.kick |
| Description | REST user can kick players. |

<a name="x2iwx"></a>

### Kill

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.kill |
| Description | REST user can kill players. |

<a name="sePev"></a>

### Maintenance

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.maintenance |
| Description | REST user can restart/turn off the server. |

<a name="TVCKS"></a>

### Manage Tokens

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.manage |
| Description | REST user can destroy REST tokens. |

<a name="AkFsP"></a>

### Mute

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.mute |
| Description | REST user can mute players. |

<a name="vk2cu"></a>

### Use API

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.useapi |
| Description | REST user can create REST tokens. |

<a name="FTrmg"></a>

### Users - Information

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.users.info |
| Description | REST user can get user information. |

<a name="qzd2M"></a>

### Users - Manage

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.users.manage |
| Description | REST user can manage users. |

<a name="hWnBl"></a>

### Users - View

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.users.view |
| Description | REST user can get detailed information about users. |

<a name="iVJTf"></a>

### View IPs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.rest.viewips |
| Description | REST user can view players' IPs. |

<a name="iR7qM"></a>

## SSC Permissions

<a name="dH2uS"></a>

### Upload SSC

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ssc.upload |
| Description | The user can upload their joined character as SSC data. |
| Commands | /uploadssc |

<a name="ZRNqx"></a>

### Upload SSC (Others)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.ssc.upload.others |
| Description | The user can upload other players' joined character as SSC data. |

<a name="lDqLT"></a>

## Teleportation Permissions

<a name="aZMlD"></a>

### All Others

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.allothers |
| Description | The user can teleport everyone at once. |

<a name="PTZtP"></a>

### Block Teleportation

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.block |
| Description | The user can block players from teleporting to them. |
| Commands | /tpallow |

<a name="PdodV"></a>

### Get Position

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.getpos |
| Description | The user can get the position of players. |
| Commands | /pos |

<a name="RDlsB"></a>

### Home

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.home |
| Description | The user can teleport to their spawnpoint. |
| Commands | /home |

<a name="r1kGE"></a>

### NPC

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.npc |
| Description | The user can teleport to an NPC. |
| Commands | /tpnpc |

<a name="yFOKb"></a>

### Others

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.others |
| Description | The user can teleport other players. |
| Commands | /tphere |

<a name="uIJWg"></a>

### Override Teleportation Blocking

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.override |
| Description | The user can override teleportation blocking. |

<a name="Kz237"></a>

### Pylons

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.pylon |
| Description | The user can teleport using pylons. |

<a name="sGj8a"></a>

### Position

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.pos |
| Description | The user can teleport to a specific position. |
| Commands | /tppos |

<a name="NES3d"></a>

### Rod of Discord

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.rod |
| Description | The user can teleport using the Rod of Discord. |

<a name="o1SYY"></a>

### Self

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.self |
| Description | The user can teleport to other players. |
| Commands | /tp |

<a name="t9iSl"></a>

### Silent

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.silent |
| Description | The user can teleport to players without notification. |

<a name="XQVqV"></a>

### Spawn

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.spawn |
| Description | The user can teleport to the map's spawnpoint. |
| Commands | /spawn |

<a name="RfaxS"></a>

### Wormhole Potion

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tp.wormhole |
| Description | The user can teleport using a Wormhole Potion. |

<a name="fmrCA"></a>

## World Permissions

<a name="Xn1Qk"></a>

### Edit Regions

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.editregion |
| Description | The user can bypass tShock's region protection. |

<a name="SFL9U"></a>

### Edit Spawn

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.editspawn |
| Description | The user can bypass tShock's spawn protection. |

<a name="c22ct"></a>

### Events

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events |
| Description | The user has access to the /worldevent command. |
| Commands | /worldevent |

<a name="pe8ox"></a>

### Event - Blood Moon

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.bloodmoon |
| Description | The user can start a blood moon. |
| Commands | /worldevent bloodmoon |

<a name="N1rkR"></a>

### Event - Eclipse

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.eclipse |
| Description | The user can start an eclipse. |
| Commands | /worldevent eclipse |

<a name="wFgix"></a>

### Event - Full Moon

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.fullmoon |
| Description | The user can start a full moon. |
| Commands | /worldevent fullmoon |

<a name="I9809"></a>

### Event - Invasion

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.invasion |
| Description | The user can start an invasion. |
| Commands | /worldevent invasion |

<a name="eZhMT"></a>

### Event - Meteor

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.meteor |
| Description | The user can drop a meteor. |
| Commands | /worldevent meteor |

<a name="Y9vtM"></a>

### Event - Rain

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.rain |
| Description | The user can start rain. |
| Commands | /worldevent rain |

<a name="DeJVt"></a>

### Event - Sandstorm

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.events.sandstorm |
| Description | The user can start a sandstorm. |
| Commands | /worldevent sandstorm |

<a name="kIeq0"></a>

### Grow

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.grow |
| Description | The user can grow plants. |
| Commands | /grow |

<a name="dHTC2"></a>

### Hardmode

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.hardmode |
| Description | The user can toggle the map's Hardmode setting. |
| Commands | /hardmode |

<a name="fuHbP"></a>

### Info

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.info |
| Description | The user can get world information. |
| Commands | /world |

<a name="iYm55"></a>

### Modify

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.modify |
| Description | The user can modify the world. |

<a name="Rq0dD"></a>

### Move NPCs

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.movenpc |
| Description | The user can move the homes of Town NPCs. |

<a name="fLCSw"></a>

### Paint

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.paint |
| Description | The user can paint tiles. |

<a name="kDPc8"></a>

### Save

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.save |
| Description | The user can save the map. |
| Commands | /save |

<a name="m7zHO"></a>

### Set Dungeon

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.setdungeon |
| Description | The user can set the map's dungeon entrance location. |
| Commands | /setdungeon |

<a name="W2LSI"></a>

### Set Halloween

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.sethalloween |
| Description | The user can force Halloween mode. |
| Commands | /forcehalloween |

<a name="JxlyL"></a>

### Set Spawn

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.setspawn |
| Description | The user can set the map's spawnpoint. |
| Commands | /setspawn |

<a name="sVKio"></a>

### Set Christmas

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.setxmas |
| Description | The user can force Christmas mode. |
| Commands | /forcexmas |

<a name="oXjL5"></a>

### World Settle

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.settleliquids |
| Description | The user can force-settle liquids. |
| Commands | /settle |

<a name="wuaiP"></a>

### Time - Set

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.time.set |
| Description | The user can set the world time. |
| Commands | /time |

<a name="QMXwN"></a>

### Time - Use Sundial

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.time.usesundial |
| Description | The user can use the Sundial item. |

<a name="m4tiQ"></a>

### Toggle Expert Mode

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.toggleexpert |
| Description | The user can toggle the map's Expert Mode setting. |
| Commands | /expert |

<a name="VZWC0"></a>

### Toggle Party Event

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.toggleparty |
| Description | The user can toggle the party event. |

<a name="Nt6el"></a>

### Wind

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.world.wind |
| Description | The user can modify the wind speed. |
| Commands | /wind |

<a name="hQmnH"></a>

## Miscellaneous Permissions

<a name="nYLCQ"></a>

### Account Info (Check)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.accountinfo.check |
| Description | The user can check if an account is registered and its last login time. |
| Commands | /accountinfo |

<a name="ToCsA"></a>

### Account Info (Details)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.accountinfo.details |
| Description | The user can get detailed information about an account. |

<a name="ufr3I"></a>

### Annoy

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.annoy |
| Description | The user can annoy other players. |
| Commands | /annoy |

<a name="sUF3H"></a>

### Can Chat

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.canchat |
| Description | The user can chat. |

<a name="ra9Wj"></a>

### Clear

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.clear |
| Description | The user can clear items, projectiles, or NPCs. |
| Commands | /clear |

<a name="yWdDH"></a>

### Emojis

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.sendemoji |
| Description | The user can send emojis. |

<a name="grkMw"></a>

### Firework

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.annoy |
| Description | The user can spawn a firework on a player. |
| Commands | /firework |

<a name="AzjYQ"></a>

### Godmode

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.godmode |
| Description | The user can activate god-mode (regenerating health when damaged). |
| Commands | /godmode |

<a name="kw7qp"></a>

### Godmode (Others)

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.godmode.other |
| Description | The user can activate god-mode for other players. |

<a name="HLxmF"></a>

### Heal

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.heal |
| Description | The user can heal players. |
| Commands | /heal |

<a name="lngDY"></a>

### Information

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.info |
| Description | The user can get the server's information. |
| Commands | /serverinfo |

<a name="X9aIy"></a>

### Kill

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.kill |
| Description | The user can kill other players. |
| Commands | /kill |

<a name="M4OOc"></a>

### Party Chat

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.partychat |
| Description | The user can use party chat. |
| Commands | /party |

<a name="riKmK"></a>

### Projectiles - Use Banned

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.projectiles.usebanned |
| Description | The user can use banned projectiles. |

<a name="hqoSX"></a>

### Reserved Slot

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.reservedslot |
| Description | The user can bypass the max slot setting up to a total defined in config. Default 20. |

<a name="pLzAE"></a>

### Slap

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.slap |
| Description | The user can slap other players. |
| Commands | /slap |

<a name="E3SeH"></a>

### Sync

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.synclocalarea |
| Description | The user is sent all tiles from the server to resync the client with the actual world state. |
| Commands | /sync |

<a name="RYmoO"></a>

### Rocket

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.annoy |
| Description | The user can rocket a player upwards. Requires SSC. |
| Commands | /rocket |

<a name="a9Ez9"></a>

### Third Person

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.thirdperson |
| Description | The user can talk in third-person. |
| Commands | /me |

<a name="vpEN5"></a>

### Tiles - Use Banned

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.tiles.usebanned |
| Description | The user can use banned tiles. |

<a name="Fygo0"></a>

### Warp

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.warp |
| Description | The user can use warps. |
| Commands | /warp |

<a name="nqXqN"></a>

### Whisper

| **Type** | **Details** |
| --- | --- |
| Permission | tshock.whisper |
| Description | The user can whisper other players. |
| Commands | /whisper, /reply |
