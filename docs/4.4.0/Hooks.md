---
title: Hooks
url: https://www.yuque.com/hufang/tmp/ts-hooks
---

原文链接：<https://tshock.readme.io/docs/hooks>

***

TerrariaServerAPI and TShock both carry numerous hooks that will make the development of C# plugins much easier and hassle free. These hooks differ, however. TShock provides **packet implementation hooks** that expose all packet data without requiring developers to read packets themselves, whereas TSAPI comes with a bunch of handy hooks such as *ServerChat*, *NPCLoot*, *NpcStrike* and more. <a name="IsNRl"></a>

## Adding a Hook

The implementation itself is fairly easy. Assuming you are already familiar with the basic plugin structure we'll now hook onto TSAPI's ServerChat and TShock's PlayerInfo hook. In case you did not read the [Hello, World!](https://tshock.readme.io/docs/hello-world) documentation you should go read that and then come back.

```json
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;

namespace TestPlugin
{
    [ApiVersion(2, 1)]
    public class TestPlugin : TerrariaPlugin
    {
        public override string Author => "Anonymous";
        
        public override string Description => "An example on using hooks provided by the API";
      
        public override string Name => "Hook Test";
      
        public override Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }
      
        public TestPlugin(Main game) : base(game)
        {
            
        }
        
        public override void Initialize()
        {
            // All hooks provided by TSAPI are a part of the _ServerApi_ namespace.
            // This example will show you how to use the ServerChat hook which is 
            // fired whenever a client sends a message to the server.
            // In order to register the hook you need to pass in the class that 
            // is registering the hook and it's callback function (OnServerChat)
            // By passing a reference to the `OnServerChat` method you are able to
            // execute code whenever a message is sent to the server.
            ServerApi.Hooks.ServerChat.Register(this, OnServerChat);
          
            // This is an example of subscribing to TShock's TogglePvP event.
            // This event is a part of the `GetDataHandlers` class.
            // All events located within this class are _packet implementation_ hooks.
            // These hooks will come in handy when dealing with packets
            // because they provide the packet's full structure, saving you from
            // reading the packet data yourself.
            TShockAPI.TShock.GetDataHandlers.TogglePvp += OnTogglePvp;
        }
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // As mentioned in the Hello, World! tutorial you should always 
                // deregister your hooks during the disposal process.
                ServerApi.Hooks.ServerChat.Deregister(this, OnServerChat);
                TShockAPI.TShock.GetdataHandlers.TogglePvP -= OnTogglePvP;
            }
            base.Dispose(disposing);
        }
      
        // This is the ServerChat's callback function; this function is called
        // whenever the ServerChat hook is fired, which is upon receiving a message
        // from the client.
        // This example acts as a debug and outputs the message to the console.
        void OnServerChat(ServerChatEventArgs args)
        {
            Console.WriteLine("DEBUG: {0}", args.Text);
        }
        
        // This is the TogglePvp handler. This function is called whenever the server
        // receives packet #30 (TogglePvP)
        void OnTogglePvp(object sender, 
                TShockAPI.GetDataHandlers.TogglePvpEventArgs args)
        {
            Console.WriteLine("{0} has just {1} their Pvp Status",
                TShock.Players[args.PlayerId].Name, args.Pvp ? "enabled" : "disabled");
        }
```

The two notable differences are:

```json
ServerApi.Hooks.ServerChat.Register(this, OnServerChat);
```

```json
TShockAPI.GetDataHandlers.TogglePvp += OnTogglePvp;
```

```json
void OnServerChat(ServerChatEventArgs args)
{
    
}
```

```json
void TogglePvp(object sender, TShockAPI.GetDataHandlers.TogglePvpEventArgs args)
{
  
}
```

**Things to remember:**

- Subscribing to TSAPI hooks is done by using .Register method, whereas subscribing to TShock's hooks does not differ from the regular syntax.
- The hook registrator (the plugin's main class) **must** inherit the *TerrariaPlugin* class.
- TShock's GetDataHandler hooks require you to pass in the object sender, whereas TSAPI only asks you to pass in the hook's arguments. <a name="GYk5B"></a>

## Hook: PlayerInfo

Description: When a player joins, the player sends it's information to the server.

```json
public class PlayerInfoEventArgs : HandledEventArgs
{
    public int playerid { get; set; }
    public int hair { get; set; }
    public int male { get; set; }
    public int difficulty { get; set; }
    public string name { get; set; }
}
```

```json
GetDataHandlers.PlayerInfo += PlayerInfo;
void PlayerInfo(object sender, TShockAPI.GetDataHandlers.PlayerInfoEventArgs args)
{
    Console.WriteLine(args.name + " just called a PlayerInfo event.");
    Console.WriteLine(args.name + " has " + args.hair + " hair!");
}
```

<a name="CGXYn"></a>

## Hook: TileEdit

Description: When a tile is edited, TShock calls this hook.

```json
public class TileEdit : HandledEventArgs
{
            public int X { get; set; }
            public int Y { get; set; }
            public byte Type { get; set; }
            public byte EditType { get; set; }
}
```

```json
GetDataHandlers.TileEdit += TileEdit;
void TileEdit(object sender, TShockAPI.GetDataHandlers.TileEditEventArgs args)
{
    Console.WriteLine("TileEdit at :" + args.X + "," + args.Y);
}
```

Notes:

- Type = The type of tile edited
- EditType
- KillTile = 0
- PlaceTile = 1
- KillWall = 2
- PlaceWall = 3
- KillTileNoItem = 4
- PlaceWire = 5
- KillWire = 6
- PoundTile = 7
- PlaceActuator = 8
- KillActuator = 9
- PlaceWire2 = 10
- KillWire2 = 11
- PlaceWire3 = 12
- KillWire3 = 13
- SlopeTile = 14
- FrameTrack = 15
- PlaceWire4 = 16
- KillWire4 = 17
- PokeLogicGate = 18
- Actuate = 19 <a name="cjGaR"></a>

## Hook: TogglePvp

Description: When a player toggles PVP, this hook is called.

```json
public class TogglePvpEventArgs : HandledEventArgs
{
    public byte PlayerId { get; set; }
    public bool Pvp { get; set; }
}
```

```json
GetDataHandlers.TogglePvp += TogglePvp;
void TogglePvp(object sender, TShockAPI.GetDataHandlers.TogglePvpEventArgs args)
{
    Console.WriteLine(args.PlayerId + " just set pvp to " + args.Pvp);
}
```

Notes:

- PlayerId = Terraria player index
