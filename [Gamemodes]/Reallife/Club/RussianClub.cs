using AltV.Net.Data;
using System.Numerics;

namespace VenoXV._Gamemodes_.Reallife.Club
{
    public class RussianClub
    {
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateTextLabel("HARDBASS BLYATT!!!!!", new Position(-1388.0013f, -618.41967f, 30.819599f), 10.0f, 0.5f, 4, new int[] { 255, 255, 255, 255 });
            Core.RageAPI.CreateBlip("Cyka Moscow", new Vector3(-1388.0013f, -618.41967f, 30.819599f), 679, 63, false);
        }
    }
}
