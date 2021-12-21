using System;
using System.Collections.Generic;
using System.Linq;
using AltV.Net;
using AltV.Net.Data;
using Newtonsoft.Json;
using VenoXV._Preload_;
using VenoXV.Models;

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
            public int Fid { get; set; }
            public string[] Entry { get; set; }
        }
        public static List<ScoreboardModel> AllPlayers = new List<ScoreboardModel>();

        public static void InitializeTacticsEntrys(VnXPlayer player)
        {
            TimeSpan spielzeittab = TimeSpan.FromMinutes(player.Played);
            string spielzeit = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

            ScoreboardModel pClass = new ScoreboardModel
            {
                Username = player.Username,
                Gamemode = player.Gamemode,
                Fid = 0,
                Entry = new[] { player.Username, spielzeit, player.Reallife.SocialState, player.Tactics.Kills.ToString(), player.Tactics.Deaths.ToString(), player.Ping.ToString(), player.Ping.ToString() }
            };
            AllPlayers.Add(pClass);
        }
        public static void InitializeReallifeEntrys(VnXPlayer player)
        {
            TimeSpan spielzeittab = TimeSpan.FromMinutes(player.Played);
            string spielzeit = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);
            ScoreboardModel pClass = new ScoreboardModel
            {
                Username = player.Username,
                Gamemode = player.Gamemode,
                Fid = player.Reallife.Faction,
                Entry = new[] { player.Username, spielzeit, player.Reallife.SocialState, "13212321", "-", player.Reallife.Faction.ToString(), player.Ping.ToString() }
            };
            AllPlayers.Add(pClass);
        }

        public static void UpdateScoreboard()
        {
            AllPlayers = new List<ScoreboardModel>();
            foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList())
            {
                switch (player.Gamemode)
                {
                    case (int)Preload.Gamemodes.Tactics:
                        InitializeTacticsEntrys(player);
                        break;
                    case (int)Preload.Gamemodes.Reallife:
                        InitializeReallifeEntrys(player);
                        break;
                }
            }
        }

        public static void Fill_Playerlist(object unused)
        {
            try
            {
                UpdateScoreboard();
                List<ScoreboardModel> alleSpieler = AllPlayers;
                foreach (VnXPlayer player in VenoX.GetAllPlayers().ToList())
                {
                    VenoX.TriggerClientEvent(player, "UpdateScoreboard_Event", JsonConvert.SerializeObject(alleSpieler), player.Gamemode);
                }
            }
            catch(Exception ex){Core.Debug.CatchExceptions(ex);}
        }
    }
}
