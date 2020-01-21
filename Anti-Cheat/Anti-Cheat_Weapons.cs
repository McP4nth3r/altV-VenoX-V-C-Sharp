using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.vnx_stored_files;

namespace VenoXV.Anti_Cheat
{
    public class Anti_Cheat_Weapons : IScript
    {
        public const string ANTICHEAT_HAMMER_HASH = "-0x003";
        public const string ANTICHEAT_VINTAGEPISTOL_HASH = "-0x002";
        public const string ANTICHEAT_BOTTLE_HASH = "-0x001";
        public const string ANTICHEAT_SNOWBALL_HASH = "0x000";
        public const string ANTICHEAT_PISTOL_HASH = "0x001";
        public const string ANTICHEAT_PISTOL50_HASH = "0x002";
        public const string ANTICHEAT_REVOLVER_HASH = "0x003";
        public const string ANTICHEAT_PDW_HASH = "0x004";
        public const string ANTICHEAT_KARABINER_HASH = "0x005";
        public const string ANTICHEAT_ADVANCED_HASH = "0x006";
        public const string ANTICHEAT_SNIPER_HASH = "0x007";
        public const string ANTICHEAT_SHOTGUN_HASH = "0x008";
        public const string ANTICHEAT_TAZER_HASH = "0x009";
        public const string ANTICHEAT_NIGHTSTICK_HASH = "0x0010";
        public const string ANTICHEAT_KNIFE_HASH = "0x0011";
        public const string ANTICHEAT_BASEBALL_HASH = "0x0012";
        public const string ANTICHEAT_RIFLE_HASH = "0x0013";
        public const string ANTICHEAT_RPG_HASH = "0x0014";
        public const string ANTICHEAT_AK47_HASH = "0x0015";
        public const string ANTICHEAT_MP5_HASH = "0x0016";
        public const string ANTICHEAT_MINISMG_HASH = "0x0017";
        public static void anticheat_permanent_ban(IPlayer player, string Banhash)
        {
            try
            {
                if (Banhash != "0")
                {
                    if (player.Health != 0)
                    {
                        logfile.WriteAntiCheatLogs("weapon", "[ANTI-CHEAT][" + Banhash + "] : " +player.Name + " |Position Now : " + player.Position + " | Currentweapon : " + player.CurrentWeapon);
                        Database.AddPlayerPermaBan(player.vnxGetElementData<int>(EntityData.PLAYER_SQL_ID), player.SocialClubId.ToString(), player.HardwareIdHash.ToString(), Banhash, "ANTI_CHEAT_" + Banhash);
                        Reallife.Core.RageAPI.SendChatMessageToAll("!{255,0,0}" +player.Name + " wurde von [VenoX Anti-Cheat Shield] Permanent gebannt! Grund : # " + Banhash);
                        player.Kick("~r~Grund : " + " [ANTI-CHEAT] Weapon # " + Banhash);
                    }
                }
            }
            catch { }
        }
    }
}
