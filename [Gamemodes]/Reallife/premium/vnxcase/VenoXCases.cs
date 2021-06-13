using System.Numerics;
using AltV.Net;
using AltV.Net.Data;
using VenoXV.Core;
using VenoXV.Models;

namespace VenoXV._Gamemodes_.Reallife.premium.vnxcase
{
    public class VenoXCases : IScript
    {
        ColShapeModel _col = RageApi.CreateColShapeSphere(new Position(-311.2075f, -278.3156f, 31.5f), 3f);
        public static void OnResourceStart()
        {
            RageApi.CreateBlip("VIP Area", new Vector3(-311.2075f, -278.3156f, 31.5f), 304, 46, false);
        }

        /*[Command("gotovipshop")]
        public void blabla(PlayerModel player)
        {
            //Anti_Cheat.//AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
            player.position = new Position(-311.2075f, -278.3156f, 31.5f);
        }*/

        /*//[ServerEvent(Event.PlayerEnterColShapeModel)]
        public void OnPlayerEnterColShapeModel(ColShapeModel shape, PlayerModel player)
        {
            if (shape == col)
            {
                //VenoX.TriggerClientEvent(player,"CreateCaseWindow");
                //player.SendTranslatedChatMessage("Funktion Aufgerufen!");
            }
        }*/
    }
}
