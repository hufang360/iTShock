---
title: config-settings
url: https://www.yuque.com/hufang/tmp/ts-config-settings
---

原始网址：<https://tshock.readme.io/docs/config-settings>

<a name="avk1y"></a>

#### Note: These configuration settings are in the config.json file created in the TShock folder automatically when TShock starts. These are separate from config.txt and other systems that ship with Terraria.

<a name="fZs1o"></a>

## Server Settings

<a name="g2DR9"></a>

### ServerPassword

| Type | String |
| --- | --- |
| Description | The server password required to join the server. |
| Default | "" |

<a name="EPcX7"></a>

### ServerPort

| Type | Int32 |
| --- | --- |
| Description | The port the server runs on. |
| Default | 7777 |

<a name="Lb7oP"></a>

### MaxSlots

| Type | Int32 |
| --- | --- |
| Description | Maximum number of clients connected at once. If you want people to be kicked with "Server is full" set this to how many players you want max and then set Terraria max players to 2 higher. |
| Default | 8 |

<a name="Wgkm9"></a>

### ReservedSlots

| Type | Int32 |
| --- | --- |
| Description | The number of reserved slots past your max server slots that can be joined by reserved players. |
| Default | 20 |

<a name="5uzw0"></a>

### ServerName

| Type | String |
| --- | --- |
| Description | Replaces the world name during a session if UseServerName is true. |
| Default | "" |

<a name="fKBX7"></a>

### UseServerName

| Type | Boolean |
| --- | --- |
| Description | Whether or not to use ServerName in place of the world name. |
| Default | false |

<a name="ObIAG"></a>

### LogPath

| Type | String |
| --- | --- |
| Description | The path to the directory where logs should be written to. |
| Default | "tshock" |

<a name="DePQQ"></a>

### DebugLogs

| Type | Boolean |
| --- | --- |
| Description | Whether or not the server should output debug level messages related to system operation. |
| Default | true |

<a name="KCZ19"></a>

### DisableLoginBeforeJoin

| Type | Boolean |
| --- | --- |
| Description | Prevents users from being able to login before they finish connecting. |
| Default | false |

<a name="kTQZI"></a>

### IgnoreChestStacksOnLoad

| Type | Boolean |
| --- | --- |
| Description | Allows stacks in chests to go beyond the stack limit during world loading. |
| Default | false |

<a name="xuz4C"></a>

## Backup and Save Settings

<a name="8Uxh2"></a>

### AutoSave

| Type | Boolean |
| --- | --- |
| Description | Enable or disable Terraria's built-in world auto save. |
| Default | true |

<a name="Ggg7i"></a>

### AnnounceSave

| Type | Boolean |
| --- | --- |
| Description | Enable or disable world save announcements. |
| Default | true |

<a name="etO0O"></a>

### ShowBackupAutosaveMessages

| Type | Boolean |
| --- | --- |
| Description | Whether or not to show backup auto save messages. |
| Default | true |

<a name="5NlEZ"></a>

### BackupInterval

| Type | Int32 |
| --- | --- |
| Description | The interval between backups, in minutes. Backups are stored in the tshock/backups folder. |
| Default | 0 |

<a name="mS6eb"></a>

### BackupKeepFor

| Type | Int32 |
| --- | --- |
| Description | For how long backups are kept in minutes. eg. 2880 = 2 days. |
| Default | 60 |

<a name="1gcT0"></a>

### SaveWorldOnCrash

| Type | Boolean |
| --- | --- |
| Description | Whether or not to save the world if the server crashes from an unhandled exception. |
| Default | true |

<a name="fSSYl"></a>

### SaveWorldOnLastPlayerExit

| Type | Boolean |
| --- | --- |
| Description | Whether or not to save the world when the last player disconnects. |
| Default | true |

<a name="hkoHI"></a>

## World Settings

<a name="PVwN2"></a>

### InvasionMultiplier

| Type | Int32 |
| --- | --- |
| Description | Determines the size of invasion events. The equation for calculating invasion size is 100 + (multiplier * (number of active players with greater than 200 health)). |
| Default | 1 |

<a name="vS4sX"></a>

### DefaultMaximumSpawns|

| Type | Int32 |
| --- | --- |
| Description | The default maximum number of mobs that will spawn per wave. Higher means more mobs in that wave. |
| Default | 5 |

<a name="Q6Kaq"></a>

### DefaultSpawnRate|

| Type | Int32 |
| --- | --- |
| Description | The delay between waves. Lower values lead to more mobs. |
| Default | 600 |

<a name="Db8gl"></a>

### InfiniteInvasion

| Type | Boolean |
| --- | --- |
| Description | Enables never ending invasion events. You still need to start the event, such as with the /invade command. |
| Default | true |

<a name="cN7gL"></a>

### PvPMode

| Type | String |
| --- | --- |
| Description | Sets the PvP mode. Valid types are: "normal", "always" and "disabled". |
| Default | "normal" |

<a name="3GxFW"></a>

### SpawnProtection

| Type | Boolean |
| --- | --- |
| Description | Prevents tiles from being placed within SpawnProtectionRadius of the default spawn. |
| Default | true |

<a name="rSVgB"></a>

### SpawnProtectionRadius

| Type | Int32 |
| --- | --- |
| Description | The tile radius around the spawn tile that is protected by the SpawnProtection setting. |
| Default | 10 |

<a name="NbbYH"></a>

### RangeChecks

| Type | Boolean |
| --- | --- |
| Description | Enable or disable anti-cheat range checks based on distance between the player and their block placements. |
| Default | true |

<a name="I5WnP"></a>

### HardcoreOnly

| Type | Boolean |
| --- | --- |
| Description | Prevents non-hardcore players from connecting. |
| Default | false |

<a name="nEVOg"></a>

### MediumcoreOnly

| Type | Boolean |
| --- | --- |
| Description | Prevents softcore players from connecting. |
| Default | false |

<a name="ChePw"></a>

### DisableBuild

| Type | Boolean |
| --- | --- |
| Description | Disables any placing, or removal of blocks. |
| Default | false |

<a name="ZBcwP"></a>

### DisableHardmode

| Type | Boolean |
| --- | --- |
| Description | If enabled, hardmode will not be activated by the Wall of Flesh or the /starthardmode command. |
| Default | false |

<a name="nWPWg"></a>

### DisableDungeonGuardian

| Type | Boolean |
| --- | --- |
| Description | Prevents the dungeon guardian from being spawned while sending players to their spawn point instead. |
| Default | false |

<a name="5KARY"></a>

### DisableClownBombs

| Type | Boolean |
| --- | --- |
| Description | Disables clown bomb projectiles from spawning. |
| Default | false |

<a name="jZz5L"></a>

### DisableSnowBalls

| Type | Boolean |
| --- | --- |
| Description | Disables snow ball projectiles from spawning. |
| Default | false |

<a name="Y7c7E"></a>

### DisableTombstones

| Type | Boolean |
| --- | --- |
| Description | Disables tombstone dropping during death for all players. |
| Default | true |

<a name="Q2lqc"></a>

### ForceTime

| Type | String |
| --- | --- |
| Description | Forces the world time to be normal, day, or night. |
| Default | "normal" |

<a name="fZiVk"></a>

### DisableInvisPvP

| Type | Boolean |
| --- | --- |
| Description | Disables the effect of invisibility potions while PvP is enabled by turning the player visible to the other clients. |
| Default | false |

<a name="8971M"></a>

### MaxRangeForDisabled

| Type | Int32 |
| --- | --- |
| Description | The maximum distance, in tiles, that disabled players can move from. |
| Default | 10 |

<a name="gVL79"></a>

### RegionProtectChests

| Type | Boolean |
| --- | --- |
| Description | Whether or not region protection should apply to chests. |
| Default | false |

<a name="4nYF9"></a>

### RegionProtectGemLocks

| Type | Boolean |
| --- | --- |
| Description | Whether or not region protection should apply to gem locks. |
| Default | true |

<a name="o425y"></a>

### IgnoreProjUpdate

| Type | Boolean |
| --- | --- |
| Description | Ignores checks to see if a player 'can' update a projectile. |
| Default | false |

<a name="g3Zn3"></a>

### IgnoreProjKill

| Type | Boolean |
| --- | --- |
| Description | Ignores checks to see if a player 'can' kill a projectile. |
| Default | false |

<a name="qgdNQ"></a>

### AllowCutTilesAndBreakables

| Type | Boolean |
| --- | --- |
| Description | Allows players to break temporary tiles (grass, pots, etc) where they cannot usually build. |
| Default | false |

<a name="Oo7Ds"></a>

### AllowIce

| Type | Boolean |
| --- | --- |
| Description | Allows ice placement even where a user cannot usually build. |
| Default | false |

<a name="yO3DK"></a>

### AllowCrimsonCreep

| Type | Boolean |
| --- | --- |
| Description | Allows the crimson to spread when a world is in hardmode. |
| Default | true |

<a name="1t5dx"></a>

### AllowCorruptionCreep

| Type | Boolean |
| --- | --- |
| Description | Allows the corruption to spread when a world is in hardmode. |
| Default | true |

<a name="4ZBFO"></a>

### AllowHallowCreep

| Type | Boolean |
| --- | --- |
| Description | Allows the hallow to spread when a world is in hardmode. |
| Default | true |

<a name="RFFDu"></a>

### StatueSpawn200

| Type | Int32 |
| --- | --- |
| Description | How many NPCs a statue can spawn within 200 pixels(?) before it stops spawning. Default = 3. |
| Default | 3 |

<a name="ZDQRb"></a>

### StatueSpawn600

| Type | Int32 |
| --- | --- |
| Description | How many NPCs a statue can spawn within 600 pixels(?) before it stops spawning. Default = 6. |
| Default | 6 |

<a name="2BC7w"></a>

### StatueSpawnWorld

| Type | Int32 |
| --- | --- |
| Description | How many NPCs a statue can spawn before it stops spawning. Default = 10. |
| Default | 10 |

<a name="AYkJQ"></a>

### PreventBannedItemSpawn

| Type | Boolean |
| --- | --- |
| Description | Prevent banned items from being spawned or given with commands. |
| Default | false |

<a name="RhWhY"></a>

### PreventDeadModification

| Type | Boolean |
| --- | --- |
| Description | Prevent players from interacting with the world while they are dead. |
| Default | true |

<a name="iMf7H"></a>

### PreventInvalidPlaceStyle

| Type | Boolean |
| --- | --- |
| Description | Prevents players from placing tiles with an invalid style. |
| Default | true |

<a name="oRS4w"></a>

### ForceXmas

| Type | Boolean |
| --- | --- |
| Description | Forces Christmas-only events to occur all year. |
| Default | false |

<a name="5lUmx"></a>

### ForceHalloween

| Type | Boolean |
| --- | --- |
| Description | Forces Halloween-only events to occur all year. |
| Default | false |

<a name="R0he2"></a>

### AllowAllowedGroupsToSpawnBannedItems

| Type | Boolean |
| --- | --- |
| Description | Allows groups on the banned item allowed list to spawn banned items even if PreventBannedItemSpawn is set to true. |
| Default | false |

<a name="Llg41"></a>

### RespawnSeconds

| Type | Int32 |
| --- | --- |
| Description | The number of seconds a player must wait before being respawned. Cannot be longer than normal value now. Use at your own risk. |
| Default | 5 |

<a name="Jtn7g"></a>

### RespawnBossSeconds

| Type | Int32 |
| --- | --- |
| Description | The number of seconds a player must wait before being respawned if there is a boss nearby. Cannot be longer than normal value now. Use at your own risk. |
| Default | 10 |

<a name="6Bqug"></a>

### AnonymousBossInvasions

| Type | Boolean |
| --- | --- |
| Description | Whether or not to announce boss spawning or invasion starts. |
| Default | true |

<a name="bY9VU"></a>

### MaxHP

| Type | Int32 |
| --- | --- |
| Description | The maximum HP a player can have, before equipment buffs. |
| Default | 500 |

<a name="52rbM"></a>

### MaxMP

| Type | Int32 |
| --- | --- |
| Description | The maximum MP a player can have, before equipment buffs. |
| Default | 200 |

<a name="Li3se"></a>

### BombExplosionRadius

| Type | Int32 |
| --- | --- |
| Description | Determines the range in tiles that a bomb can affect tiles from detonation point. |
| Default | 5 |

<a name="FPo9k"></a>

## Login and Ban Settings

<a name="0aTtg"></a>

### DefaultRegistrationGroupName

| Type | String |
| --- | --- |
| Description | The default group name to place newly registered players under. |
| Default | "default" |

<a name="bThHS"></a>

### DefaultGuestGroupName

| Type | String |
| --- | --- |
| Description | The default group name to place unregistered players under. |
| Default | "guest" |

<a name="j0aGG"></a>

### RememberLeavePos

| Type | Boolean |
| --- | --- |
| Description | Remembers where a player left off, based on their IP. Does not persist through server restarts. eg. When you try to disconnect, and reconnect to be automatically placed at spawn, you'll be at your last location. |
| Default | false |

<a name="WrKfC"></a>

### MaximumLoginAttempts

| Type | Int32 |
| --- | --- |
| Description | Number of failed login attempts before kicking the player. |
| Default | 3 |

<a name="4grmg"></a>

### KickOnMediumcoreDeath

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick mediumcore players on death. |
| Default | false |

<a name="kSqRh"></a>

### MediumcoreKickReason

| Type | String |
| --- | --- |
| Description | The reason given if kicking a mediumcore players on death. |
| Default | "Death results in a kick" |

<a name="UbIjS"></a>

### BanOnMediumcoreDeath

| Type | Boolean |
| --- | --- |
| Description | Whether or not to ban mediumcore players on death. |
| Default | false |

<a name="Rbqsc"></a>

### MediumcoreBanReason

| Type | String |
| --- | --- |
| Description | The reason given if banning a mediumcore player on death. |
| Default | "Death results in a ban" |

<a name="qsSHk"></a>

### EnableWhitelist

| Type | Boolean |
| --- | --- |
| Description | Enable or disable the whitelist based on IP addresses in the whitelist.txt file. |
| Default | false |

<a name="VI468"></a>

### WhitelistKickReason

| Type | String |
| --- | --- |
| Description | The reason given when kicking players for not being on the whitelist. |
| Default | "You are not on the whitelist." |

<a name="miL49"></a>

### ServerFullReason

| Type | String |
| --- | --- |
| Description | The reason given when kicking players that attempt to join while the server is full. |
| Default | "Server is full" |

<a name="QVRps"></a>

### ServerFullNoReservedReason

| Type | String |
| --- | --- |
| Description | The reason given when kicking players that attempt to join while the server is full with no reserved slots available. |
| Default | "Server is full. No reserved slots open." |

<a name="pBGqq"></a>

### KickOnHardcoreDeath

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick hardcore players on death. |
| Default | false |

<a name="A3pHi"></a>

### HardcoreKickReason

| Type | String |
| --- | --- |
| Description | The reason given when kicking hardcore players on death. |
| Default | "Death results in a kick" |

<a name="vgqjK"></a>

### BanOnHardcoreDeath

| Type | Boolean |
| --- | --- |
| Description | Whether or not to ban hardcore players on death. |
| Default | false |

<a name="e3BFY"></a>

### HardcoreBanReason

| Type | String |
| --- | --- |
| Description | The reason given when banning hardcore players on death. |
| Default | "Death results in a ban" |

<a name="AyDrN"></a>

### EnableIPBans

| Type | Boolean |
| --- | --- |
| Description | Enables kicking banned users by matching their IP Address. |
| Default | true |

<a name="0T2rY"></a>

### EnableUUIDBans

| Type | Boolean |
| --- | --- |
| Description | Enables kicking banned users by matching their client UUID. |
| Default | true |

<a name="6GMd3"></a>

### EnableBanOnUsernames

| Type | Boolean |
| --- | --- |
| Description | Enables kicking banned users by matching their Character Name. |
| Default | false |

<a name="Ifw6v"></a>

### KickProxyUsers

| Type | Boolean |
| --- | --- |
| Description | If GeoIP is enabled, this will kick users identified as being under a proxy. |
| Default | true |

<a name="QZ0c4"></a>

### RequireLogin

| Type | Boolean |
| --- | --- |
| Description | Require all players to register or login before being allowed to play. |
| Default | false |

<a name="9MGpH"></a>

### AllowLoginAnyUsername

| Type | Boolean |
| --- | --- |
| Description | Allows users to login to any account even if the username doesn't match their character name. |
| Default | true |

<a name="1z3py"></a>

### AllowRegisterAnyUsername

| Type | Boolean |
| --- | --- |
| Description | Allows users to register a username that doesn't necessarily match their character name. |
| Default | false |

<a name="kk2i2"></a>

### MinimumPasswordLength

| Type | Int32 |
| --- | --- |
| Description | The minimum password length for new user accounts. Can never be lower than 4. |
| Default | 4 |

<a name="1cARv"></a>

### HashAlgorithm

| Type | String |
| --- | --- |
| Description | The hash algorithm used to encrypt user passwords. Valid types: "sha512", "sha256" and "md5". Append with "-xp" for the xp supported algorithms. |
| Default | "sha512" |

<a name="jMF0u"></a>

### BCryptWorkFactor

| Type | Int32 |
| --- | --- |
| Description | Determines the BCrypt work factor to use. If increased, all passwords will be upgraded to new work-factor on verify. The number of computational rounds is 2^n. Increase with caution. Range: 5-31. |
| Default | 7 |

<a name="KQVdb"></a>

### DisableUUIDLogin

| Type | Boolean |
| --- | --- |
| Description | Prevents users from being able to login with their client UUID. |
| Default | false |

<a name="Jsb1G"></a>

### KickEmptyUUID

| Type | Boolean |
| --- | --- |
| Description | Kick clients that don't send their UUID to the server. |
| Default | false |

<a name="iG4RQ"></a>

### TilePaintThreshold

| Type | Int32 |
| --- | --- |
| Description | Disables a player if this number of tiles is painted within 1 second. |
| Default | 15 |

<a name="XyEZ2"></a>

### KickOnTilePaintThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the TilePaint threshold. |
| Default | false |

<a name="Ir3bd"></a>

### MaxDamage

| Type | Int32 |
| --- | --- |
| Description | The maximum damage a player/NPC can inflict. |
| Default | 1175 |

<a name="1IDxs"></a>

### MaxProjDamage

| Type | Int32 |
| --- | --- |
| Description | The maximum damage a projectile can inflict. |
| Default | 1175 |

<a name="IIYob"></a>

### KickOnDamageThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the MaxDamage threshold. |
| Default | false |

<a name="c3w6U"></a>

### TileKillThreshold

| Type | Int32 |
| --- | --- |
| Description | Disables a player and reverts their actions if this number of tile kills is exceeded within 1 second. |
| Default | 60 |

<a name="ooiAg"></a>

### KickOnTileKillThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the TileKill threshold. |
| Default | false |

<a name="Tcxsw"></a>

### TilePlaceThreshold

| Type | Int32 |
| --- | --- |
| Description | Disables a player and reverts their actions if this number of tile places is exceeded within 1 second. |
| Default | 32 |

<a name="tqZjF"></a>

### KickOnTilePlaceThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the TilePlace threshold. |
| Default | false |

<a name="BKKg6"></a>

### TileLiquidThreshold

| Type | Int32 |
| --- | --- |
| Description | Disables a player if this number of liquid sets is exceeded within 1 second. |
| Default | 50 |

<a name="ZPoN6"></a>

### KickOnTileLiquidThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the TileLiquid threshold. |
| Default | false |

<a name="afEmE"></a>

### ProjIgnoreShrapnel

| Type | Boolean |
| --- | --- |
| Description | Whether or not to ignore shrapnel from crystal bullets for the projectile threshold count. |
| Default | true |

<a name="rQYe8"></a>

### ProjectileThreshold

| Type | Int32 |
| --- | --- |
| Description | Disable a player if this number of projectiles is created within 1 second. |
| Default | 50 |

<a name="jhPmN"></a>

### KickOnProjectileThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the Projectile threshold. |
| Default | false |

<a name="2mgXC"></a>

### HealOtherThreshold

| Type | Int32 |
| --- | --- |
| Description | Disables a player if this number of HealOtherPlayer packets is sent within 1 second. |
| Default | 50 |

<a name="ylywi"></a>

### KickOnHealOtherThresholdBroken

| Type | Boolean |
| --- | --- |
| Description | Whether or not to kick users when they surpass the HealOther threshold. |
| Default | false |

<a name="2DerO"></a>

## Chat Settings

<a name="idVSL"></a>

### CommandSpecifier

| Type | String |
| --- | --- |
| Description | Specifies which string starts a command. Note: Will not function properly if the string length is bigger than 1. |
| Default | "/" |

<a name="Z5ICz"></a>

### CommandSilentSpecifier

| Type | String |
| --- | --- |
| Description | Specifies which string starts a command silently. Note: Will not function properly if the string length is bigger than 1. |
| Default | "." |

<a name="BtTpP"></a>

### DisableSpewLogs

| Type | Boolean |
| --- | --- |
| Description | Disables sending logs as messages to players with the log permission. |
| Default | true |

<a name="rmUZC"></a>

### DisableSecondUpdateLogs

| Type | Boolean |
| --- | --- |
| Description | Prevents OnSecondUpdate checks from writing to the log file. |
| Default | false |

<a name="0dfg8"></a>

### SuperAdminChatRGB

| Type | Int32 |
| --- | --- |
| Description | The chat color for the superadmin group. #.#.# = Red/Blue/Green Max value: 255 |
| Default | { 255, 255, 255 } |

<a name="znAYM"></a>

### SuperAdminChatPrefix

| Type | String |
| --- | --- |
| Description | The superadmin chat prefix. |
| Default | "(Super Admin) " |

<a name="Zxqqk"></a>

### SuperAdminChatSuffix

| Type | String |
| --- | --- |
| Description | The superadmin chat suffix. |
| Default | "" |

<a name="Sw9hY"></a>

### EnableGeoIP

| Type | Boolean |
| --- | --- |
| Description | Whether or not to announce a player's geographic location on join, based on their IP. |
| Default | false |

<a name="QNXdG"></a>

### DisplayIPToAdmins

| Type | Boolean |
| --- | --- |
| Description | Displays a player's IP on join to users with the log permission. |
| Default | false |

<a name="HVbIk"></a>

### ChatFormat

| Type | String |
| --- | --- |
| Description | Changes in-game chat format: {0} = Group Name, {1} = Group Prefix, {2} = Player Name, {3} = Group Suffix, {4} = Chat Message. |
| Default | "{1}{2}{3}: {4}" |

<a name="S2f1c"></a>

### ChatAboveHeadsFormat

| Type | String |
| --- | --- |
| Description | Changes the player name when using chat above heads. Starts with a player name wrapped in brackets, as per Terraria's formatting. Same formatting as ChatFormat without the message. |
| Default | "{2}" |

<a name="HP3bT"></a>

### EnableChatAboveHeads

| Type | Boolean |
| --- | --- |
| Description | Whether or not to display chat messages above players' heads. |
| Default | false |

<a name="dgT6T"></a>

### BroadcastRGB

| Type | Int32 |
| --- | --- |
| Description | The RGB values used for the color of broadcast messages. #.#.# = Red/Blue/Green Max value: 255 |
| Default | { 127, 255, 212 } |

<a name="Acuy7"></a>

## SQL Settings

<a name="cf2R3"></a>

### StorageType

| Type | String |
| --- | --- |
| Description | The type of database to use when storing data (either "sqlite" or "mysql"). |
| Default | "sqlite" |

<a name="qUlFl"></a>

### SqliteDBPath

| Type | String |
| --- | --- |
| Description | The path of sqlite db. |
| Default | "tshock.sqlite" |

<a name="XoNJC"></a>

### MySqlHost

| Type | String |
| --- | --- |
| Description | The MySQL hostname and port to direct connections to. |
| Default | "localhost:3306" |

<a name="54BWA"></a>

### MySqlDbName

| Type | String |
| --- | --- |
| Description | The database name to connect to when using MySQL as the database type. |
| Default | "" |

<a name="OV64t"></a>

### MySqlUsername

| Type | String |
| --- | --- |
| Description | The username used when connecting to a MySQL database. |
| Default | "" |

<a name="kHfnn"></a>

### MySqlPassword

| Type | String |
| --- | --- |
| Description | The password used when connecting to a MySQL database. |
| Default | "" |

<a name="00BYq"></a>

### UseSqlLogs

| Type | Boolean |
| --- | --- |
| Description | Whether or not to save logs to the SQL database instead of a text file. Default = false. |
| Default | false |

<a name="DUpZl"></a>

### RevertToTextLogsOnSqlFailures

| Type | Int32 |
| --- | --- |
| Description | Number of times the SQL log must fail to insert logs before falling back to the text log. |
| Default | 10 |

<a name="56IsI"></a>

## REST API Settings

<a name="2eI76"></a>

### RestApiEnabled

| Type | Boolean |
| --- | --- |
| Description | Enable or disable the REST API. |
| Default | false |

<a name="qvqWO"></a>

### RestApiPort

| Type | Int32 |
| --- | --- |
| Description | The port used by the REST API. |
| Default | 7878 |

<a name="cJ8Rq"></a>

### LogRest

| Type | Boolean |
| --- | --- |
| Description | Whether or not to log REST API connections. |
| Default | false |

<a name="165hH"></a>

### EnableTokenEndpointAuthentication

| Type | Boolean |
| --- | --- |
| Description | Whether or not to require token authentication to use the |
| Default | false |

<a name="okBA8"></a>

### RESTMaximumRequestsPerInterval

| Type | Int32 |
| --- | --- |
| Description | The maximum REST requests in the bucket before denying requests. Minimum value is 5. |
| Default | 5 |

<a name="pxZoV"></a>

### RESTRequestBucketDecreaseIntervalMinutes

| Type | Int32 |
| --- | --- |
| Description | How often in minutes the REST requests bucket is decreased by one. Minimum value is 1 minute. |
| Default | 1 |

<a name="Oa0s1"></a>

### ApplicationRestTokens

| Type | Dictionary\<String, SecureRest.TokenData> |
| --- | --- |
| Description | A dictionary of REST tokens that external applications may use to make queries to your server. |
| Default | {} |
