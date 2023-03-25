---
title: A List Of Tutorial Repositories
url: https://www.yuque.com/hufang/tmp/ts-a-list-of-tutorial-repositories
---

原文：<https://tshock.readme.io/docs/a-list-of-tutorial-repositories>

***

Please note that our tutorials are rather basic and cover only a fraction of the functionality that both .NET and our libraries provide. Because we require all plugins to be open source, one of the best ways to learn how to do something is to check out [other people's plugins](https://tshock.co/xf/index.php?resources/).
Most of the documentation of these tutorials is in their respective repositories.
All of our tutorials are hosted on [Github](https://github.com/), and we strongly recommend you use [Git](https://www.git-scm.com/) in conjunction with Github to host your plugins too.
TShock uses the **.NET Framework version 4.5**. If you wish to write plugins you **must** have:

- An operating system that can run .**NET 4.5**
- A C# compiler that supports .NET 4.5
  OR
- An operating system that can run **Mono 4.x**
- A C# compiler that supports Mono 4.x

For development on Windows devices, we recommend using [Microsoft Visual Studio Community 2015](https://www.microsoft.com/en-us/download/details.aspx?id=48146). <a name="DlaiV"></a>

## Plugin Tutorial List:

**Tutorial 1** - Seeing what a plugin looks like:
This repository contains a simple plugin template with all the necessary parts that allow a plugin to be loaded and run by our API.
You can find the repository [here](https://github.com/TShockResources/PluginTemplate).*
**Tutorial 2** - Using Hooks:
Hooks are hugely important part of our plugins - they are used to get and/or set data sent from all sorts of sources.
The following tutorial makes use of the ServerChat hook to simply echo all in-game chat to the server console.
You can find the repository [here](https://github.com/TShockResources/ServerHooksExample).*
**Tutorial 3** - Chat Censor:
This tutorial is one that actually does something useful: a chat censor.
The tutorial makes use of the ServerChat hook to filter out a hard-coded list of bad words.
Furthermore it provides an example of loading a list of strings from a text file, as well as an example of how to use the TShock Reload hook.
You can find the repository [here](https://github.com/TShockResources/ChatCensor).*
**Tutorial 4** - Lava Sucks:
Lava sucks uses the NetGetData hook to remove the lava produced when hellstone is mined.
This tutorial will teach you how to add commands that can be used in-game, as well as how to use the NetGetData hook.
You can find the repository [here](https://github.com/TShockResources/LavaSucks).*

- Please note that the binaries provided with the tutorials are not necessarily the most recent. It is highly likely you will need to download the [latest version of TShock](https://github.com/NyxStudios/TShock/releases/tag/v4.3.20) and reference those binaries, rather than the ones provided.
