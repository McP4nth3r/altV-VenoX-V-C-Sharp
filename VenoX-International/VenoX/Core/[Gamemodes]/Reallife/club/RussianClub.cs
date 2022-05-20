using System.Numerics;
using AltV.Net.Data;
using VenoX.Core._RootCore_;

namespace VenoX.Core._Gamemodes_.Reallife.club
{
    public class RussianClub
    {
        public static void OnResourceStart()
        {
            RageApi.CreateTextLabel("HARDBASS BLYATT!!!!!", new Position(-1388.0013f, -618.41967f, 30.819599f), 10.0f, 0.5f, 4, new[] { 255, 255, 255, 255 });
            RageApi.CreateBlip("Cyka Moscow", new Vector3(-1388.0013f, -618.41967f, 30.819599f), 679, 63, false);
        }
    }
}
