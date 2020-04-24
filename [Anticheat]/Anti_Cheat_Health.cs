using AltV.Net;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Core;
using VenoXV._Gamemodes_.Reallife.vnx_stored_files;

namespace VenoXV.Anti_Cheat
{
    public class Anti_Cheat_Health : IScript
    {

        //[AltV.Net.ClientEvent("Anticheat_Server_Health")]
        public static void Ban_Player_HealthCheat(IPlayer player)
        {
            try
            {
                if (player.Health != 0)
                {
                    string Banhash = "0x0139";
                    //AntiCheat_Allround.Anticheat_time_ban(player, 2, Banhash);
                    RageAPI.SendChatMessageToAll(RageAPI.GetHexColorcode(255,0,0) + player.GetVnXName() + " wurde von [VenoX Anti-Cheat Shield] gekickt! Grund : # " + Banhash);
                    player.Kick("~r~Grund : " + " [ANTI-CHEAT] Weapon # " + Banhash);
                }
            }
            catch { }
        }
    }
}
