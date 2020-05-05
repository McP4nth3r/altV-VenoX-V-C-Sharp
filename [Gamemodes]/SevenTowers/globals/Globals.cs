using AltV.Net;
using System;
using VenoXV._RootCore_.Models;

namespace VenoXV.SevenTowers.globals
{
    public class Main : IScript
    {
        public static void OnPlayerDisconnect(PlayerModel player)
        {
            try
            {
                Lobby.Main.SevenTowersPlayers.Remove(player);
            }
            catch { }
        }

        public static void OnUpdate()
        {
            if (Lobby.Main.SEVENTOWERS_ROUND_END <= DateTime.Now)
            {
                Lobby.Main.EndRound();
                Lobby.Main.SEVENTOWERS_ROUND_IS_RUNNING = false;
                Lobby.Main.SEVENTOWERS_ROUND_WILL_START = DateTime.Now.AddSeconds(Lobby.Main.SEVENTOWERS_ROUND_START_AFTER_LOADING);
            }

            if (!Lobby.Main.SEVENTOWERS_ROUND_IS_RUNNING && Lobby.Main.SEVENTOWERS_ROUND_WILL_START <= DateTime.Now)
            {
                if (Lobby.Main.SevenTowersPlayers.Count > 0)
                {
                    Lobby.Main.StartNewRound();
                    Lobby.Main.SEVENTOWERS_ROUND_IS_RUNNING = true;
                    Lobby.Main.SEVENTOWERS_ROUND_END = DateTime.Now.AddSeconds(Lobby.Main.SEVENTOWERS_ROUND_MINUTE);
                }
            }
        }
    }
}
