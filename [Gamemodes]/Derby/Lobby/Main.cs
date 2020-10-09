using System.Numerics;
using VenoXV._RootCore_.Models;

namespace VenoXV._Gamemodes_.Derby.Lobby
{
    public class Main
    {
        public static void OnPlayerJoin(VnXPlayer player)
        {
            try { player.SetPosition = new Vector3(-5176.1562f, -7722.7764f, 6.0960693f); }
            catch { }
        }
    }
}
