using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using VenoX.Core._Gamemodes_.Zombie.Assets;
using VenoX.Core._Preload_.Loading;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Core._RootCore_.Sync;
using static VenoX.Core._Preload_.Preload;

namespace VenoX.Core._Preload_
{
    public class Load : IScript
    {

        public static void LoadGamemodeSpecificData(VnXPlayer player, Gamemodes gamemode)
        {
            _RootCore_.VenoX.TriggerClientEvent(player, "LoadingScreen:ShowPreload", true);
            Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
            _RootCore_.VenoX.TriggerClientEvent(player, "Quests:Show", false);

            switch (gamemode)
            {
                case Gamemodes.Reallife:
                    Main.LoadReallifeMaps(player);
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Inventory...","Inventory:Load");
                    _RootCore_.VenoX.TriggerPreloadEvent(player,"Loading Personal-Menu...", "XMenu:Load");
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Phone...","Phone:Load");
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading HUD...","Reallife:LoadHUD", player.Settings.ReallifeHud);
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Quests...","Quests:Show", true);

                    Sync.LoadAllNpCs(player);
                    break;
                case Gamemodes.Tactics:
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Basic Tactics...","Tactics:Load");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, false, false);
                    ZombieAssets.LoadZombieEntityData(player);
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Zombie HUD...","Zombies:CreateHUD", player.Zombies.ZombieKills);
                    break;
                case Gamemodes.Race:
                    _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading Basic Race...","Race:Load");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.SeventowersMap);
                    List<VnXPlayer> sevenTowersPlayers = Enumerable.Where<VnXPlayer>(_Globals_.Initialize.SevenTowersPlayers, p => p != player).ToList();
                    foreach (VnXPlayer otherPlayers in sevenTowersPlayers)
                    {
                        _RootCore_.VenoX.TriggerPreloadEvent(otherPlayers, "Loading SevenTowers specator...","SevenTowers:AddPlayer", player);
                        _RootCore_.VenoX.TriggerPreloadEvent(player, "Loading SevenTowers spectator(2)...","SevenTowers:AddPlayer", otherPlayers);
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
            _RootCore_.VenoX.TriggerClientEvent(player, "BlipClass:RemoveAllBlips");
            switch (gamemode)
            {
                case Gamemodes.Reallife:
                    Main.UnloadReallifeMaps(player);
                    _RootCore_.VenoX.TriggerClientEvent(player, "Inventory:Unload");
                    _RootCore_.VenoX.TriggerClientEvent(player, "XMenu:Unload");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Phone:Unload");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Reallife:UnloadHUD");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Reallife:DestroyHouseBlips");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Reallife:DestroyATMBlips");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Quests:Show", false);
                    break;
                case Gamemodes.Tactics:
                    _RootCore_.VenoX.TriggerClientEvent(player, "Tactics:Unload");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
                    _RootCore_.VenoX.TriggerClientEvent(player, "Zombies:DestroyHUD");
                    _RootCore_.VenoX.TriggerClientEvent(player, "Zombies:OnGamemodeDisconnect");
                    break;
                case Gamemodes.Race:
                    _RootCore_.VenoX.TriggerClientEvent(player, "Race:Unload");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.SeventowersMap);
                    _Gamemodes_.SevenTowers.lobby.Main.TakePlayerFromRound(player);
                    foreach (VnXPlayer otherPlayers in Enumerable.ToList<VnXPlayer>(_Globals_.Initialize.SevenTowersPlayers).Where(p => p != player))
                        _RootCore_.VenoX.TriggerClientEvent(otherPlayers, "SevenTowers:RemovePlayer", player);
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
