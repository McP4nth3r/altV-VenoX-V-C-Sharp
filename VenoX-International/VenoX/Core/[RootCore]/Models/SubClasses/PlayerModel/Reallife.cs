using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoX.Core._Globals_;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
{
    public class DrivingSchool
    {
        public int MarkerStage { get; set; }
        public DrivingSchool(Player player)
        {
            try
            {

            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
    public class Reallife
    {
        private readonly Player _client;
        public DrivingSchool DrivingSchool { get; }
        public Vector3 LastPosition { get; set; }
        private int _money { get; set; }
        public int Money { get => _money;
            set { _money = value; _client.VnxSetSharedElementData(EntityData.PlayerMoney, value); } }
        private int _bank { get; set; }
        public int Bank { get => _bank;
            set { _bank = value; _client.VnxSetSharedElementData(EntityData.PlayerBank, value); } }
        private string _SocialState { get; set; }
        public string SocialState { get => _SocialState;
            set { _SocialState = value; _client.VnxSetStreamSharedElementData(EntityData.PlayerStatus, value); } }
        private int _Faction { get; set; }
        public int Faction { get => _Faction;
            set { _Faction = value; _client.VnxSetSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerFaction, value); _client.VnxSetStreamSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerFaction, value); } }
        private int _Hunger { get; set; }
        public int Hunger { get => _Hunger;
            set { _Hunger = value; _client.VnxSetSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerHunger, value); } }
        public int JobStage { get; set; }
        public int JobMarker { get; set; }
        public DateTime LastFactionTeleport { get; set; }
        public string Job { get; set; }
        public int TruckerJobLevel { get; set; }
        public int AirportJobLevel { get; set; }
        public int BusJobLevel { get; set; }
        public int FactionRank { get; set; }
        public int OnDuty { get; set; }
        public int OnDutyBad { get; set; }
        public int OnDutyNeutral { get; set; }
        public int HouseRent { get; set; }
        public string HouseIpl { get; set; }
        public int HouseEntered { get; set; }
        public int BusinessEntered { get; set; }
        public int IDCard { get; set; }
        public int DrivingLicense { get; set; }
        public int BikeDrivingLicense { get; set; }
        public int TruckDrivingLicense { get; set; }
        public int HelicopterDrivingLicense { get; set; }
        public int FlyLicenseA { get; set; }
        public int FlyLicenseB { get; set; }
        public int MotorBoatDrivingLicense { get; set; }
        public int FishingLicense { get; set; }
        public int WeaponLicense { get; set; }
        public string SpawnLocation { get; set; }
        //private int _Quests { get; set; }
        public int Quests { get; set; }
        private int _wantedStars { get; set; }
        public int WantedStars { get => _wantedStars;
            set { _wantedStars = value; _client.VnxSetSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerWanteds, value); _client.VnxSetStreamSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerWanteds, value); } }
        private int _jailTime { get; set; }
        public int PrisonTime { get => _jailTime;
            set { _jailTime = value; _client.VnxSetSharedElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerKnastzeit, value); } }
        private int _bail { get; set; }
        public int PrisonBail { get => _bail;
            set { _bail = value; _client.VnxSetElementData(_Gamemodes_.Reallife.globals.EntityData.PlayerKaution, value); } }
        public int AdventCalender { get; set; }
        private bool _handcuffed { get; set; }
        public bool Handcuffed
        {
            get => _handcuffed;
            set { _handcuffed = value; VenoX.TriggerClientEvent((VnXPlayer)_client, "toggleHandcuffed", value); }
        }

        public Reallife(Player player)
        {
            try
            {
                _client = player;
                DrivingSchool = new DrivingSchool(player);
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                Money = 0;
                Hunger = 100;
                Faction = 0;
                Job = "-";
                JobStage = 0;
                OnDuty = 0;
                OnDutyBad = 0;
                OnDutyNeutral = 0;
                SocialState = "VenoX";
                SpawnLocation = "noobspawn";
                Quests = 0;
                Faction = 0;
                WantedStars = 0;
                PrisonTime = 0;
                PrisonBail = 0;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }
}
