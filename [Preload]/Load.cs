using AltV.Net;
using System.Collections.Generic;
using System.Linq;
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
            VenoX.TriggerClientEvent(player, "Quests:Show", false);
            switch (Gamemode)
            {
                case Gamemodes.Reallife:
                    Loading.Main.LoadReallifeMaps(player);
                    VenoX.TriggerClientEvent(player, "Inventory:Load");
                    VenoX.TriggerClientEvent(player, "XMenu:Load");
                    VenoX.TriggerClientEvent(player, "Phone:Load");
                    VenoX.TriggerClientEvent(player, "Reallife:LoadHUD", player.Reallife.HUD);
                    VenoX.TriggerClientEvent(player, "Quests:Show", true);
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
                    List<VnXPlayer> SevenTowersPlayers = Globals.Main.SevenTowersPlayers.Where(p => p != player).ToList();
                    foreach (VnXPlayer otherplayers in SevenTowersPlayers)
                    {
                        VenoX.TriggerClientEvent(otherplayers, "SevenTowers:AddPlayer", player);
                        VenoX.TriggerClientEvent(player, "SevenTowers:AddPlayer", otherplayers);
                    }
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.LoadMap(player, _Maps_.Main.DERBY1_MAP);
                    break;
            }
        }
        public static void UnloadGamemodeWindows(VnXPlayer player, Gamemodes Gamemode)
        {
            Core.RageAPI.SetPlayerVisible(player, true);
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
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.SEVENTOWERS_MAP);
                    _Gamemodes_.SevenTowers.Main.TakePlayerFromRound(player);
                    foreach (VnXPlayer otherplayers in Globals.Main.SevenTowersPlayers.ToList().Where(p => p != player))
                        VenoX.TriggerClientEvent(player, "SevenTowers:RemovePlayer", player);
                    break;
                case Gamemodes.Derby:
                    _Maps_.Main.UnloadMap(player, _Maps_.Main.DERBY1_MAP);
                    break;
            }
        }

    }
}
