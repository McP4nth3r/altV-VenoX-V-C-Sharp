using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Reallife.premium.vnxcase
{
    public class VenoXCases : IScript
    {
        IColShape col = Alt.CreateColShapeSphere(new Position(-311.2075f, -278.3156f, 31.5f), 3f);
        public static void OnResourceStart()
        {
            /*Blip AmmunationBlip = NAPI.Blip.CreateBlip(new Position(-311.2075f, -278.3156f, 31.5f));
            AmmunationBlip.Name = "VIP Area";
            AmmunationBlip.Sprite = 304;
            AmmunationBlip.Rgba = 46;*/
        }

        /*[Command("gotovipshop")]
        public void blabla(IPlayer player)
        {
            Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
            player.Position = new Position(-311.2075f, -278.3156f, 31.5f);
        }*/

        /*//[ServerEvent(Event.PlayerEnterIColShape)]
        public void OnPlayerEnterIColShape(IColShape shape, IPlayer player)
        {
            if (shape == col)
            {
                //player.Emit("CreateCaseWindow");
                //player.SendChatMessage("Funktion Aufgerufen!");
            }
        }*/
    }
}
