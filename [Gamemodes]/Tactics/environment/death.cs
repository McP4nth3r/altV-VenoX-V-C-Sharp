using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._Gamemodes_.Tactics.Globals;
using VenoXV._RootCore_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using static VenoXV._Language_.Main;

namespace VenoXV._Gamemodes_.Tactics.environment
{
    public class Death : IScript
    {
        public static async void OnPlayerDeath(VnXPlayer player, VnXPlayer killer)
        {
            try
            {
                if (!player.Tactics.IsDead)
                {
                    Languages Pair = (Languages)player.Language;
                    if (player != killer && killer != null)
                    {
                        switch (killer.Tactics.CurrentStreak)
                        {
                            case 3:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(Pair, " hat einen Tripple-Kill erzielt!"));
                                break;
                            case 5:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(Pair, " hat einen Penta-Kill Streak erzielt!"));
                                break;
                            case 7:
                                Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await GetTranslatedTextAsync(Pair, " hat einen Ultimate-Kill Streak erzielt!"));
                                break;
                        }
                        killer.Tactics.Kills += 1;
                        killer.Tactics.CurrentKills += 1;
                        killer.Tactics.CurrentStreak += 1;
                    }


                    Functions.SendTacticRoundMessage(RageAPI.GetHexColorcode(0, 200, 0) + killer.Username + " killed " + player.Username + "!");
                    player.Tactics.Spawned = false;
                    player.Tactics.IsDead = true;
                    player.Tactics.Deaths += 1;
                    player.Tactics.CurrentStreak = 0;

                    if (player.Tactics.Team == EntityData.BFAC_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                        if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                        {
                            //Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_A_WinnerText);
                            //Functions.ShowOutroScreen(await GetTranslatedTextAsync(Pair, Lobby.Main.CurrentMap.Team_A_WinnerText));
                            Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_A_WinnerText);
                            return;
                        }
                    }
                    else if (player.Tactics.Team == EntityData.COPS_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_COPS -= 1;
                        if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                        {
                            //Functions.ShowOutroScreen(await GetTranslatedTextAsync(Pair, Lobby.Main.CurrentMap.Team_B_WinnerText));
                            Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_B_WinnerText);
                            return;
                        }
                    }
                    else
                    {
                        Debug.OutputDebugString("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                        RageAPI.SendTranslatedChatMessageToAll("[ERROR]: UNKNOWN TEAM " + player.Tactics.Team);
                    }
                    player.SpawnPlayer(new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                    Lobby.Main.SyncStats();
                    Lobby.Main.SyncPlayerStats();
                    RageAPI.SetPlayerVisible(player, false);
                    VenoX.TriggerClientEvent(player, "Tactics:OnDeath");
                    Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    player.RemoveAllPlayerWeapons();
                }
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
