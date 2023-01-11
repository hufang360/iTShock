using System;
using System.IO;
using System.Reflection;
using System.Text;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace Plugin
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {

        public override string Description => "Boss战期间和护士对话，护士会消失";
        public override string Name => "Boss还是护士";
        public override string Author => "hufang360";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;


        public Plugin(Main game) : base(game)
        {
        }


        public override void Initialize()
        {
            ServerApi.Hooks.NetGetData.Register(this, OnGetData, 1);
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        void OnGetData(GetDataEventArgs args)
        {
            switch (args.MsgID)
            {
                case PacketTypes.NpcTalk:
                    using (MemoryStream ms = new(args.Msg.readBuffer, args.Index, args.Length))
                    using (BinaryReader br = new(ms, Encoding.UTF8, true))
                    {
                        int playerID = br.ReadByte();
                        int npcTalkTarget = br.ReadInt16();
                        if (npcTalkTarget == -1)
                            return;

                        // 是否是护士
                        NPC npc = Main.npc[npcTalkTarget];
                        if (npc.netID != 18)
                            return;

                        // 是否是boss战期间
                        bool flag = false;
                        for (int i = 0; i < 200; i++)
                        {
                            if (!Main.npc[i].active || !Main.npc[i].boss)
                            {
                                continue;
                            }

                            // 四柱
                            switch (Main.npc[i].type)
                            {
                                case 422:
                                case 493:
                                case 507:
                                case 517:
                                    continue;
                            }
                            flag = true;
                            break;
                        }
                        if (flag)
                        {
                            ClearNPCByID(npc.netID);
                            TSPlayer.All.SendInfoMessage($"[i:{3544}]{npc.TypeName}已离开！");
                            args.Handled = true;
                        }
                    }
                    break;
            }
        }
        
        /// <summary>
        /// 通过npcid清理npc
        /// </summary>
        static int ClearNPCByID(int npcID)
        {
            int cleared = 0;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].netID == npcID)
                {
                    Main.npc[i].active = false;
                    Main.npc[i].type = 0;
                    TSPlayer.All.SendData(PacketTypes.NpcUpdate, "", i);
                    cleared++;
                }
            }
            return cleared;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.NetGetData.Deregister(this, OnGetData);
            }
            base.Dispose(disposing);
        }

    }
}
