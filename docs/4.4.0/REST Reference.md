---
title: REST Reference
url: https://www.yuque.com/hufang/tmp/reference
---

原始网址：<https://tshock.readme.io/reference>

<a name="t1nlY"></a>

## REST API Endpoints

<a name="cxjrw"></a>

## Description

The REST API of tshock allows for increased functionality and interaction with the server through web-based commands.The API works through what are called "end points" which are basically commands that are send to the server through a URL. <a name="wn0MJ"></a>

### 📘Note:

While most of this information is accurate (setting it up, acquiring a token), this documentation is quite old, and more endpoints have been added or changed. Please visit us in Slack if you require more assistance with the API. <a name="BebDh"></a>

### 👍Technical Information:

All responses by the API are JSON encoded. <a name="WWbMd"></a>

## Setting it all up

To use the API first it must be enabled. You can enable it through the config.json file that is created by the tshock server.To enable the REST API find the following lines in the config.json file:"RestApiEnabled": false,"RestApiPort": 7878,
Change the "false" to "true" and restart the server.
Next you will have to create a token. A token is a unique string that identifies you to the server. To create a token visit thefollowing URL in your web-browser or, if you are a developer, get your program to access it:http://IP-ADDRESS-OF-SERVER:RESTAPI-PORT/v2/token/create?username={username}\&password={password}If you ever need to destroy a token then you would usehttp://IP-ADDRESS-OF-SERVER:RESTAPI-PORT/token/destroy/{token}?token={token}
It's important to note that REST tokens generated in this fashion will not be persisted across sessions.If you want REST tokens that are usable across sessions (i.e., after server restarts), you can create Application REST Tokens in the TShock config.json file. <a name="I2ka0"></a>

### ❗️Note:

Your Application REST Token's name should be hard to guess!Anyone who knows the token name can use it.
Restrict the permissions on the usergroup you assign to the user you use for your tokens in order to avoid security breaches!

```json
"ApplicationRestTokens": {
    "This_Is_Your_Token_Name_And_Should_Be_Hard_To_Guess": {
      "Username": "This should be an existing username",
      "UserGroupName": "This should be the group belonging to the user"
    },
    "REST_BAN_MANAGER_TOKEN_61238": {
        "Username": "REST_Banner",
        "UserGroupName": "REST_Ban_Group"
    }
  }
```

<a name="aA9Ur"></a>

## Usage

End-points are fairly self-explanatory however a few things that may not be: When using the REST API the tokenthat you created in "setting it all up" must be appended as a parameter in about 90% of the end-points (thesewill be shown in the references at the bottom of the page).
The API is used in the following manner:http://IP-ADDRESS-OF-SERVER:RESTAPI-PORT/endpoint?token={token}
in other words, if you wanted to get a list of all the players that are currently on the server then you woulduse it as such:[http://127.0.0.1:7878/lists/players?token={token}](http://127.0.0.1:7878/lists/players?token=%7Btoken%7D)
or say you needed to add extra parameters to the call? This would be accomplished in the following method:[http://127.0.0.1:7878/v2/players/read?player=someplayer\&token={token}](http://127.0.0.1:7878/v2/players/read?player=someplayer\&token=%7Btoken%7D)
As you can see all parameters are simply separated by an ampersand (the & symbol). <a name="HakIC"></a>

## End Points

<a name="DBIM4"></a>

## Status codes

| **Status Code** | **Meaning** |
| --- | --- |
| HTTP 200 | The command succeed and the return may also include a "response" message. |
| HTTP 400 | There was an error and the return will include an error message providing additional information about the failure. |
| HTTP 401 | A secure endpoint (which requires an authenticated token) was used without supplying an authenticated token. |
| HTTP 403 | Returned solely by the token creation endpoint, this value indicates that the supplied credentials are invalid. |
| HTTP 404 | The endpoint does not exist. |

<a name="ruAyE"></a>

## Server Commands

<a name="ps8V3"></a>

## **/status**

**Description**: Prints out a basic information about the servers status
**Parameters**: N/A
**Returns**:name - Server nameport - Port the server is running onplayercount - Number of players currently onlineplayers - Player names separated by a comma <a name="u4A0m"></a>

## **/tokentest**

**Description**: Tests the token to see if it is valid
**Parameters**:token - The token to be tested
**Returns**:response - A response message <a name="OodgM"></a>

## **/v2/token/create**

**Description**: Creates an authenticated token for use with other endpoints
**Parameters**:username - User with which to authenticate the tokenpassword - User's password
%20 and + can be used to replace whitespace in usernames and passwords.
**Returns**:HTTP 200 if the authentication succeedsHTTP 403 if the authentication failsresponse - Error message if the authentication failed, else an authenticated token.
Examples
200 response:
https://ip:port/v2/token/create?username=example\&password=example
{
&#x20; "status": "200",
&#x20; "response": "Successful login",
&#x20; "token": "F7FCC991A229448AE73C6179DFD4815E73AD69BA44FA2A0063FCD6286BBCDAB4"
}&#x20;
&#x20;
403 response:
https://ip:port/v2/token/create?username=example\&password=example
{
&#x20; "status": "403",
&#x20; "error": "Username or password may be incorrect or this account may not have sufficient privileges."
}

<a name="oLCwD"></a>

## **/v2/server/broadcast**

**Description**: Performs a server broadcast to all players on the server
**Parameters**:token - A valid tokenmsg - The message to broadcast**Returns**:response - A response message <a name="JbTQM"></a>

## **/v2/server/off**

**Description**: Shuts down the server
**Parameters**:token - A valid tokenconfirm - A bool value confirming whether or not to shut down the servernosave - A bool value indicating whether or not to save the world before shutting down the server
**Returns**:response - A response message <a name="YtZFI"></a>

## **/v2/server/status**

**Description**: Prints out details about the status of the currently running server
**Parameters**:players - A bool value indicating if the status response should include player informationrules - A bool value indicating if the status response should include rule information- values indicating player columns which players must match to be returned if player output is enabled
**Returns**:name - Server nameport - Port the server is running onplayercount - Number of players currently onlinemaxplayers - The maximum number of players the server supportworld - The name of the currently running worldplayers - (optional) an array of players including the following information: nickname, username, ip, group, active, state, teamrules - (optional) an array of server rules which are name value pairs e.g. AutoSave, DisableBuild etc <a name="EGaCE"></a>

## **/v2/server/rawcmd**

**Description**: Issues a raw command on the server just as if you typed it into the console.
**Parameters**:token - A valid tokencmd - The command to execute on the server
**Returns**:response - The response from the executed commandUser Commands <a name="pQdEU"></a>

## **/v2/users/activelist**

**Description**: Returns a list of currently active users on the server
**Parameters**:token - A valid token
**Returns**:activeusers - List of active users separated by a tab character <a name="gc0et"></a>

## **/v2/users/read**

**Description**: Returns information about a specified user
**Parameters**:token - A valid tokentype - (defaults to name) name, id or ip indicating what the "user" parameter refers touser - The name, ip or id of a currently registered user
**Returns**:group - The group the user belong's toid - The user's IDname - The name of the userip - The ip of the user <a name="BDcJm"></a>

## **/v2/users/create**

**Description**: Creates a user in the database
**Parameters**:token - A valid tokentype - (defaults to name) name, id or ip indicating what the "user" parameter refers touser - The name of the user to registerpassword - The password you wish to assign to the usergroup - The group you wish to assign to the userip - The ip you wish to assign to the user
**Returns**:response - A response message <a name="s4CjH"></a>

## **/v2/users/destroy**

**Description**: Deletes a user from the database
**Parameters**:token - A valid tokentype - (defaults to name) name, id or ip indicating what the "user" parameter refers touser - The name, ip or id of a currently registered user
**Returns**:response - A response message <a name="MftgO"></a>

## **/v2/users/update**

**Description**: Edits the settings of a user
**Parameters**:token - A valid tokentype - (defaults to name) name, id or ip indicating what the "user" parameter refers touser - The name, ip or id of a currently registered userpassword - The new password you wish to assign to that user (optional)group - The new group you wish to assign to that user (optional)
**Returns**:response - A response message <a name="Ihykp"></a>

## Ban Commands

<a name="ikFDX"></a>

## **/bans/create**

**Description**: Bans a player from the server
**Parameters**:token - A valid tokenip - The IP address of the user being banned (optional)name - The username of the user being banned (optional)reason - The reason for banning the user (optional)
**Returns**:response - A response message <a name="qgFBQ"></a>

## **/v2/bans/read**

**Description**: Displays information on a ban
**Parameters**:token - A valid tokentype - either "user" or "ip" dependinguser - Either the username or the IP address
**Returns**:name - The username of the playerip - The IP address of the playerreason - The reason the player was banned <a name="DnDK7"></a>

## **/v2/bans/destroy**

**Description**: Removes a player/IP from the ban list
**Parameters**:token - A valid tokenban- Either the username or the IP addresstype - either "user" or "ip" depending
**Returns**:response - A response message <a name="dTDid"></a>

## **/v2/bans/list**

**Description**: Prints out all banned players currently in the database
**Parameters**:token - A valid token
**Returns**:bans - A array of all the currently banned players including: name, ip & reason <a name="KKFEc"></a>

## Player Commands

<a name="QR5pt"></a>

## **/v2/players/list**

**Description**: Prints out all players that are currently on the server.
**Parameters**:token - A valid token
**Returns**:players - A list of all current players on the server, separated by a comma. <a name="MwyML"></a>

## **/v2/players/read**

**Description**: Prints out detailed information about a player
**Parameters**:token - A valid tokenplayer - An active player's nickname
**Returns**:nickname - The player's nicknameusername - The player's username (if they are registered)ip - The player's IP addressgroup - The group that the player belong's toposition - The player's current position on the mapinventory - A list of all items in the player's inventorybuffs - A list of all buffs that are currently affecting the player <a name="gBNuM"></a>

## **/v2/players/kick**

**Description**: Kicks a player from the server
**Parameters**:token - A valid tokenplayer - A current player's nicknamereason - The reason for kicking the player (optional)
**Returns**:response - A response message <a name="zsYHB"></a>

## **/v2/players/ban**

**Description**: Bans a player from the server
**Parameters**:token - A valid tokenplayer - A current player's nicknamereason - The reason for banning the player (optional)
**Returns**:response - A response message <a name="DwbVY"></a>

## **/v2/players/kill**

**Description**: Kills a player on the server
**Parameters**:token - A valid tokenplayer - A current player's nickname
**Returns**:response - A response message <a name="RM3iQ"></a>

## **/v2/players/mute**

**Description**: Mutes a player on the server
**Parameters**:token - A valid tokenplayer - A current player's nicknamereason - The reason for muting the player (optional)
**Returns**:response - A response message <a name="nKNKb"></a>

## **/v2/players/unmute**

**Description**: Unmutes a player on the server
**Parameters**:token - A valid tokenplayer - A current player's nicknamereason - The reason for un-muting the player (optional)
**Returns**:response - A response message <a name="ibed3"></a>

## World Commands

<a name="MJBE9"></a>

## **/world/read**

**Description**: Prints out a lot of information about the world being run on the server.
**Parameters**:token - A valid token
**Returns**:name - The world namesize - The dimensions of the worldtime - The current time in the worlddaytime - Bool value indicating whether it is daytime or notbloodmoon - Bool value indicating whether there is a blood moon or notinvasionsize - The current invasion size <a name="EX5p3"></a>

## **/world/meteor**

**Description**: Spawns a meteor in the world
**Parameters**:token - A valid token
**Returns**:response - A response message <a name="WcEJc"></a>

## **/world/bloodmoon/{bool}**

**Description**: Turns blood moon on or off
**Parameters**:token - A valid token
**Returns**:response - A response message <a name="iBjFb"></a>

## **/v2/world/save**

**Description**: Saves the world. (Same as using the /save command in the console)
**Parameters**:token - A valid token
**Returns**:response - A response message <a name="QKaHL"></a>

## **/v2/world/autosave/state/{bool}**

**Description**: Turns the auto-save feature on or off
**Parameters**:token - A valid token
**Returns**:response - A response message <a name="P4jpf"></a>

## **/v2/world/butcher**

**Description**: Kills all NPCs on the map.
**Parameters**:token - A valid tokenkillfriendly - Bool value indicating whether or not to kill friendly NPCs
**Returns**:response - A response message <a name="XzvEe"></a>

## Group Commands

<a name="uuvku"></a>

## **/v2/groups/create**

**Description**: Creates a new group on the server
**Parameters**:token - A valid tokengroup - The name of the new groupparent - The name of the new groups parent grouppermissions - A comma separated list of permissions for the new group.chatcolor - A color in R,G,B form e.g. 255,255,255
**Returns**:response - A response message <a name="X4KeQ"></a>

### 📘Note:

Permissions prefixed with ! will become negated permissions which cancel the inheritance of a permission from parent groups <a name="GbpIA"></a>

## **/v2/groups/destroy**

**Description**: Destroys a existing group
**Parameters**:token - A valid tokengroup - The name of the group to destroy
**Returns**:response - A response message <a name="bzsa8"></a>

## **/v2/groups/list**

Description: Returns an array of the groups configured on the server
**Parameters**:token - A valid token
**Returns**:groups - An array of the groups configured on the server including: name, parent & chatcolor <a name="z5VmD"></a>

## **/v2/groups/read**

**Description**: Returns detailed information about the requested group
**Parameters**:token - A valid tokengroup - The name of the group to return information about
**Returns**:name - The name of the groupparent - The name of the parent of this groupchatcolor - The chat color of this grouppermissions - An array of permissions assigned "directly" to this groupnegatedpermissions - An array of negated permissions assigned "directly" to this grouptotalpermissions - An array of the calculated permissions available to members of this group due to direct permissions and inherited permissions <a name="mfPL0"></a>

## **/v2/groups/update**

**Description**: Returns an array of the groups configured on the server
**Parameters**:token - A valid tokengroup - The name of the group to updateparent - The new parent for the group (optional)chatcolor- The new chat color for the group (optional)permissions - The new permissions, comma separated and with ! prefix to indicate a negated permission, for the group (optional)
**Returns**:response - A response messageMisc Information
JSON Reply Format:
{
&#x20;“status”: “200”,
&#x20;blah,
&#x20;blah
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/raw-rest-overview) <a name="Pa4Cg"></a>

## \[Raw] REST Overview

BanCreateDescription: Create a new ban entry.Permissions: tshock.rest.bans.manageNouns:ip(Optional) \[String] - The IP to ban, at least this or name must be specified.name(Optional) \[String] - The name to ban, at least this or ip must be specified.reason(Optional) \[String] - The reason to assign to the ban.token(Required) \[String] - The REST authentication token.Example Usage: /bans/create?ip=ip\&name=name\&reason=reason\&token=token
BanDestroyV2Description: Delete an existing ban entry.Permissions: tshock.rest.bans.manageNouns:ban(Required) \[String] - The search criteria, either an IP address or a name.type(Required) \[String] - The type of search criteria, 'ip' or 'name'. Also used as the method of removing from the database.caseinsensitive(Optional) \[Boolean] - Name lookups should be case insensitive.token(Required) \[String] - The REST authentication token.Example Usage: /v2/bans/destroy?ban=ban\&type=type\&caseinsensitive=caseinsensitive\&token=token
BanInfoV2Description: View the details of a specific ban.Permissions: tshock.rest.bans.viewNouns:ban(Required) \[String] - The search criteria, either an IP address or a name.type(Required) \[String] - The type of search criteria, 'ip' or 'name'.caseinsensitive(Optional) \[Boolean] - Name lookups should be case insensitive.token(Required) \[String] - The REST authentication token.Example Usage: /v2/bans/read?ban=ban\&type=type\&caseinsensitive=caseinsensitive\&token=token
BanListV2Description: View all bans in the TShock database.Permissions: tshock.rest.bans.viewNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/bans/list?token=token
GroupCreateDescription: Create a new group.Permissions: tshock.rest.groups.manageNouns:group(Required) \[String] - The name of the new group.parent(Optional) \[String] - The name of the parent group.permissions(Optional) \[String] - A comma seperated list of permissions for the new group.chatcolor(Optional) \[String] - A r,g,b string representing the color for this groups chat.token(Required) \[String] - The REST authentication token.Example Usage: /v2/groups/create?group=group\&parent=parent\&permissions=permissions\&chatcolor=chatcolor\&token=token
GroupDestroyDescription: Delete a group.Permissions: tshock.rest.groups.manageNouns:group(Required) \[String] - The group name to delete.token(Required) \[String] - The REST authentication token.Example Usage: /v2/groups/destroy?group=group\&token=token
GroupInfoDescription: Display information of a group.Permissions: tshock.rest.groups.viewNouns:group(Required) \[String] - The group name to get information on.token(Required) \[String] - The REST authentication token.Example Usage: /v2/groups/read?group=group\&token=token
GroupListDescription: View all groups in the TShock database.Permissions: tshock.rest.groups.viewNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/groups/list?token=token
PlayerBanV2Description: Add a ban to the database.Permissions: tshock.rest.ban, tshock.rest.bans.manageNouns:player(Required) \[String] - The player to kick.reason(Optional) \[String] - The reason the user was banned.token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/ban?player=player\&reason=reason\&token=token
PlayerKickV2Description: Kick a player off the server.Permissions: tshock.rest.kickNouns:player(Required) \[String] - The player to kick.reason(Optional) \[String] - The reason the player was kicked.token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/kick?player=player\&reason=reason\&token=token
PlayerKillDescription: Kill a player.Permissions: tshock.rest.killNouns:player(Required) \[String] - The player to kick.from(Optional) \[String] - Who killed the player.token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/kill?player=player\&from=from\&token=token
PlayerListDescription: List all player names that are currently on the server.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /lists/players?token=token
PlayerListV2Description: Fetches detailed user information on all connected users, and can be filtered by specifying a key value pair filter users where the key is a field and the value is a users field value.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/list?token=token
PlayerMuteDescription: Mute a player.Permissions: tshock.rest.muteNouns:player(Required) \[String] - The player to mute.token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/mute?player=player\&token=token
PlayerReadV3Description: Get information for a user.Permissions: tshock.rest.users.infoNouns:player(Required) \[String] - The player to lookuptoken(Required) \[String] - The REST authentication token.Example Usage: /v3/players/read?player=player\&token=token
PlayerUnMuteDescription: Unmute a player.Permissions: tshock.rest.muteNouns:player(Required) \[String] - The player to mute.token(Required) \[String] - The REST authentication token.Example Usage: /v2/players/unmute?player=player\&token=token
ServerBroadcastDescription: Broadcast a server wide message.No special permissions are required for this route.Nouns:msg(Required) \[String] - The message to broadcast.token(Required) \[String] - The REST authentication token.Example Usage: /v2/server/broadcast?msg=msg\&token=token
ServerCommandV3Description: Executes a remote command on the server, and returns the output of the command.Permissions: tshock.rest.commandNouns:cmd(Required) \[String] - The command and arguments to execute.token(Required) \[String] - The REST authentication token.Example Usage: /v3/server/rawcmd?cmd=cmd\&token=token
ServerMotdDescription: Returns the motd, if it exists.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /v3/server/motd?token=token
ServerOffDescription: Turn the server off.Permissions: tshock.rest.maintenanceNouns:confirm(Required) \[Boolean] - Required to confirm that actually want to turn the server off.message(Optional) \[String] - The shutdown message.nosave(Optional) \[Boolean] - Shutdown without saving.token(Required) \[String] - The REST authentication token.Example Usage: /v2/server/off?confirm=confirm\&message=message\&nosave=nosave\&token=token
ServerReloadDescription: Reload config files for the server.Permissions: tshock.rest.cfgNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v3/server/reload?token=token
ServerRestartDescription: Attempt to restart the server.Permissions: tshock.rest.maintenanceNouns:confirm(Required) \[Boolean] - Confirm that you actually want to restart the servermessage(Optional) \[String] - The shutdown message.nosave(Optional) \[Boolean] - Shutdown without saving.token(Required) \[String] - The REST authentication token.Example Usage: /v3/server/restart?confirm=confirm\&message=message\&nosave=nosave\&token=token
ServerRulesDescription: Returns the rules, if they exist.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /v3/server/rules?token=token
ServerStatusV2Description: Get a list of information about the current TShock server.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/server/status?token=token
ServerTokenTestDescription: Test if a token is still valid.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /tokentest?token=token
UserActiveListV2Description: Returns the list of user accounts that are currently in use on the server.Permissions: tshock.rest.users.viewNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/activelist?token=token
UserCreateV2Description: Create a new TShock user account.Permissions: tshock.rest.users.manageNouns:user(Required) \[String] - The user account name for the new account.group(Optional) \[String] - The group the new account should be assigned.password(Required) \[String] - The password for the new account.token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/create?user=user\&group=group\&password=password\&token=token
UserDestroyV2Description: Destroy a TShock user account.Permissions: tshock.rest.users.manageNouns:user(Required) \[String] - The search criteria (name or id of account to lookup).type(Required) \[String] - The search criteria type (name for name lookup, id for id lookup).token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/destroy?user=user\&type=type\&token=token
UserInfoV2Description: List detailed information for a user account.Permissions: tshock.rest.users.viewNouns:user(Required) \[String] - The search criteria (name or id of account to lookup).type(Required) \[String] - The search criteria type (name for name lookup, id for id lookup).token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/read?user=user\&type=type\&token=token
UserListV2Description: Lists all user accounts in the TShock database.Permissions: tshock.rest.users.viewNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/list?token=token
UserUpdateV2Description: Update a users information.Permissions: tshock.rest.users.manageNouns:user(Required) \[String] - The search criteria (name or id of account to lookup).type(Required) \[String] - The search criteria type (name for name lookup, id for id lookup).password(Optional) \[String] - The users new password, and at least this or group must be defined.group(Optional) \[String] - The new group for the user, at least this or password must be defined.token(Required) \[String] - The REST authentication token.Example Usage: /v2/users/update?user=user\&type=type\&password=password\&group=group\&token=token
WorldBloodmoonDescription: Toggle the status of blood moon.Permissions: tshock.rest.causeeventsVerbs:bloodmoon(Required) \[Boolean] - State of bloodmoon.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /world/bloodmoon/{bloodmoon}?token=token
WorldButcherDescription: Butcher npcs.Permissions: tshock.rest.butcherNouns:killfriendly(Optional) \[Boolean] - Should friendly npcs be butchered.token(Required) \[String] - The REST authentication token.Example Usage: /v2/world/butcher?killfriendly=killfriendly\&token=token
WorldMeteorDescription: Drops a meteor on the world.Permissions: tshock.rest.causeeventsNouns:token(Required) \[String] - The REST authentication token.Example Usage: /world/meteor?token=token
WorldReadDescription: Get information regarding the world.No special permissions are required for this route.Nouns:token(Required) \[String] - The REST authentication token.Example Usage: /world/read?token=token
WorldSaveDescription: Save the world.Permissions: tshock.rest.cfgNouns:token(Required) \[String] - The REST authentication token.Example Usage: /v2/world/save?token=token

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/banscreate) <a name="kXLii"></a>

## /bans/create

Create a new ban entry.

gethttp://server-ip:rest-port/bans/create

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/bans/create?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x20; "Ban created successfully"
} <a name="GxCGh"></a>

### QUERY PARAMS

**ip**string
The IP to ban, at least this or name must be specified.
**name**string
The name to ban, at least this or ip must be specified.
**reason**string
The reason to assign to the ban.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2banslist) <a name="FIaUj"></a>

## /v2/bans/list

View all bans in the TShock database.

gethttp://server-ip:rest-port/v2/bans/list

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/bans/list?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)
{
&#x20; "bans": \[
&#x20;   {
&#x20;     "name": "Nicatrontg",
&#x20;     "ip": "192.168.1.31",
&#x20;     "reason": "Banned for cheating in PvP!"
&#x20;   },
&#x20;   {
&#x20;     "name": "Ijwu",
&#x20;     "ip": "192.168.1.36",
&#x20;     "reason": "Banned for winning in PvP!"
&#x20;   }
&#x20; ]
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2bansread) <a name="IGjFj"></a>

## /v2/bans/read

View the details of a specific ban.

gethttp://server-ip:rest-port/v2/bans/read

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/bans/read?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x20; "name": "Nicatrontg",
&#x20; "ip": "192.168.1.31",
&#x20; "reason": "Banned for cheating in PvP!"
} <a name="V7y09"></a>

### QUERY PARAMS

**ban**string
The search criteria, either an IP address or a name.
**type**string
The type of search criteria, 'ip' or 'name'.
**caseinsensitive**boolean
Name lookups should be case insensitive.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2serverbroadcast) <a name="onRKo"></a>

## /v2/server/broadcast

Broadcast a server wide message.

gethttp://server-ip:rest-port/v2/server/broadcast

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/server/broadcast?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"The message was broadcasted successfully"
} <a name="njnLx"></a>

### QUERY PARAMS

**msg**string
The message to broadcast.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v3servermotd) <a name="Y62ce"></a>

## /v3/server/motd

Returns the motd, if it exists.

gethttp://server-ip:rest-port/v3/server/motd

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v3/server/motd?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"motd": "The contents of the message of the day will be here."
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2serveroff) <a name="i3duN"></a>

## /v2/server/off

Turn the server off.

gethttp://server-ip:rest-port/v2/server/off

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/server/off?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"The server is shutting down"
} <a name="mlIml"></a>

### QUERY PARAMS

**confirm**boolean
Required to confirm that actually want to turn the server off.
**message**string
The shutdown message.
**nosave**boolean
Shutdown without saving.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v3serverrawcmd) <a name="hYTYN"></a>

## /v3/server/rawcmd

Executes a remote command on the server, and returns the output of the command.

gethttp://server-ip:rest-port/v3/server/rawcmd

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v3/server/rawcmd?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;-Command Output-
} <a name="xCMXo"></a>

### QUERY PARAMS

**cmd**string
The command and arguments to execute.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v3serverreload) <a name="f9tcC"></a>

## /v3/server/reload

Reload config files for the server.

gethttp://server-ip:rest-port/v3/server/reload

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v3/server/reload?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)
{
&#x9;"Configuration, permissions, and regions reload complete. Some changes may require a server restart."
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v3serverrestart) <a name="proxu"></a>

## /v3/server/restart

Attempt to restart the server.

gethttp://server-ip:rest-port/v3/server/restart

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v3/server/restart?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"The server is shutting down and will attempt to restart"
} <a name="dDFyv"></a>

### QUERY PARAMS

**confirm**boolean
Confirm that you actually want to restart the server
**message**string
The shutdown message.
**nosave**boolean
Shutdown without saving.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v3serverrules) <a name="uz3pV"></a>

## /v3/server/rules

Returns the rules, if they exist.

gethttp://server-ip:rest-port/v3/server/rules

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v3/server/rules?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[500Internal Server Error](https://tshock.readme.io/reference#)
{
&#x9;"rules": "The rules will be here."
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2status) <a name="YIcqj"></a>

## /v2/server/status

The status endpoint returns basic information about the server's status.

gethttp://server-ip:rest-port/v2/server/status

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/server/status?players=false\&rules=false\&token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"name": 'Fizzbuzz',
&#x20; "port": 7777,
&#x20; "playercount": 3,
&#x20; "maxplayers": 13,
&#x20; "world": "Alaenna's Smile",
&#x20; "players": \[
&#x20;   "Alfonse",
&#x20;   "Edward",
&#x20;   "Winry"
&#x20; ],
&#x20; "rules": \[
&#x20;   "AutoSave": true,
&#x20;   "DisableBuild": true
&#x20; ]
} <a name="q3P8m"></a>

### QUERY PARAMS

**players**boolean
Indicates if the response should include the player list.
**rules**boolean
Indicates if the response should include game rules.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/tokentest) <a name="gC2Lq"></a>

## /tokentest

Test if a token is still valid.

gethttp://server-ip:rest-port/tokentest

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/tokentest?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)
{
&#x9;"response": "Token is valid and was passed through correctly.",
&#x20; "associateduser": "myPlayerName"
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2usersactivelist) <a name="TxtXt"></a>

## /v2/users/activelist

Returns the list of user accounts that are currently in use on the server.

gethttp://server-ip:rest-port/v2/users/activelist

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/activelist?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)
{
&#x9;"activeusers": "Bob	Johnny	Victoria"
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2userscreate) <a name="n80VB"></a>

## /v2/users/create

Create a new TShock user account.

gethttp://server-ip:rest-port/v2/users/create

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/create?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x9;"User was successfully created"
} <a name="Kyv9N"></a>

### QUERY PARAMS

**user**string
The user account name for the new account.
**group**string
The group the new account should be assigned.
**password**string
The password for the new account.

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2usersdestroy) <a name="zbQb8"></a>

## /v2/users/destroy

Destroy a TShock user account.

gethttp://server-ip:rest-port/v2/users/destroy

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/destroy?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x20; "User deleted successfully"
} <a name="npS69"></a>

### QUERY PARAMS

**user**string
The search criteria (name or id of account to lookup).
**type**string
The search criteria type (name for name lookup, id for id lookup).

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2userslist) <a name="FUUTb"></a>

## /v2/users/list

Lists all user accounts in the TShock database.

gethttp://server-ip:rest-port/v2/users/list

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/list?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)
{
&#x20; "users": \[
&#x20;   {
&#x20;     "name": "Nicatrontg",
&#x20;     "id": 1,
&#x20;     "group": "superadmin"
&#x20;   },
&#x20;   {
&#x20;     "name": "Ijwu",
&#x20;     "id": 2,
&#x20;     "group": "trustedadmin"
&#x20;   }
&#x20; ]
}

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2usersread) <a name="dcSd8"></a>

## /v2/users/read

List detailed information for a user account.

gethttp://server-ip:rest-port/v2/users/read

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/read?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x20; "group": "superadmin",
&#x20; "id": "1",
&#x20; "name": "Nicatrontg"
} <a name="VrPld"></a>

### QUERY PARAMS

**user**string
The search criteria (name or id of account to lookup).
**type**string
The search criteria type (name for name lookup, id for id lookup).

[SUGGEST EDITS](https://tshock.readme.io/reference-edit/v2usersupdate) <a name="LgUqr"></a>

## /v2/users/update

Update a users information.

gethttp://server-ip:rest-port/v2/users/update

- [cURL](https://tshock.readme.io/reference#)
- [Node](https://tshock.readme.io/reference#)
- [Ruby](https://tshock.readme.io/reference#)
- [JavaScript](https://tshock.readme.io/reference#)
- [Python](https://tshock.readme.io/reference#)

curl --request GET \<br />  --url 'http://server-ip/:rest-port/v2/users/update?token=AlaennaRocksMySocks'
[200OK](https://tshock.readme.io/reference#)[400Bad Request](https://tshock.readme.io/reference#)
{
&#x20; "password-response": "Password updated successfully",
&#x20; "group-response": "Group updated successfully"
} <a name="ccvCy"></a>

### QUERY PARAMS

**user**string
The search criteria (name or id of account to lookup).
**type**string
The search criteria type (name for name lookup, id for id lookup).
**password**string
The users new password, and at least this or group must be defined.
**group**string
The new group for the user, at least this or password must be defined.
