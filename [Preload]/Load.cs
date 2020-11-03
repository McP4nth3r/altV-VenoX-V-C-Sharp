using AltV.Net;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV._RootCore_.Sync;
using static VenoXV._Preload_.Preload;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {

        public static void LoadGamemodeWindows(VnXPlayer player, Gamemodes Gamemode)
        {
            Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    Loading.Main.LoadReallifeMaps(player);
                    _Maps_.Main.LoadMap(player, _Maps_.Main.BUSSTATION_MAP);
                    VenoX.TriggerClientEvent(player, "Inventory:Load");
                    VenoX.TriggerClientEvent(player, "XMenu:Load");
                    VenoX.TriggerClientEvent(player, "Phone:Load");
                    VenoX.TriggerClientEvent(player, "Reallife:LoadHUD", player.Reallife.HUD);
                    Sync.LoadAllNPCs(player);
                    break;
                case Gamemodes.Tactics:
                    VenoX.TriggerClientEvent(player, "Tactics:Load");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, false, false);
                    VenoX.TriggerClientEvent(player, "Zombies:CreateHUD", player.Zombies.Zombie_kills);
                    break;
                case Gamemodes.Race:
                    VenoX.TriggerClientEvent(player, "Race:Load");
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
            VenoX.TriggerClientEvent(player, "BlipClass:RemoveAllBlips");
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    Loading.Main.UnloadReallifeMaps(player);
                    VenoX.TriggerClientEvent(player, "Inventory:Unload");
                    VenoX.TriggerClientEvent(player, "XMenu:Unload");
                    VenoX.TriggerClientEvent(player, "Phone:Unload");
                    VenoX.TriggerClientEvent(player, "Reallife:UnloadHUD");
                    VenoX.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    VenoX.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    break;
                case Gamemodes.Tactics:
                    VenoX.TriggerClientEvent(player, "Tactics:Unload");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
                    VenoX.TriggerClientEvent(player, "Zombies:DestroyHUD");
                    VenoX.TriggerClientEvent(player, "Zombies:OnGamemodeDisconnect");
                    break;
                case Gamemodes.Race:
                    VenoX.TriggerClientEvent(player, "Race:Unload");
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
