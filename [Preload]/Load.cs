using AltV.Net;
using VenoXV._RootCore_.Models;
using static VenoXV._Preload_.Preload;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {

        public static void LoadGamemodeWindows(Client player, Gamemodes Gamemode)
        {
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    player.Emit("Inventory:Load");
                    player.Emit("XMenu:Load");
                    player.Emit("Phone:Load");
                    break;
                case Gamemodes.Tactics:
                    break;
                case Gamemodes.Zombies:
                    //Test
                    break;
                case Gamemodes.SevenTowers:
                    break;
            }
        }
        public static void UnloadGamemodeWindows(Client player, Gamemodes Gamemode)
        {
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    player.Emit("Inventory:Unload");
                    player.Emit("XMenu:Unload");
                    player.Emit("Phone:Unload");
                    break;
                case Gamemodes.Tactics:
                    break;
                case Gamemodes.Zombies:
                    break;
                case Gamemodes.SevenTowers:
                    break;
            }
        }
    }
}
