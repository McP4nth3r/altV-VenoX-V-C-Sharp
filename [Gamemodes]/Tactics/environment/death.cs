using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Resources.Chat.Api;
using System;
using VenoXV._Gamemodes_.Tactics.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.environment
{
    public class Death : IScript
    {
        [Command("tpos")]
        public static void GetTacticSpawnpoint(Client player)
        {
            Core.Debug.OutputDebugString("TPOS : " + player.Position.X + "f, " + player.Position.Y + "f, " + player.Position.Z + "f");
        }
        public static void OnPlayerDeath(Client player, Client killer)
        {
            try
            {
                player.vnxSetElementData(EntityData.PLAYER_CURRENT_STREAK, 0);
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_DEAD) == false || player.vnxGetElementData<string>(EntityData.PLAYER_IS_DEAD) == "")
                {
                    if (player != killer)
                    {
                        switch (killer.vnxGetElementData<int>(EntityData.PLAYER_CURRENT_STREAK))
                        {
                            case 3:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + " hat einen Tripple-Kill erzielt!!");
                                break;
                            case 5:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + " hat einen Penta-Kill Streak erzielt!!");
                                break;
                            case 7:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + " hat einen Ultimate-Kill Streak erzielt!!");
                                break;
                        }
                        killer.vnxSetElementData(EntityData.PLAYER_KILLED_PLAYERS, killer.vnxGetElementData<int>(EntityData.PLAYER_KILLED_PLAYERS) + 1);
                        killer.vnxSetElementData(EntityData.PLAYER_CURRENT_STREAK, killer.vnxGetElementData<int>(EntityData.PLAYER_CURRENT_STREAK) + 1);
                        killer.vnxSetElementData(Tactics.Globals.EntityData.PLAYER_TACTIC_KILLS, killer.vnxGetElementData<int>(Tactics.Globals.EntityData.PLAYER_TACTIC_KILLS) + 1);
                    }


                    Functions.SendTacticRoundMessage(RageAPI.GetHexColorcode(0, 200, 0) + killer.Username + " hat " + player.Username + " getötet!");
                    player.vnxSetElementData(EntityData.PLAYER_SPAWNED_TACTICS, false);
                    player.vnxSetElementData(EntityData.PLAYER_IS_DEAD, true);
                    player.vnxSetElementData(EntityData.PLAYER_TACTIC_TODE, player.vnxGetElementData<int>(EntityData.PLAYER_TACTIC_TODE) + 1);

                    if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.BFAC_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                        if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                        {
                            Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_A_WinnerText);
                            return;
                        }
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.COPS_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_COPS -= 1;
                        if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                        {
                            Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_B_WinnerText);
                            return;
                        }
                    }
                    else
                    {
                        Core.Debug.OutputDebugString("[ERROR]: UNKNOWN TEAM " + player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM));
                        Core.RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN TEAM " + player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM));
                    }
                    player.SpawnPlayer(new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                    Lobby.Main.SyncStats();
                    Lobby.Main.SyncPlayerStats();
                    RageAPI.SetPlayerVisible(player, false);
                    player.Emit("Tactics:OnDeath");
                    _Gamemodes_.Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    player.RemoveAllPlayerWeapons();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("OnPlayerDeath", ex); }
        }
    }
}
