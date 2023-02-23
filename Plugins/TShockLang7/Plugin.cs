using System;
using System.Reflection;
using Terraria;
using Terraria.Localization;
using TerrariaApi.Server;

namespace Lang7;

[ApiVersion(2, 1)]
public class Plugin : TerrariaPlugin
{
    public override string Name => "Lang7";
    public override string Author => "hufang360";
    public override string Description => "将服务器语言设置成中文";
    public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

    public Plugin(Main game) : base(game)
    {
    }

    public override void Initialize()
    {
        LanguageManager.Instance.SetLanguage(7);
    }
}
