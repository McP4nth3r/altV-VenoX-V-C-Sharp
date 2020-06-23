using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
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
                    Alt.Server.TriggerClientEvent(player, "Inventory:Load");
                    Alt.Server.TriggerClientEvent(player, "XMenu:Load");
                    Alt.Server.TriggerClientEvent(player, "Phone:Load");
                    Alt.Server.TriggerClientEvent(player, "Reallife:LoadHUD", player.Reallife.HUD);
                    Sync.LoadAllNPCs(player);
                    break;
                case Gamemodes.Tactics:
                    break;
                case Gamemodes.Zombies:
                    //Test
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                    break;
            }
        }
        public static void UnloadGamemodeWindows(Client player, Gamemodes Gamemode)
        {
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    Alt.Server.TriggerClientEvent(player, "Inventory:Unload");
                    Alt.Server.TriggerClientEvent(player, "XMenu:Unload");
                    Alt.Server.TriggerClientEvent(player, "Phone:Unload");
                    Alt.Server.TriggerClientEvent(player, "Reallife:UnloadHUD");
                    break;
                case Gamemodes.Tactics:
                    break;
                case Gamemodes.Zombies:
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                    break;
            }
        }
    }
}
