---
title: Hello, World!
url: https://www.yuque.com/hufang/tmp/ts-hello-world
---

原文：<https://tshock.readme.io/docs/hello-world>

***

This guide will show you how to get up and running with plugin development as fast as possible. <a name="dKFIm"></a>

## Introduction

Requirements:

- You **must** have the [.NET framework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=30653) installed
- You **must** have a copy of *TerrariaServer.exe*, *TShockAPI.dll*, and *OTAPI.dll*.
- You **must** have some IDE installed, eg [Visual Studio](https://www.visualstudio.com/vs/visual-studio-express/). <a name="GiCJu"></a>

## Creating a skeleton project

Open Visual Studio, or your IDE of choice. Create a project, using a class library as the base, and naming it something sensible.
![](..\assets\ts-hello-world\1652664393633-92ae3b2c-c959-4a7c-a0a6-7809e0afec74.png)![](..\assets\ts-hello-world\1652664393673-3c2a9642-e97f-4455-859d-0a608149b89e.png)
Next, refactor Class1.cs into something logical as well. Insert the following skeleton code:

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
        /// <summary>
        /// Gets the author(s) of this plugin
        /// </summary>
        public override string Author => "Anonymous";
        
        /// <summary>
        /// Gets the description of this plugin.
        /// A short, one lined description that tells people what your plugin does.
        /// </summary>
        public override string Description => "A sample test plugin";
      
        /// <summary>
        /// Gets the name of this plugin.
        /// </summary>
        public override string Name => "Test Plugin";
      
        /// <summary>
        /// Gets the version of this plugin.
        /// </summary>
        public override Version Version => new Version(1, 0, 0, 0);
      
        /// <summary>
        /// Initializes a new instance of the TestPlugin class.
        /// This is where you set the plugin's order and perfrom other constructor logic
        /// </summary>
        public TestPlugin(Main game) : base(game)
        {
            
        }
        
        /// <summary>
        /// Handles plugin initialization. 
        /// Fired when the server is started and the plugin is being loaded.
        /// You may register hooks, perform loading procedures etc here.
        /// </summary>
        public override void Initialize()
        {
            
        }
      
        /// <summary>
        /// Handles plugin disposal logic.
        /// *Supposed* to fire when the server shuts down.
        /// You should deregister hooks and free all resources here.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Deregister hooks here
            }
            base.Dispose(disposing);
        }
    }
}
```

Essentials to remember are:

- You **must** extend ***TerrariaPlugin***
- You must have a name, author, description, and plugin version
- You **must** support *the same version of the API* that you're developing for <a name="lH1s6"></a>

## Don't forget to reference!

Now that you have some code, Visual Studio will be yelling at you because it has no idea where to look for the code. Add references appropriately, and your code should be error free and compile fine.
![](..\assets\ts-hello-world\1652664395601-72067b9b-5f37-4438-848c-250cc2de5c51.png)![](..\assets\ts-hello-world\1652664393357-ea3df11c-3724-42ed-b27b-7ce2da271d18.png)
When completed, your references should look something like this:
![](..\assets\ts-hello-world\1652664393591-23809211-9fdc-4593-b15c-3ed38c5a3cc4.png)![](..\assets\ts-hello-world\1652664395628-63399686-2a3d-4801-ab92-17da5a3d509d.png) <a name="kU2mP"></a>

## Testing your plugin

At this point, you should be able to tap F6 and your code will compile without error. Assuming you're compiling in debug mode, your dll will be in the bin/debug/ directory in the same directory that your solution resides. Drop this in the ServerPlugins folder, run the server, and you should see your plugin loading at the top.
