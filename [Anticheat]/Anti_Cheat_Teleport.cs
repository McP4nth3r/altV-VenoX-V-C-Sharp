using AltV.Net;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Anti_Cheat
{
    public class Anti_Cheat_Teleport : IScript
    {


        //[AltV.Net.ClientEvent("Anticheat_Server_Teleport")]
        public static void Ban_Player_TeleportCheat(Client player)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x004";
                    //Database.UpdatePlayerTimeBan(player.SocialClubId.ToString(), DateTime.Now.AddDays(7), "[ANTI-CHEAT] # " + Banhash);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(255, 0, 0) + player.Username + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Teleport # " + Banhash);
                }
            }
            catch { }
        }

        //[AltV.Net.ClientEvent("Anticheat_Server_Speed")]
        public static void Ban_Player_SpeedCheat(Client player, int distanz, string position_now, string position_last)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x005";
                    //Database.UpdatePlayerTimeBan(player.SocialClubId.ToString(), DateTime.Now.AddDays(7), "[ANTI-CHEAT] # " + Banhash);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(255, 0, 0) + player.Username + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Speedhack # " + Banhash);
                    logfile.WriteAntiCheatLogs("speed", "[ANTI-CHEAT][0x005] : " + player.Username + " | Distanz : " + distanz + " | Position Now : " + position_now + " | Position Last : " + position_last);
                }
            }
            catch { }
        }
    }
}
