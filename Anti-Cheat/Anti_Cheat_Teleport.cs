using AltV.Net;
using AltV.Net.Elements.Entities;
using VenoXV.Core;
using VenoXV.Reallife.vnx_stored_files;

namespace VenoXV.Anti_Cheat
{
    public class Anti_Cheat_Teleport : IScript
    {


        //[AltV.Net.ClientEvent("Anticheat_Server_Teleport")]
        public static void Ban_Player_TeleportCheat(IPlayer player)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x004";
                    //Database.UpdatePlayerTimeBan(player.SocialClubId.ToString(), DateTime.Now.AddDays(7), "[ANTI-CHEAT] # " + Banhash);
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(255,0,0) +player.GetVnXName<string>() + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Teleport # " + Banhash);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Anticheat_Server_Speed")]
        public static void Ban_Player_SpeedCheat(IPlayer player, int distanz, string position_now, string position_last)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x005";
                    //Database.UpdatePlayerTimeBan(player.SocialClubId.ToString(), DateTime.Now.AddDays(7), "[ANTI-CHEAT] # " + Banhash);
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(255,0,0) +player.GetVnXName<string>() + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Speedhack # " + Banhash);
                    logfile.WriteAntiCheatLogs("speed", "[ANTI-CHEAT][0x005] : " +player.GetVnXName<string>() + " | Distanz : " + distanz + " | Position Now : " + position_now + " | Position Last : " + position_last);
                }
            }
            catch { }
        }
    }
}
