﻿using AltV.Net;
using AltV.Net.Data;
using System;
using VenoXV._Gamemodes_.Tactics.Globals;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Tactics.environment
{
    public class Death : IScript
    {
        public static void OnPlayerDeath(Client player, Client killer)
        {
            try
            {
                if (!player.Tactics.IsDead)
                {
                    string Pair = _Language_.Main.GetClientLanguagePair(player);
                    if (player != killer && killer != null)
                    {
                        switch (killer.Tactics.CurrentStreak)
                        {
                            case 3:
                                //Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await _Language_.Main.TranslateText(" hat einen Tripple-Kill erzielt!", "de", Pair));
                                break;
                            case 5:
                                //Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await _Language_.Main.TranslateText(" hat einen Penta-Kill Streak erzielt!", "de", Pair));
                                break;
                            case 7:
                                //Functions.SendTacticRoundMessage(Core.RageAPI.GetHexColorcode(200, 0, 200) + killer.Username + await _Language_.Main.TranslateText(" hat einen Ultimate-Kill Streak erzielt!", "de", Pair));
                                break;
                        }
                        killer.Tactics.Kills += 1;
                        killer.Tactics.CurrentKills += 1;
                        killer.Tactics.CurrentStreak += 1;
                    }


                    Functions.SendTacticRoundMessage(RageAPI.GetHexColorcode(0, 200, 0) + killer.Username + " hat " + player.Username + " getötet!");
                    player.Tactics.Spawned = false;
                    player.Tactics.IsDead = true;
                    player.Tactics.Deaths += 1;
                    player.Tactics.CurrentStreak = 0;

                    if (player.Tactics.Team == EntityData.BFAC_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                        if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                        {
                            Functions.ShowOutroScreen(Lobby.Main.CurrentMap.Team_A_WinnerText);
                            //Functions.ShowOutroScreen(_Language_.Main.TranslateText(Lobby.Main.CurrentMap.Team_A_WinnerText, "de", Pair));
                            return;
                        }
                    }
                    else if (player.Tactics.Team == EntityData.COPS_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_COPS -= 1;
                        if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                        {
                            //Functions.ShowOutroScreen(_Language_.Main.TranslateText(Lobby.Main.CurrentMap.Team_B_WinnerText, "de", Pair));
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
                    Alt.Server.TriggerClientEvent(player, "Tactics:OnDeath");
                    Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                    player.RemoveAllPlayerWeapons();
                }
            }
            catch (Exception ex) { Debug.CatchExceptions("OnPlayerDeath", ex); }
        }
    }
}
