using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace Plugin
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {

        public override string Description => "";
        public override string Name => "hfToy-射弹发射器";
        public override string Author => "hufang360";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;


        public Plugin(Main game) : base(game)
        {
        }

        /// <summary>
        /// 初始时
        /// </summary>
        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("hf.toy.projectile", PCommand, "pj", "射弹") { HelpText = "射弹发射器", AllowServer=false });
        }

        /// <summary>
        /// 销毁时
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 处理指令
        /// </summary>
        void PCommand(CommandArgs args)
        {
            TSPlayer op = args.Player;

            if (args.Parameters.Count == 0)
            {
                op.SendErrorMessage("请输入射弹id，例如 /pj 1013");
                return;
            }

            if (int.TryParse(args.Parameters[0], out int projID))
            {
                if (projID > 1021 || projID <= 0)
                    projID = 1013;
            }
            else
            {
                projID = 1013;
            }

            int total = 40;
            if (args.Parameters.Count > 1 && int.TryParse(args.Parameters[1], out total))
            {
                if (total >= 800 || total < 1)
                    total = 40;
            }

            Vector2 pos;
            Vector2 vel;
            int pIndex;
            for (int i = 0; i < total; i++)
            {
                // 1013 弹力巨石
                // 1021 月亮巨石
                pos = new(op.TPlayer.position.X + (60 - i * 3) * 16, op.TPlayer.position.Y - 16 * (Main.rand.Next(10, 50)));
                vel = new(Main.rand.Next(-10, 10), Main.rand.Next(2, 20));
                pIndex = Projectile.NewProjectile(Projectile.GetNoneSource(), pos, vel, projID, 0, 0f);
                NetMessage.SendData(27, -1, -1, null, pIndex);
            }
        }


    }
}
