using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VenoXV.Anti_Cheat;
using VenoXV.Reallife.Core;
using VenoXV.Tactics.globals;

namespace VenoXV.Tactics.environment
{
    public class Death : IScript
    {
        public static void OnPlayerDeath(IPlayer player, IPlayer killer)
        {
            try
            {
                if (player.vnxGetElementData<bool>(EntityData.PLAYER_IS_DEAD) == false || player.vnxGetElementData<string>(EntityData.PLAYER_IS_DEAD) == "")
                {
                    AntiCheat_Allround.SetTimeOutHealth(player, 1000);
                    Tactics.globals.Functions.SendTacticRoundMessage(RageAPI.GetHexColorcode(0,200,0) + killer.Name + " hat " +player.GetVnXName<string>() + " getötet!");
                    player.SetData(EntityData.PLAYER_SPAWNED_TACTICS, false);
                    player.SetData(EntityData.PLAYER_IS_DEAD, true);

                    killer.SetData(EntityData.PLAYER_KILLED_PLAYERS, killer.vnxGetElementData<int>(EntityData.PLAYER_KILLED_PLAYERS) + 1);
                    killer.SetData(Reallife.Globals.EntityData.PLAYER_TACTIC_KILLS, killer.vnxGetElementData<int>(Reallife.Globals.EntityData.PLAYER_TACTIC_KILLS) + 1);
                    player.SetData(Reallife.Globals.EntityData.PLAYER_TACTIC_TODE, player.vnxGetElementData<int>(Reallife.Globals.EntityData.PLAYER_TACTIC_TODE) + 1);
                    if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.BFAC_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_BFAC -= 1;
                        if (Lobby.Main.MEMBER_COUNT_BFAC <= 0)
                        {
                            Tactics.globals.Functions.ShowOutroScreen("Das L.S.P.D gewinnt die Runde.");
                            return;
                        }
                    }
                    else if (player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == EntityData.COPS_NAME)
                    {
                        Lobby.Main.MEMBER_COUNT_COPS -= 1;
                        if (Lobby.Main.MEMBER_COUNT_COPS <= 0)
                        {
                            Tactics.globals.Functions.ShowOutroScreen("Die Grove Street gewinnt die Runde.");
                            return;
                        }
                    }
                    Lobby.Main.SyncStats();
                    Lobby.Main.SyncPlayerStats();
                    //foreach (IPlayer players in Alt.GetAllPlayers())
                    //{
                      //  if (players.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM) == player.vnxGetElementData<string>(EntityData.PLAYER_CURRENT_TEAM))
                       // {
                            player.Spawn(new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                            RageAPI.SetPlayerVisible(player, false);
                            //NAPI.Player.SpawnPlayer(player, new Position(player.Position.X, player.Position.Y, player.Position.Z + 50));
                            Reallife.dxLibary.VnX.SetElementFrozen(player, true);
                            //ToDo : ZwischenLösung Finden! player.Transparency = 0;
                            player.RemoveAllWeapons();
                            //player.Emit("Tactics:SpectatePlayer", players);
                            return;
                        //}
                    //}
                }
            }
            catch(Exception ex) { Reallife.Core.Debug.CatchExceptions("OnPlayerDeath", ex); }
        }
    }
}
