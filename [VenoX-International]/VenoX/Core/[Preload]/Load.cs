using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using VenoXV._Gamemodes_.Zombie.Assets;
using VenoXV._Preload_.Loading;
using VenoXV._RootCore_.Sync;
using VenoXV.Models;
using static VenoXV._Preload_.Preload;

namespace VenoXV
{
    public class Load : IScript
    {

        public static void LoadGamemodeSpecificData(VnXPlayer player, Gamemodes gamemode)
        {
            VenoX.TriggerClientEvent(player, "LoadingScreen:ShowPreload", true);
            Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
            VenoX.TriggerClientEvent(player, "Quests:Show", false);

            switch (gamemode)
            {
                case Gamemodes.Reallife:
                    Main.LoadReallifeMaps(player);
                    VenoX.TriggerPreloadEvent(player, "Loading Inventory...","Inventory:Load");
                    VenoX.TriggerPreloadEvent(player,"Loading Personal-Menu...", "XMenu:Load");
                    VenoX.TriggerPreloadEvent(player, "Loading Phone...","Phone:Load");
                    VenoX.TriggerPreloadEvent(player, "Loading HUD...","Reallife:LoadHUD", player.Settings.ReallifeHud);
                    VenoX.TriggerPreloadEvent(player, "Loading Quests...","Quests:Show", true);
                    Sync.LoadAllNpCs(player);
                    break;
                case Gamemodes.Tactics:
                    VenoX.TriggerPreloadEvent(player, "Loading Basic Tactics...","Tactics:Load");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, false, false);
                    ZombieAssets.LoadZombieEntityData(player);
                    VenoX.TriggerPreloadEvent(player, "Loading Zombie HUD...","Zombies:CreateHUD", player.Zombies.ZombieKills);
                    break;
                case Gamemodes.Race:
                    VenoX.TriggerPreloadEvent(player, "Loading Basic Race...","Race:Load");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.SeventowersMap);
                    List<VnXPlayer> sevenTowersPlayers = _Globals_.Main.SevenTowersPlayers.Where(p => p != player).ToList();
                    foreach (VnXPlayer otherPlayers in sevenTowersPlayers)
                    {
                        VenoX.TriggerPreloadEvent(otherPlayers, "Loading SevenTowers specator...","SevenTowers:AddPlayer", player);
                        VenoX.TriggerPreloadEvent(player, "Loading SevenTowers spectator(2)...","SevenTowers:AddPlayer", otherPlayers);
                    }
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.Derby1Map);
                    break;
                case Gamemodes.Shooter:
                    break;
                default:
                    break;
            }
        }
        public static void UnloadGamemodeWindows(VnXPlayer player, Gamemodes gamemode)
        {
            player.SetPlayerVisible(true);
            VenoX.TriggerClientEvent(player, "BlipClass:RemoveAllBlips");
            switch (gamemode)
            {
                case Gamemodes.Reallife:
                    Main.UnloadReallifeMaps(player);
                    VenoX.TriggerClientEvent(player, "Inventory:Unload");
                    VenoX.TriggerClientEvent(player, "XMenu:Unload");
                    VenoX.TriggerClientEvent(player, "Phone:Unload");
                    VenoX.TriggerClientEvent(player, "Reallife:UnloadHUD");
                    VenoX.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    VenoX.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    VenoX.TriggerClientEvent(player, "Quests:Show", false);
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
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.SeventowersMap);
                    _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                    foreach (VnXPlayer otherPlayers in _Globals_.Main.SevenTowersPlayers.ToList().Where(p => p != player))
                        VenoX.TriggerClientEvent(otherPlayers, "SevenTowers:RemovePlayer", player);
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.Derby1Map);
                    break;
                case Gamemodes.Shooter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gamemode), gamemode, null);
            }
        }

    }
}
