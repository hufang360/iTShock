---
title: Command Line Parameters
url: https://www.yuque.com/hufang/tmp/ts-command-line-parameters
---

原始网址：<https://tshock.readme.io/docs/command-line-parameters>

The following parameters can be added to TShock to alter the way a server initializes. Options set via the command line will override all configuration options regardless. These can be used either for personal use or in a GSP environment for easier hosting without hassle:
Terraria Server API Command Line:

- -ip - Starts the server bound to a given IPv4 address
- -port - Starts the server bound to a given port
- -maxplayers - Starts the server with a given player count
- -world \<file.wld> - Starts the server and immediately loads a given world file
- -worldpath - Starts the server and changes the world path to a given path
- -autocreate <1/2/3> - Starts the server and, if a world file isn't found, automatically create the world file with a given size, 1-3, 1 being small.
- -config - Starts the server with a given config file
- -connperip - Allows n number of connections per IP.
- -killinactivesocket - Kills connections which have not started the protocol handshake.
- -lang - Sets the server's language.
- -ignoreversion - Ignores API version checks for plugins allowing for old plugins to run.
- -forceupdate - Forces the server to continue running, and not hibernating when no players are on. This results in time passing, grass growing, and cpu running.
- \--stats-optout - Prevents the server from reporting stats to the TShock server. View stats [here](http://stats.tshock.co/).

TShock Command Line:

- -configpath - The path tshock uses to resolve configs, log files, and sqlite db.
- -worldpath - The path that Terraria Server uses to find all world files.
- -logpath - Overrides the default log path and saves logs here.
- -logformat - Format the name of log files, [subject to C# date standard abbreviations](https://msdn.microsoft.com/en-us/library/8kb3ddd4%28v=vs.110%29.aspx).
- -logclear \<true/false> - Overwrites old config if it exists.
- -dump - Dumps permissions and config file descriptions for wiki use.
  | Example usage: |
  | --- |
  | TerrariaServer.exe -ip 127.0.0.1 -port 7777 -maxplayers 16 -world
  "C:\Users\Shank\Documents\My Games\Terraria\Worlds\world1.wld" |
