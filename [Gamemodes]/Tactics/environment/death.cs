using System;
using AltV.Net;
using AltV.Net.Data;
using VenoXV._Gamemodes_.Tactics.Globals;
using VenoXV._Gamemodes_.Tactics.Lobby;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models;
using static VenoXV._Language_.Main;
using VnX = VenoXV._Gamemodes_.Reallife.dxLibary.VnX;

namespace VenoXV._Gamemodes_.Tactics.environment
{
    public class Death : IScript
    {
        public static async void OnPlayerDeath(VnXPlayer player, VnXPlayer killer)
        {
            try
            {
                Round currentPlayerLobby = player.Tactics.CurrentLobby;
                if (currentPlayerLobby is null) return;
                if (!player.Tactics.IsDead)
                {
                    Languages pair = (Languages)player.Language;
                    if (player != killer && killer != null)
                    {
                        switch (killer.Tactics.CurrentStreak)
                        {
                            case 3:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(pair, " hat einen Tripple-Kill erzielt!"), currentPlayerLobby);
                                break;
                            case 5:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(pair, " hat einen Penta-Kill Streak erzielt!"), currentPlayerLobby);
                                break;
                            case 7:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(pair, " hat einen Ultimate-Kill Streak erzielt!"), currentPlayerLobby);
                                break;
                        }
                        killer.Tactics.Kills += 1;
                        killer.Tactics.CurrentKills += 1;
                        killer.Tactics.CurrentStreak += 1;
                    }


                    Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(0, 200, 0) + killer.Username + " killed " + player.Username + "!", currentPlayerLobby);
                    player.Tactics.Spawned = false;
                    player.Tactics.IsDead = true;
                    player.Tactics.Deaths += 1;
                    player.Tactics.CurrentStreak = 0;

                    if (player.Tactics.Team == EntityData.BfacName)
                    {
                        currentPlayerLobby.MemberCountBfac -= 1;
                        if (currentPlayerLobby.MemberCountBfac <= 0)
                        {
                            //Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_A_WinnerText);
                            //Functions.ShowOutroScreen(await GetTranslatedTextAsync(Pair, Lobby.Main.CurrentMap.Team_A_WinnerText));
                            Functions.ShowOutroScreen(currentPlayerLobby.CurrentMap.TeamAWinnerText, currentPlayerLobby);
                            return;
                        }
                    }
                    else if (player.Tactics.Team == EntityData.CopsName)
                    {
                        currentPlayerLobby.MemberCountCops -= 1;
                        if (currentPlayerLobby.MemberCountCops <= 0)
                        {
                            //Functions.ShowOutroScreen(await GetTranslatedTextAsync(Pair, Lobby.Main.CurrentMap.Team_B_WinnerText));
                            Functions.ShowOutroScreen(currentPlayerLobby.CurrentMap.TeamBWinnerText, currentPlayerLobby);
                            return;
                        }
                    }
                    else
                    {
                        Debug.OutputDebugString("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                        RageApi.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                    }
                    player.SpawnPlayer(new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                    currentPlayerLobby.SyncStats();
                    currentPlayerLobby.SyncPlayerStats();
                    player.SetPlayerVisible(false);
                    VenoX.TriggerClientEvent(player, "Tactics:OnDeath");
                    VnX.SetElementFrozen(player, true);
                    player.RemoveAllPlayerWeapons();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
