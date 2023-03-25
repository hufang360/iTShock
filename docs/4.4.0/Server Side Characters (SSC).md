---
title: Server Side Characters (SSC)
url: https://www.yuque.com/hufang/tmp/ts-ssc
---

原始网址：<https://tshock.readme.io/docs/server-side-character-config>

<a name="t8n2A"></a>

## What Server Side Characters are

<a name="5FqHY"></a>

##

Server Side Characters is a special mechanism designed for Terraria servers that forces players to start with fresh characters when they join. This means they lose *all* of their items. This is purely server-side, though, it will not affect their actual Singleplayer character. Server Side Characters are what you need if you wish to prevent people from bringing in items from other servers and/or singleplayer and force them to start from scratch.

> <a name="guXUk"></a>

### 🚧

> <a name="tQHrP"></a>

### The SuperAdmin bypasses SSC

> The SuperAdmin account has all permissions on your server. This includes the permission to ignore Server Side Characters (\`\`
> `tshock.ignore.ssc`
> ).If you want to start with a fresh character and still have SuperAdmin privileges, create a new group and grant it the following permissions:
> *, !tshock.ignore.ssc
> . This will enable every permission (
> *
> ), then negate the SSC ignoring permission (
> !tshock.ignore.ssc
> ).Example:
> /group addperm <group name> * !tshock.ignore.ssc

<a name="1FVn9"></a>

## Enabling Server Side Characters and configuring the setup

All you have to do to enable Server Side Characters is open the **tshock** folder -> **sscconfig.json** and set the *Enabled* flag to true.
**The configuration file:**
Text

    {
      "Enabled": false,
      "ServerSideCharacterSave": 5,
      "LogonDiscardThreshold": 250,
      "StartingHealth": 100,
      "StartingMana": 20,
      "StartingInventory": [
        {
          "netID": -15,
          "prefix": 0,
          "stack": 1
        },
        {
          "netID": -13,
          "prefix": 0,
          "stack": 1
        },
        {
          "netID": -16,
          "prefix": 0,
          "stack": 1
        }
      ]
    }

*Enabled*

- Type: Boolean
- Description: Indicates whether SSC is enabled or not

*ServerSideCharacterSave*

- Type: Int32
- Description: Represents the save interval, in minutes. This means that the server will create a backup of every player's character and save it every 5 minutes

*LogonDiscardThreshold*

- Type: Int32
- Description: The time to disallow discarding items after logging in

*StartingHealth*

- Type: Int32
- Description: The amount of health points players are given upon initial login

*StartingMana*

- Type: Int32
- Description: The amount of mana points players are given upon initial login

*StartingInventory*

- Type: TShockAPI.NetItem\[]
- Description: Represents the starting kit. Players are given copper tools by default, but you can change this by modifying the *netID* field. You can find a list of item IDs on Terraria's wiki page.
