using AltV.Net.Data;
using VenoXV._Gamemodes_.Reallife.model;

namespace VenoXV._Gamemodes_.Reallife.Club
{
    public class RussianClub
    {
        public static void OnResourceStart()
        {
            Core.RageAPI.CreateTextLabel("HARDBASS BLYATT!!!!!", new Position(-1388.0013f, -618.41967f, 30.819599f), 10.0f, 0.5f, 4, new int[] { 255, 255, 255, 255 });

            BlipModel blip = new BlipModel
            {
                Name = "Cyka Moscow",
                posX = -1388.0013f,
                posY = -618.41967f,
                posZ = 30.819599f,
                Sprite = 679,
                Color = 63,
                ShortRange = false
            };
            VenoXV.Globals.Functions.BlipList.Add(blip);
        }
    }
}
