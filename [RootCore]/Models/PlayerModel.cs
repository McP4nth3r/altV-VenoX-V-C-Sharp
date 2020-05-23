using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Reallife
    {
        private Player Player;
        public int Money { get { return Player.vnxGetElementData<int>(Globals.EntityData.PLAYER_MONEY); } set { Player.vnxSetElementData(Globals.EntityData.PLAYER_MONEY, value); } }
        public int Bank { get { return Player.vnxGetElementData<int>(Globals.EntityData.PLAYER_BANK); } set { Player.vnxSetElementData(Globals.EntityData.PLAYER_BANK, value); } }
        public string SocialState { get { return Player.vnxGetElementData<string>(Globals.EntityData.PLAYER_STATUS); } set { Player.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_STATUS, value); } }
        public int Faction { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION); } set { Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION, value); } }
        public int REALLIFE_HUD { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REALLIFE_HUD); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REALLIFE_HUD, value); } }
        public DateTime Zivizeit { get { return Player.vnxGetElementData<DateTime>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ZIVIZEIT); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ZIVIZEIT, value); } }
        public string REALLIFE_JOB { get { return Player.vnxGetElementData<string>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_JOB); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_JOB, value); } }
        public int LIEFERJOB_LEVEL { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_LIEFERJOB_LEVEL); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_LIEFERJOB_LEVEL, value); } }
        public int AIRPORTJOB_LEVEL { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_AIRPORTJOB_LEVEL); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_AIRPORTJOB_LEVEL, value); } }
        public int BUSJOB_LEVEL { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_BUSJOB_LEVEL); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_BUSJOB_LEVEL, value); } }
        public int FactionRank { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION_RANK); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FACTION_RANK, value); } }
        public int OnDuty { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY, value); } }
        public int OnDutyBad { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY_BAD); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY_BAD, value); } }
        public int OnDutyNeutral { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY_NEUTRAL); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ON_DUTY_NEUTRAL, value); } }
        public int HouseRent { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_RENT_HOUSE); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_RENT_HOUSE, value); } }
        public int HouseEntered { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HOUSE_ENTERED); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HOUSE_ENTERED, value); } }
        public int BusinessEntered { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_BUSINESS_ENTERED); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_BUSINESS_ENTERED, value); } }
        public int Personalausweis { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PERSONALAUSWEIS); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PERSONALAUSWEIS, value); } }
        public int Autofuehrerschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FÜHRERSCHEIN, value); } }
        public int Motorradfuehrerschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_MOTORRAD_FÜHRERSCHEIN, value); } }
        public int LKWfuehrerschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_LKW_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_LKW_FÜHRERSCHEIN, value); } }
        public int Helikopterfuehrerschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HELIKOPTER_FÜHRERSCHEIN, value); } }
        public int FlugscheinKlasseA { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FLUGSCHEIN_A_FÜHRERSCHEIN, value); } }
        public int FlugscheinKlasseB { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_FLUGSCHEIN_B_FÜHRERSCHEIN, value); } }
        public int Motorbootschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_MOTORBOOT_FÜHRERSCHEIN, value); } }
        public int Angelschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ANGEL_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ANGEL_FÜHRERSCHEIN, value); } }
        public int Waffenschein { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WAFFEN_FÜHRERSCHEIN, value); } }
        public string SpawnLocation { get { return Player.vnxGetElementData<string>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_SPAWNPOINT); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_SPAWNPOINT, value); } }
        public int Quests { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUESTS); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUESTS, value); } }
        public int Wanteds { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS); } set { Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS, value); } }
        public int Knastzeit { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KNASTZEIT); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KNASTZEIT, value); } }
        public int Kaution { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KAUTION); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KAUTION, value); } }
        public int Adventskalender { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ADVENTSKALENEDER); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ADVENTSKALENEDER, value); } }
        public Reallife(Player player)
        {
            try
            {
                Player = player;
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                Money = 0;
                Faction = 0;
                Zivizeit = DateTime.Now;
                REALLIFE_JOB = "-";
                LIEFERJOB_LEVEL = 0;
                BUSJOB_LEVEL = 0;
                AIRPORTJOB_LEVEL = 0;
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
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }
    public class Tactics
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public bool Joined { get; set; }
        public bool IsDead { get; set; }
        public bool Spawned { get; set; }
        public int CurrentDamage { get; set; }
        public int CurrentKills { get; set; }
        public int CurrentStreak { get; set; }
        public string Team { get; set; }
        public Tactics(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }
    public class Zombies
    {
        public int Zombie_kills { get; set; }
        public int Zombie_player_kills { get; set; }
        public int Zombie_tode { get; set; }

        public Zombies(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }
    public class Race
    {

    }
    public class SevenTowers
    {
        public bool Spawned { get; set; }
        public SevenTowers(Player player)
        {
            try
            {

            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }
    public class Settings
    {
        private Player Player;
        public int ShowATM { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ATM_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS, value); } }
        public int ShowHouse { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HAUS_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HAUS_ANZEIGEN, value); } }
        public int ShowSpeedo { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_TACHO_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_TACHO_ANZEIGEN, value); } }
        public int ShowQuests { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUEST_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUEST_ANZEIGEN, value); } }
        public int ShowReporter { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REPORTER_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REPORTER_ANZEIGEN, value); } }
        public int ShowGlobalChat { get { return Player.vnxGetElementData<int>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_GLOBALCHAT_ANZEIGEN); } set { Player.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_GLOBALCHAT_ANZEIGEN, value); } }

        public Settings(Player player)
        {
            try
            {
                Player = player;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }
    public class Client : Player
    {
        //Main
        public int UID { get; set; }
        public string Username { get { return this.vnxGetElementData<string>(Globals.EntityData.PLAYER_NAME); } set { this.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_NAME, value); } }
        public int AdminRank { get { return this.vnxGetElementData<int>(Globals.EntityData.PLAYER_ADMIN_RANK); } set { this.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_ADMIN_RANK, value); } }
        public int Language { get; set; }

        // Gamemode Classes
        public Reallife Reallife { get; }
        public Zombies Zombies { get; }
        public Tactics Tactics { get; }
        public SevenTowers SevenTowers { get; }
        public Race Race { get; }


        // Settings - Classes
        public Settings Settings { get; }
        public Position SetPosition
        { set { Alt.Emit("GlobalSystems:PlayerPosition", this, value); } }
        public int Sex { get { return this.vnxGetElementData<int>(Globals.EntityData.PLAYER_SEX); } set { this.vnxSetElementData(Globals.EntityData.PLAYER_SEX, value); } }
        public int Gamemode { get { return this.vnxGetElementData<int>(Globals.EntityData.PLAYER_CURRENT_GAMEMODE); } set { this.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, value); } }
        public int Dead { get { return this.vnxGetElementData<int>(Globals.EntityData.PLAYER_DEAD); } set { this.vnxSetElementData(Globals.EntityData.PLAYER_DEAD, value); } }
        public int Played { get { return this.vnxGetElementData<int>(Globals.EntityData.PLAYER_PLAYED); } set { this.vnxSetElementData(Globals.EntityData.PLAYER_PLAYED, value); } }
        public bool Playing { get { return this.vnxGetElementData<bool>(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PLAYING); } set { this.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PLAYING, value); } }
        public string Vip_Paket { get; set; }
        public DateTime Vip_BisZum { get; set; }
        public DateTime Vip_GekauftAm { get; set; }
        public Client(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            try
            {
                Settings = new Settings(this);
                Reallife = new Reallife(this);
                Tactics = new Tactics(this);
                Zombies = new Zombies(this);
                SevenTowers = new SevenTowers(this);
                this.SpawnPlayer(Position);
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                SetPosition = new Position(152.26f, -1004.47f, -99.00f);
                Dimension = Id;
                Health = 200;
                Armor = 0;
                this.RemoveAllPlayerWeapons();
                this.vnxSetStreamSharedElementData("settings_reporter", "ja");
                this.vnxSetStreamSharedElementData("settings_globalchat", "ja");
                this.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
                this.vnxSetStreamSharedElementData("HideHUD", 1);
                this.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HUNGER, 60);
                this.vnxSetElementData(_Gamemodes_.Reallife.Vehicles.Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);
                Username = "Random-Player";
                Playing = false;
                AdminRank = 0;
                Dead = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerModel-Create", ex); }
        }
    }

    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr playerPointer, ushort id)
        {
            try
            {
                return new Client(playerPointer, id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions("PlayerFactory:Create", ex); return null; }
        }
    }
}

