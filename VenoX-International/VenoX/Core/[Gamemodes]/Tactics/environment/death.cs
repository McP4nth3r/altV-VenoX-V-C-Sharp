using System;
using AltV.Net;
using AltV.Net.Data;
using VenoX.Core._Gamemodes_.Tactics.globals;
using VenoX.Core._Gamemodes_.Tactics.lobby;
using VenoX.Core._Language_;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;
using static VenoX.Core._Language_.Main;
using VnX = VenoX.Core._Gamemodes_.Reallife.anzeigen.ServerToClient.VnX;

namespace VenoX.Core._Gamemodes_.Tactics.environment
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
                    Constants.Languages pair = (Constants.Languages)player.Language;
                    if (player != killer && killer != null)
                    {
                        switch (killer.Tactics.CurrentStreak)
                        {
                            case 3:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.CharacterUsername + await GetTranslatedTextAsync(pair, " hat einen Tripple-Kill erzielt!"), currentPlayerLobby);
                                break;
                            case 5:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.CharacterUsername + await GetTranslatedTextAsync(pair, " hat einen Penta-Kill Streak erzielt!"), currentPlayerLobby);
                                break;
                            case 7:
                                Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(200, 0, 200) + killer.CharacterUsername + await GetTranslatedTextAsync(pair, " hat einen Ultimate-Kill Streak erzielt!"), currentPlayerLobby);
                                break;
                        }
                        killer.Tactics.Kills += 1;
                        killer.Tactics.CurrentKills += 1;
                        killer.Tactics.CurrentStreak += 1;
                    }


                    Functions.SendTacticRoundMessage(RageApi.GetHexColorcode(0, 200, 0) + killer.CharacterUsername + " killed " + player.CharacterUsername + "!", currentPlayerLobby);
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
                        ConsoleHandling.OutputDebugString("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                        RageApi.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                    }
                    player.SpawnPlayer(new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                    currentPlayerLobby.SyncStats();
                    currentPlayerLobby.SyncPlayerStats();
                    player.SetPlayerVisible(false);
                    _RootCore_.VenoX.TriggerClientEvent(player, "Tactics:OnDeath");
                    VnX.SetElementFrozen(player, true);
                    player.RemoveAllPlayerWeapons();
                }
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
