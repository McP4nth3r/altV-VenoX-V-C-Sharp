using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.factions;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Globals_.Scoreboard
{
    public class Scoreboard : IScript
    {
        public static List<ScoreboardModel> SpielerLi;
        public static ScoreboardModel SpielerListe;
        public static Rgba OtherLobbyColor = new Rgba(180, 180, 180, 255);
        public static int LSPD = 0;
        public static int LCN = 0;
        public static int YAKUZA = 0;
        public static int NEWS = 0;
        public static int FBI = 0;
        public static int VL = 0;
        public static int USARMY = 0;
        public static int SAMCRO = 0;
        public static int MEDIC = 0;
        public static int MECHANIKER = 0;
        public static int BALLAS = 0;
        public static int GROVE = 0;
        public static void InitializeScoreboardStats()
        {
            LSPD = 0;
            LCN = 0;
            YAKUZA = 0;
            NEWS = 0;
            FBI = 0;
            VL = 0;
            USARMY = 0;
            SAMCRO = 0;
            MEDIC = 0;
            MECHANIKER = 0;
            BALLAS = 0;
            GROVE = 0;
            foreach (Client players in Globals.Main.ReallifePlayers)
            {
                switch (players.Reallife.Faction)
                {
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_POLICE:
                        LSPD++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_COSANOSTRA:
                        LCN++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_YAKUZA:
                        YAKUZA++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_NEWS:
                        NEWS++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_FBI:
                        FBI++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_MS13:
                        VL++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_USARMY:
                        USARMY++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_SAMCRO:
                        SAMCRO++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_MECHANIK:
                        MECHANIKER++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_BALLAS:
                        BALLAS++;
                        break;
                    case _Gamemodes_.Reallife.Globals.Constants.FACTION_GROVE:
                        GROVE++;
                        break;
                }
            }
        }

        public static void DrawReallifeScoreboard(Client Spieler)
        {
            try
            {
                int Spielzeit = 0;
                int Fraktion = 0;
                if (Spieler.Played >= 0)
                {
                    Spielzeit = Spieler.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED);
                }
                if (Spieler.Reallife.Faction >= 0)
                {
                    Fraktion = Spieler.Reallife.Faction;
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string factionname = Faction.GetPlayerFactionName(Fraktion);
                if (Fraktion == _Gamemodes_.Reallife.Globals.Constants.FACTION_POLICE)
                {
                    factionname = "L.S.P.D";
                }
                if (Fraktion == _Gamemodes_.Reallife.Globals.Constants.FACTION_FBI)
                {
                    factionname = "F.I.B";
                }
                string playerping = Spieler.Ping.ToString();
                int FraktionsID = Fraktion;
                string viplevel = Spieler.vnxGetElementData<string>(Globals.EntityData.PLAYER_VIP_LEVEL);
                if (Spieler.Playing == false && Spieler.Gamemode == (int)_Preload_.Preload.Gamemodes.Reallife)
                {
                    SpielerListe.FID = -1;
                    SpielerListe.SpielerName = Spieler.Username;
                    SpielerListe.Spielzeit = "-";
                    SpielerListe.SpielzeitTactics = "-";
                    SpielerListe.VIP = "-";
                    SpielerListe.SozialerStatus = "Reallife verbindet...";
                    SpielerListe.SozialerStatusTactics = "Reallife verbindet...";
                    SpielerListe.Fraktion = "-";
                    SpielerListe.kills = "-";
                    SpielerListe.tode = "-";
                    SpielerListe.Ping = playerping;
                    SpielerListe.ColorStorageR = 255;
                    SpielerListe.ColorStorageG = 255;
                    SpielerListe.ColorStorageB = 255;
                    SpielerListe.ColorStorageTacticsR = OtherLobbyColor.R;
                    SpielerListe.ColorStorageTacticsG = OtherLobbyColor.G;
                    SpielerListe.ColorStorageTacticsB = OtherLobbyColor.B;

                    SpielerListe.ColorStorageVR = 255;
                    SpielerListe.ColorStorageVG = 255;
                    SpielerListe.ColorStorageVB = 255;
                }
                else
                {
                    int R = 255;
                    int G = 255;
                    int B = 255;

                    int VR = 255;
                    int VG = 255;
                    int VB = 255;
                    if (viplevel == "TOP DONATOR") { viplevel = "Top Donator"; }
                    if (viplevel == "UltimateRed") { viplevel = "Ultimate RED"; }
                    SpielerListe.FID = FraktionsID;
                    SpielerListe.SpielerName = Spieler.Username;
                    SpielerListe.Spielzeit = label;
                    SpielerListe.SpielzeitTactics = "-";
                    SpielerListe.VIP = viplevel;
                    SpielerListe.SozialerStatus = Spieler.Reallife.SocialState;
                    SpielerListe.SozialerStatusTactics = "Reallife";
                    SpielerListe.kills = "-";
                    SpielerListe.tode = "-";
                    SpielerListe.Fraktion = factionname;
                    SpielerListe.Ping = playerping;
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_POLICE) { R = 0; G = 140; B = 183; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_COSANOSTRA) { R = 120; G = 120; B = 120; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_YAKUZA) { R = 255; G = 4; B = 4; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_NEWS) { R = 180; G = 130; B = 0; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_FBI) { R = 0; G = 86; B = 184; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_MS13) { R = 128; G = 129; B = 150; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_USARMY) { R = 0; G = 100; B = 0; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_SAMCRO) { R = 100; G = 50; B = 50; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_EMERGENCY) { R = 255; G = 51; B = 51; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_MECHANIK) { R = 255; G = 100; B = 0; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_BALLAS) { R = 138; G = 43; B = 226; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == _Gamemodes_.Reallife.Globals.Constants.FACTION_GROVE) { R = 0; G = 152; B = 0; }
                    SpielerListe.ColorStorageR = R;
                    SpielerListe.ColorStorageG = G;
                    SpielerListe.ColorStorageB = B;
                    SpielerListe.ColorStorageTacticsR = 255;
                    SpielerListe.ColorStorageTacticsG = 255;
                    SpielerListe.ColorStorageTacticsB = 255;
                    if (viplevel == "-") { VR = 255; VG = 255; VB = 255; }
                    if (viplevel == "Bronze") { VR = 205; VG = 127; VB = 50; }
                    if (viplevel == "Silber") { VR = 192; VG = 192; VB = 192; }
                    if (viplevel == "Gold") { VR = 218; VG = 165; VB = 32; }
                    if (viplevel == "Platin") { VR = 229; VG = 228; VB = 226; }
                    if (viplevel == "Ultimate RED") { VR = 175; VG = 0; VB = 0; }
                    if (viplevel == "Top Donator") { VR = 0; VG = 150; VB = 255; }
                    SpielerListe.ColorStorageVR = VR;
                    SpielerListe.ColorStorageVG = VG;
                    SpielerListe.ColorStorageVB = VB;
                }
                SpielerListe.LSPD = LSPD;
                SpielerListe.LCN = LCN;
                SpielerListe.YAKUZA = YAKUZA;
                SpielerListe.NEWS = NEWS;
                SpielerListe.FBI = FBI;
                SpielerListe.VL = VL;
                SpielerListe.USARMY = USARMY;
                SpielerListe.SAMCRO = SAMCRO;
                SpielerListe.MEDIC = MEDIC;
                SpielerListe.MECHANIKER = MECHANIKER;
                SpielerListe.BALLAS = BALLAS;
                SpielerListe.GROVE = GROVE;
                SpielerListe.TOTALPLAYERS = Alt.GetAllPlayers().Count;
            }
            catch { }
        }

        public static void DrawTacticScoreboard(Client Spieler)
        {
            try
            {
                int Spielzeit = 0;
                int R = 255;
                int G = 255;
                int B = 255;

                int kills = Spieler.Tactics.Kills;
                int tode = Spieler.Tactics.Deaths;

                if (Spieler.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) >= 0)
                {
                    Spielzeit = Spieler.Played;
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string playerping = Spieler.Ping.ToString();

                if (Spieler.Tactics.Team == _Gamemodes_.Tactics.Globals.EntityData.COPS_NAME)
                {
                    SpielerListe.FID = -2;
                    SpielerListe.FIDTactics = 20;
                    R = _Gamemodes_.Tactics.Globals.EntityData.COPS_Color.R;
                    G = _Gamemodes_.Tactics.Globals.EntityData.COPS_Color.G;
                    B = _Gamemodes_.Tactics.Globals.EntityData.COPS_Color.B;
                }
                else
                {
                    SpielerListe.FID = -3;
                    SpielerListe.FIDTactics = 30;
                    R = _Gamemodes_.Tactics.Globals.EntityData.BFAC_Color.R;
                    G = _Gamemodes_.Tactics.Globals.EntityData.BFAC_Color.G;
                    B = _Gamemodes_.Tactics.Globals.EntityData.BFAC_Color.B;
                }
                SpielerListe.SpielerName = Spieler.Username;
                SpielerListe.SpielzeitTactics = label;
                SpielerListe.SozialerStatusTactics = Spieler.Reallife.SocialState;
                SpielerListe.Spielzeit = "-";
                SpielerListe.SozialerStatus = "Tactics";
                SpielerListe.Fraktion = "-";
                SpielerListe.VIP = "-";
                SpielerListe.kills = kills.ToString();
                SpielerListe.tode = tode.ToString();
                SpielerListe.Ping = playerping;

                SpielerListe.ColorStorageTacticsR = R;
                SpielerListe.ColorStorageTacticsG = G;
                SpielerListe.ColorStorageTacticsB = B;
                SpielerListe.ColorStorageR = OtherLobbyColor.R;
                SpielerListe.ColorStorageG = OtherLobbyColor.G;
                SpielerListe.ColorStorageB = OtherLobbyColor.B;
                SpielerListe.ColorStorageVR = OtherLobbyColor.R;
                SpielerListe.ColorStorageVG = OtherLobbyColor.G;
                SpielerListe.ColorStorageVB = OtherLobbyColor.B;


            }
            catch { }
        }
        public static void DrawLobbyScoreboard(IPlayer Spieler)
        {
            try
            {
                int Spielzeit = 0;
                int R = 150;
                int G = 150;
                int B = 150;

                if (Spieler.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED) >= 0)
                {
                    Spielzeit = Spieler.vnxGetElementData<int>(VenoXV.Globals.EntityData.PLAYER_PLAYED);
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string playerping = Spieler.Ping.ToString();
                SpielerListe.FID = -2;

                //SpielerListe.SpielerName = Spieler.Username;
                SpielerListe.SpielerName = Spieler?.Name;
                SpielerListe.Spielzeit = "-";
                SpielerListe.SpielzeitTactics = "-";
                SpielerListe.SozialerStatus = "Lobby";
                SpielerListe.SozialerStatusTactics = "Lobby";
                SpielerListe.kills = "-";
                SpielerListe.tode = "-";
                SpielerListe.VIP = "-";
                SpielerListe.Fraktion = "-";
                SpielerListe.Ping = playerping;

                SpielerListe.ColorStorageTacticsR = R;
                SpielerListe.ColorStorageTacticsG = G;
                SpielerListe.ColorStorageTacticsB = B;

                SpielerListe.ColorStorageR = R;
                SpielerListe.ColorStorageG = G;
                SpielerListe.ColorStorageB = B;

            }
            catch { }
        }



        public static List<ScoreboardModel> GetAllPlayersScoreboard()
        {
            try
            {
                SpielerLi = new List<ScoreboardModel>();
                InitializeScoreboardStats();
                foreach (Client Spieler in Alt.GetAllPlayers())
                {
                    SpielerListe = new ScoreboardModel();
                    switch (Spieler.Gamemode)
                    {
                        case (int)_Preload_.Preload.Gamemodes.Tactics:
                            DrawTacticScoreboard(Spieler);
                            break;
                        case (int)_Preload_.Preload.Gamemodes.Reallife:
                            DrawReallifeScoreboard(Spieler);
                            break;
                        default:
                            DrawLobbyScoreboard(Spieler);
                            break;
                    }
                    SpielerLi.Add(SpielerListe);
                }
            }
            catch { }
            return SpielerLi;
        }
        public static void Fill_Playerlist(object unused)
        {
            try
            {
                List<ScoreboardModel> AlleSpieler = GetAllPlayersScoreboard();
                foreach (Client player in Alt.GetAllPlayers())
                {
                    Alt.Server.TriggerClientEvent(player,"UpdateScoreboard_Event", JsonConvert.SerializeObject(AlleSpieler));
                }
            }
            catch
            {

            }
        }
    }
}
