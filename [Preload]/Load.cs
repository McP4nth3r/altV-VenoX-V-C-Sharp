using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using VenoXV._Preload_.Loading;
using VenoXV._RootCore_.Sync;
using VenoXV.Core;
using VenoXV.Models;
using static VenoXV._Preload_.Preload;

namespace VenoXV._Preload_
{
    public class Load : IScript
    {

        public static void LoadGamemodeWindows(VnXPlayer player, Gamemodes gamemode)
        {
            Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, true, false);
            VenoX.TriggerClientEvent(player, "Quests:Show", false);
            switch (gamemode)
            {
                case Gamemodes.Reallife:
                    Main.LoadReallifeMaps(player);
                    VenoX.TriggerClientEvent(player, "Inventory:Load");
                    VenoX.TriggerClientEvent(player, "XMenu:Load");
                    VenoX.TriggerClientEvent(player, "Phone:Load");
                    VenoX.TriggerClientEvent(player, "Reallife:LoadHUD", player.Settings.ReallifeHud);
                    VenoX.TriggerClientEvent(player, "Quests:Show", true);
                    Sync.LoadAllNpCs(player);
                    break;
                case Gamemodes.Tactics:
                    VenoX.TriggerClientEvent(player, "Tactics:Load");
                    break;
                case Gamemodes.Zombies:
                    Alt.Emit("GlobalSystems:PlayerProofs", player, true, false, false, false, false, false);
                    VenoX.TriggerClientEvent(player, "Zombies:CreateHUD", player.Zombies.ZombieKills);
                    break;
                case Gamemodes.Race:
                    VenoX.TriggerClientEvent(player, "Race:Load");
                    break;
                case Gamemodes.SevenTowers:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.SeventowersMap);
                    List<VnXPlayer> sevenTowersPlayers = _Globals_.Main.SevenTowersPlayers.Where(p => p != player).ToList();
                    foreach (VnXPlayer otherplayers in sevenTowersPlayers)
                    {
                        VenoX.TriggerClientEvent(otherplayers, "SevenTowers:AddPlayer", player);
                        VenoX.TriggerClientEvent(player, "SevenTowers:AddPlayer", otherplayers);
                    }
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.Derby1Map);
                    break;
            }
        }
        public static void UnloadGamemodeWindows(VnXPlayer player, Gamemodes gamemode)
        {
            RageApi.SetPlayerVisible(player, true);
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
                    foreach (VnXPlayer otherplayers in _Globals_.Main.SevenTowersPlayers.ToList().Where(p => p != player))
                        VenoX.TriggerClientEvent(player, "SevenTowers:RemovePlayer", player);
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.Derby1Map);
                    break;
            }
        }

    }
}
