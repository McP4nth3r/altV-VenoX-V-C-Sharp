using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.premium.vnxcase
{
    public class VenoXCases : IScript
    {
        IColShape col = Alt.CreateColShapeSphere(new Position(-311.2075f, -278.3156f, 31.5f), 3f);
        public static void OnResourceStart()
        {
            BlipModel blip = new BlipModel();
            Position pos = new Position(-311.2075f, -278.3156f, 31.5f);
            blip.Name = "VIP Area";
            blip.posX = pos.X;
            blip.posY = pos.Y;
            blip.posZ = pos.Z;
            blip.Sprite = 304;
            blip.Color = 46;
            blip.ShortRange = true;
            VenoXV.Globals.Functions.BlipList.Add(blip);
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
