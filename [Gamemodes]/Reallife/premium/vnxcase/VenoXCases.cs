using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System.Numerics;

namespace VenoXV._Gamemodes_.Reallife.premium.vnxcase
{
    public class VenoXCases : IScript
    {
        IColShape col = Alt.CreateColShapeSphere(new Position(-311.2075f, -278.3156f, 31.5f), 3f);
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateBlip("VIP Area", new Vector3(-311.2075f, -278.3156f, 31.5f), 304, 46, false);
        }

        /*[Command("gotovipshop")]
        public void blabla(PlayerModel player)
        {
            Anti_Cheat.AntiCheat_Allround.SetTimeOutTeleport(player, 10000);
            player.position = new Position(-311.2075f, -278.3156f, 31.5f);
        }*/

        /*//[ServerEvent(Event.PlayerEnterIColShape)]
        public void OnPlayerEnterIColShape(IColShape shape, PlayerModel player)
        {
            if (shape == col)
            {
                //player.Emit("CreateCaseWindow");
                //player.SendTranslatedChatMessage("Funktion Aufgerufen!");
            }
        }*/
    }
}
