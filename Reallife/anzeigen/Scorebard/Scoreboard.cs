using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VenoXV.Reallife.Core;
using VenoXV.Reallife.factions;
using VenoXV.Reallife.Globals;
using VenoXV.Reallife.model;

namespace VenoXV.Reallife.anzeigen.Scorebard
{
    public class Scoreboard : IScript 
    {
        public static List<ScoreboardModel> SpielerLi;
        public static ScoreboardModel SpielerListe;
        public static Rgba OtherLobbyColor = new Rgba(180, 180, 180, 255);

        public static void DrawReallifeScoreboard(IPlayer Spieler)
        {
            try
            {
                int LSPD = 0;
                int LCN = 0;
                int YAKUZA = 0;
                int NEWS = 0;
                int FBI = 0;
                int VL = 0;
                int USARMY = 0;
                int SAMCRO = 0;
                int MEDIC = 0;
                int MECHANIKER = 0;
                int BALLAS = 0;
                int GROVE = 0;
                int TOTALPLAYERS = 0;
                int Spielzeit = 0;
                int Fraktion = 0;
                if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED) >= 0)
                {
                    Spielzeit = Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                }
                if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) >= 0)
                {
                    Fraktion = Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string factionname = Faction.GetPlayerFactionName(Fraktion);
                if (Fraktion == Constants.FACTION_POLICE)
                {
                    factionname = "L.S.P.D";
                }
                if (Fraktion == Constants.FACTION_FBI)
                {
                    factionname = "F.I.B";
                }
                string playerping = Spieler.Ping.ToString();
                int FraktionsID = Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION);
                string viplevel = Spieler.vnxGetElementData<string>(EntityData.PLAYER_VIP_LEVEL);
                if (Spieler.vnxGetElementData<bool>(EntityData.PLAYER_PLAYING) == false && Spieler.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_GAMEMODE) == globals.EntityData.GAMEMODE_REALLIFE)
                {
                    SpielerListe.FID = -1;
                    SpielerListe.SpielerName = Spieler.GetVnXName<string>();
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
                    SpielerListe.SpielerName = Spieler.GetVnXName<string>();
                    SpielerListe.Spielzeit = label;
                    SpielerListe.SpielzeitTactics = "-";
                    SpielerListe.VIP = viplevel;
                    SpielerListe.SozialerStatus = Spieler.vnxGetElementData<string>(EntityData.PLAYER_STATUS);
                    SpielerListe.SozialerStatusTactics = "Reallife";
                    SpielerListe.kills = "-";
                    SpielerListe.tode = "-";
                    SpielerListe.Fraktion = factionname;
                    SpielerListe.Ping = playerping;
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_POLICE) { R = 0; G = 140; B = 183; LSPD += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_COSANOSTRA) { R = 120; G = 120; B = 120; LCN += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_YAKUZA) { R = 255; G = 4; B = 4; YAKUZA += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_NEWS) { R = 180; G = 130; B = 0; NEWS += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_FBI) { R = 0; G = 86; B = 184; FBI += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_MS13) { R = 128; G = 129; B = 150; VL += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_USARMY) { R = 0; G = 100; B = 0; USARMY += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_SAMCRO) { R = 100; G = 50; B = 50; SAMCRO += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_EMERGENCY) { R = 255; G = 51; B = 51; MEDIC += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_MECHANIK) { R = 255; G = 100; B = 0; MECHANIKER += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_BALLAS) { R = 138; G = 43; B = 226; BALLAS += 1; }
                    if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_FACTION) == Constants.FACTION_GROVE) { R = 0; G = 152; B = 0; GROVE += 1; }
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
                TOTALPLAYERS += 1;
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
                SpielerListe.TOTALPLAYERS = TOTALPLAYERS;
            }
            catch { }
        }

        public static void DrawTacticScoreboard(IPlayer Spieler)
        {
            try
            {
                int Spielzeit = 0;
                int R = 255;
                int G = 255;
                int B = 255;

                int kills = Spieler.vnxGetElementData<int>(EntityData.PLAYER_TACTIC_KILLS);
                int tode = Spieler.vnxGetElementData<int>(EntityData.PLAYER_TACTIC_TODE);

                if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED) >= 0)
                {
                    Spielzeit = Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string playerping = Spieler.Ping.ToString();

                if(Spieler.vnxGetElementData<string>(Tactics.globals.EntityData.PLAYER_CURRENT_TEAM) == Tactics.globals.EntityData.COPS_NAME)
                {
                    SpielerListe.FID = -2;
                    SpielerListe.FIDTactics = 20;
                    R = Tactics.globals.EntityData.COPS_Color.R;
                    G = Tactics.globals.EntityData.COPS_Color.G;
                    B = Tactics.globals.EntityData.COPS_Color.B;
                }
                else
                {
                    SpielerListe.FID = -3;
                    SpielerListe.FIDTactics = 30;
                    R = Tactics.globals.EntityData.BFAC_Color.R;
                    G = Tactics.globals.EntityData.BFAC_Color.G;
                    B = Tactics.globals.EntityData.BFAC_Color.B;
                }
                SpielerListe.SpielerName = Spieler.GetVnXName<string>();
                SpielerListe.SpielzeitTactics = label;
                SpielerListe.SozialerStatusTactics = Spieler.vnxGetElementData<string>(EntityData.PLAYER_STATUS);                
                SpielerListe.Spielzeit= "-";
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

                if (Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED) >= 0)
                {
                    Spielzeit = Spieler.vnxGetElementData<int>(EntityData.PLAYER_PLAYED);
                }
                TimeSpan spielzeittab = TimeSpan.FromMinutes(Spielzeit);
                string label = string.Format("{0:00}:{1:00}", (int)spielzeittab.TotalHours, spielzeittab.Minutes);

                string playerping = Spieler.Ping.ToString();
                SpielerListe.FID = -2;

                SpielerListe.SpielerName = Spieler.GetVnXName<string>();
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
                foreach (IPlayer Spieler in Alt.GetAllPlayers())
                {
                    SpielerListe = new ScoreboardModel();
                    if (Spieler.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_TACTICS)
                    {
                        DrawTacticScoreboard(Spieler);
                    }              
                    else if(Spieler.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_REALLIFE)
                    {
                        DrawReallifeScoreboard(Spieler);
                    }                    
                    else if(Spieler.vnxGetElementData<string>(globals.EntityData.PLAYER_CURRENT_GAMEMODE) == VenoXV.globals.EntityData.GAMEMODE_NONE)
                    {
                        DrawLobbyScoreboard(Spieler);
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
                foreach (IPlayer player in Alt.GetAllPlayers())
                {
                    player.Emit("UpdateScoreboard_Event", JsonConvert.SerializeObject(AlleSpieler));
                }
            }
            catch
            {

            }
        }
    }
}
