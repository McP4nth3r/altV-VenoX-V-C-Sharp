using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV.Anti_Cheat
{
    public class Anti_Cheat_Health : IScript
    {

        //[AltV.Net.ClientEvent("Anticheat_Server_Health")]
        public static void Ban_Player_HealthCheat(Client player)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x0139";
                    //AntiCheat_Allround.Anticheat_time_ban(player, 2, Banhash);
                    RageAPI.SendTranslatedChatMessageToAll(RageAPI.GetHexColorcode(255, 0, 0) + player.Username + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Weapon # " + Banhash);
                }
            }
            catch { }
        }
    }
}
