using AltV.Net;
using AltV.Net.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV._RootCore_.Models;

namespace VenoXV._Globals_.Scoreboard
{
    public class Scoreboard : IScript
    {
        public static List<ScoreboardModel> SpielerLi;
        public static ScoreboardModel SpielerListe;
        public static Rgba OtherLobbyColor = new Rgba(180, 180, 180, 255);

        public class ScoreboardModel
        {
            public string Username { get; set; }
            public int Gamemode { get; set; }
            public int FID { get; set; }
            public string[] Entry { get; set; }
        }
        public static List<ScoreboardModel> AllPlayers = new List<ScoreboardModel>();

        public static void InitializeTacticsEntrys(Client player)
        {
            TimeSpan spielzeittab = TimeSpan.FromMinutes(player.Played);
            string Spielzeit = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

            ScoreboardModel pClass = new ScoreboardModel
            {
                Username = player.Username,
                Gamemode = player.Gamemode,
                FID = 0,
                Entry = new string[] { player.Username, Spielzeit, player.Reallife.SocialState, player.Tactics.Kills.ToString(), player.Tactics.Deaths.ToString(), player.Ping.ToString(), player.Ping.ToString() }
            };
            AllPlayers.Add(pClass);
        }
        public static void InitializeReallifeEntrys(Client player)
        {
            TimeSpan spielzeittab = TimeSpan.FromMinutes(player.Played);
            string Spielzeit = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);
            ScoreboardModel pClass = new ScoreboardModel
            {
                Username = player.Username,
                Gamemode = player.Gamemode,
                FID = player.Reallife.Faction,
                Entry = new string[] { player.Username, Spielzeit, player.Reallife.SocialState, "13212321", "-", player.Reallife.Faction.ToString(), player.Ping.ToString() }
            };
            AllPlayers.Add(pClass);
        }

        public static void UpdateScoreboard()
        {
            AllPlayers = new List<ScoreboardModel>();
            foreach (Client player in Alt.GetAllPlayers())
            {
                switch (player.Gamemode)
                {
                    case (int)_Preload_.Preload.Gamemodes.Tactics:
                        InitializeTacticsEntrys(player);
                        break;
                    case (int)_Preload_.Preload.Gamemodes.Reallife:
                        InitializeReallifeEntrys(player);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Fill_Playerlist(object unused)
        {
            try
            {
                UpdateScoreboard();
                List<ScoreboardModel> AlleSpieler = AllPlayers;
                foreach (Client player in Alt.GetAllPlayers())
                {
                    Alt.Server.TriggerClientEvent(player, "UpdateScoreboard_Event", JsonConvert.SerializeObject(AlleSpieler), player.Gamemode);
                }
            }
            catch { }
        }
    }
}
