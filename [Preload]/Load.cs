using AltV.Net;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using static VenoXV._Preload_.Preload;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {

        public static void LoadGamemodeWindows(VnXPlayer player, Gamemodes Gamemode)
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
                    Alt.Server.TriggerClientEvent(player, "Tactics:Load");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, false, false);
                    Alt.Server.TriggerClientEvent(player, "Zombies:CreateHUD", player.Zombies.Zombie_kills);
                    break;
                case Gamemodes.Race:
                    Alt.Server.TriggerClientEvent(player, "Race:Load");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.DERBY1_MAP);
                    break;
            }
        }
        public static void UnloadGamemodeWindows(VnXPlayer player, Gamemodes Gamemode)
        {
            player.Emit("BlipClass:RemoveAllBlips");
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    Alt.Server.TriggerClientEvent(player, "Inventory:Unload");
                    Alt.Server.TriggerClientEvent(player, "XMenu:Unload");
                    Alt.Server.TriggerClientEvent(player, "Phone:Unload");
                    Alt.Server.TriggerClientEvent(player, "Reallife:UnloadHUD");
                    Alt.Server.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    Alt.Server.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    break;
                case Gamemodes.Tactics:
                    Alt.Server.TriggerClientEvent(player, "Tactics:Unload");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
                    Alt.Server.TriggerClientEvent(player, "Zombies:DestroyHUD");
                    Alt.Server.TriggerClientEvent(player, "Zombies:OnGamemodeDisconnect");
                    break;
                case Gamemodes.Race:
                    Alt.Server.TriggerClientEvent(player, "Race:Unload");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                    _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.DERBY1_MAP);
                    break;
            }
        }

    }
}
