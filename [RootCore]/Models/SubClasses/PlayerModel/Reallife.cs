using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class DrivingSchool
    {
        public int MarkerStage { get; set; }
        public DrivingSchool(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Reallife
    {
        private Player client;
        public DrivingSchool DrivingSchool { get; }
        private int _Money { get; set; }
        public int Money { get { return _Money; } set { _Money = value; client.vnxSetSharedElementData(Globals.EntityData.PLAYER_MONEY, value); } }
        private int _Bank { get; set; }
        public int Bank { get { return _Bank; } set { _Bank = value; client.vnxSetSharedElementData(Globals.EntityData.PLAYER_BANK, value); } }
        private string _SocialState { get; set; }
        public string SocialState { get { return _SocialState; } set { _SocialState = value; client.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_STATUS, value); } }
        private int _Faction { get; set; }
        public int Faction { get { return _Faction; } set { _Faction = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION, value); client.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION, value); } }
        private int _HUD { get; set; }
        public int HUD { get { return _HUD; } set { _HUD = value; client.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REALLIFE_HUD, value); } }
        private int _Hunger { get; set; }
        public int Hunger { get { return _Hunger; } set { _Hunger = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HUNGER, value); } }
        public int JobStage { get; set; }
        public int JobMarker { get; set; }
        public DateTime LastFactionTeleport { get; set; }
        public DateTime Zivizeit { get; set; }
        public string Job { get; set; }
        public int LIEFERJOB_LEVEL { get; set; }
        public int AIRPORTJOB_LEVEL { get; set; }
        public int BUSJOB_LEVEL { get; set; }
        public int FactionRank { get; set; }
        public int OnDuty { get; set; }
        public int OnDutyBad { get; set; }
        public int OnDutyNeutral { get; set; }
        public int HouseRent { get; set; }
        public string HouseIPL { get; set; }
        public int HouseEntered { get; set; }
        public int BusinessEntered { get; set; }
        public int Personalausweis { get; set; }
        public int Autofuehrerschein { get; set; }
        public int Motorradfuehrerschein { get; set; }
        public int LKWfuehrerschein { get; set; }
        public int Helikopterfuehrerschein { get; set; }
        public int FlugscheinKlasseA { get; set; }
        public int FlugscheinKlasseB { get; set; }
        public int Motorbootschein { get; set; }
        public int Angelschein { get; set; }
        public int Waffenschein { get; set; }
        public string SpawnLocation { get; set; }
        //private int _Quests { get; set; }
        public int Quests { get; set; }
        private int _Wanteds { get; set; }
        public int Wanteds { get { return _Wanteds; } set { _Wanteds = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS, value); client.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS, value); } }
        private int _Knastzeit { get; set; }
        public int Knastzeit { get { return _Knastzeit; } set { _Knastzeit = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KNASTZEIT, value); } }
        private int _Kaution { get; set; }
        public int Kaution { get { return _Kaution; } set { _Kaution = value; client.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KAUTION, value); } }
        public int Adventskalender { get; set; }
        private bool _Handcuffed { get; set; }
        public bool Handcuffed
        {
            get { return _Handcuffed; }
            set { _Handcuffed = value; VenoX.TriggerClientEvent((VnXPlayer)client, "toggleHandcuffed", value); }
        }
        public bool IsDead { get; set; }
        public Reallife(Player player)
        {
            try
            {
                client = player;
                DrivingSchool = new DrivingSchool(player);
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                Money = 0;
                HUD = 0;
                Hunger = 100;
                Faction = 0;
                Zivizeit = DateTime.Now;
                Job = "-";
                LIEFERJOB_LEVEL = 0;
                BUSJOB_LEVEL = 0;
                AIRPORTJOB_LEVEL = 0;
                JobStage = 0;
                OnDuty = 0;
                OnDutyBad = 0;
                OnDutyNeutral = 0;
                HouseRent = 0;
                HouseEntered = 0;
                BusinessEntered = 0;
                Personalausweis = 0;
                Autofuehrerschein = 0;
                Motorradfuehrerschein = 0;
                LKWfuehrerschein = 0;
                Helikopterfuehrerschein = 0;
                FlugscheinKlasseA = 0;
                FlugscheinKlasseB = 0;
                Motorbootschein = 0;
                Angelschein = 0;
                Waffenschein = 0;
                Adventskalender = 0;
                Adventskalender = 0;
                SocialState = "VenoX";
                SpawnLocation = "noobspawn";
                Quests = 0;
                Faction = 0;
                Wanteds = 0;
                Knastzeit = 0;
                Kaution = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
