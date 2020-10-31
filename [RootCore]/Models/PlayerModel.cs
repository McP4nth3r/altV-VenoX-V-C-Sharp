using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Zombie.Models;
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
        public int Wanteds { get { return _Wanteds; } set { _Wanteds = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_WANTEDS, value); } }
        public int _Knastzeit { get; set; }
        public int Knastzeit { get { return _Knastzeit; } set { _Knastzeit = value; client.vnxSetSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KNASTZEIT, value); } }
        private int _Kaution { get; set; }
        public int Kaution { get { return _Kaution; } set { _Kaution = value; client.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_KAUTION, value); } }
        public int Adventskalender { get; set; }
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
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Zombies
    {
        private Player client;
        private int _Zombie_kills { get; set; }
        public int Zombie_kills { get { return _Zombie_kills; } set { _Zombie_kills = value; client.vnxSetSharedElementData("ZOMBIE_KILLS", value); } }
        public int Zombie_player_kills { get; set; }
        public int Zombie_tode { get; set; }
        public bool IsSyncer { get; set; }
        public List<Player> NearbyPlayers { get; set; }
        public List<ZombieModel> NearbyZombies { get; set; }
        public Zombies(Player player)
        {
            try
            {
                client = player;
                NearbyPlayers = new List<Player>();
                NearbyZombies = new List<ZombieModel>();
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Race
    {
        private Player Player;
        public bool IsRacing { get; set; }
        public int RoundPlace { get; set; }
        public int CurrentMarker { get; set; }
        public MarkerModel LastMarker { get; set; }
        public ColShapeModel LastColShapeModel { get; set; }
        public Race(Player player)
        {
            try
            {
                Player = player;
                IsRacing = false;
                RoundPlace = 0;
                CurrentMarker = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class SevenTowers
    {
        public int Wins { get; set; }
        public bool Spawned { get; set; }
        public DateTime SpawnedTime { get; set; }
        public DateTime LastVehicleGot { get; set; }
        public SevenTowers(Player player)
        {
            try
            {
                SpawnedTime = DateTime.Now;
                LastVehicleGot = DateTime.Now;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Settings
    {
        private Player Player;
        private int _ShowATM { get; set; }
        public int ShowATM { get { return _ShowATM; } set { _ShowATM = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_ATM_ANZEIGEN, value); } }
        private int _ShowHouse { get; set; }
        public int ShowHouse { get { return _ShowHouse; } set { _ShowHouse = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_HAUS_ANZEIGEN, value); } }
        private int _ShowSpeedo { get; set; }
        public int ShowSpeedo { get { return _ShowSpeedo; } set { _ShowSpeedo = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_TACHO_ANZEIGEN, value); } }
        private int _ShowQuests { get; set; }
        public int ShowQuests
        {
            get { return _ShowQuests; }
            set
            {
                _ShowQuests = value;
                try
                {
                    if (value == 1) Player.Emit("Quests:Show", true);
                    else Player.Emit("Quests:Show", false);
                    Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_QUEST_ANZEIGEN, value);
                }
                catch { }
            }
        }
        private int _ShowReporter { get; set; }
        public int ShowReporter { get { return _ShowReporter; } set { _ShowReporter = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_REPORTER_ANZEIGEN, value); } }
        private int _ShowGlobalChat { get; set; }
        public int ShowGlobalChat { get { return _ShowGlobalChat; } set { _ShowGlobalChat = value; Player.vnxSetStreamSharedElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_GLOBALCHAT_ANZEIGEN, value); } }

        public Settings(Player player)
        {
            try
            {
                Player = player;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Phone
    {
        private Player Player;
        public int Number { get; set; }
        public bool IsCallActive { get; set; }
        public Phone(Player player)
        {
            try
            {
                Player = player;

            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Discord
    {
        private Player Player;
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string Avatar { get; set; }
        public string Discriminator { get; set; }

        public Discord(Player player)
        {
            try
            {
                Player = player;
                ID = String.Empty;
                Name = String.Empty;
                IsOpen = false;
                Avatar = String.Empty;
                Discriminator = String.Empty;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class Forum
    {
        private Player Player;
        public int UID { get; set; }
        public Forum(Player player)
        {
            try
            {
                Player = player;
                UID = -1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

    public class Usefull
    {
        public DateTime LastVehicleLeaveEventCall { get; set; }
        public Usefull(Player player)
        {
            try
            {
                LastVehicleLeaveEventCall = DateTime.Now;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class VnXPlayer : Player
    {
        //Main
        public int UID { get; set; }
        private string _Username { get; set; }
        public string Username { get { return _Username; } set { _Username = value; this.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_NAME, value); } }
        private int _AdminRank { get; set; }
        public int AdminRank { get { return _AdminRank; } set { _AdminRank = value; this.vnxSetStreamSharedElementData(Globals.EntityData.PLAYER_ADMIN_RANK, value); } }
        public int Language { get; set; }
        // Gamemode Classes
        public Reallife Reallife { get; }
        public Zombies Zombies { get; }
        public Tactics Tactics { get; }
        public SevenTowers SevenTowers { get; }
        public Race Race { get; }
        public Phone Phone { get; }
        public Discord Discord { get; }
        public Forum Forum { get; }
        public Usefull Usefull { get; }
        // Settings - Classes
        public Settings Settings { get; }
        public Position SetPosition { set { Alt.Emit("GlobalSystems:PlayerPosition", this, value); } }
        private int _Sex { get; set; }
        public int Sex { get { return _Sex; } set { _Sex = value; } }
        private int _Gamemode { get; set; }
        public int Gamemode { get { return _Gamemode; } set { _Gamemode = value; this.vnxSetElementData(Globals.EntityData.PLAYER_CURRENT_GAMEMODE, value); } }
        public int Dead { get; set; }
        private int _Played { get; set; }
        public int Played { get { return _Played; } set { _Played = value; } }
        private bool _Playing { get; set; }
        public bool Playing { get { return _Playing; } set { _Playing = value; this.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PLAYING, value); } }
        public string Vip_Paket { get; set; }
        public void DrawWaypoint(float PosX, float PosY) { try { Alt.Server.TriggerClientEvent(this, "Player:SetWaypoint", PosX, PosY); } catch { } }
        public void SetTeam(int Team) { try { Alt.Emit("GlobalSystems:PlayerTeam", this, Team); } catch { } }
        private bool _Freeze { get; set; }
        public bool Freeze { get { return _Freeze; } set { _Freeze = value; Alt.Server.TriggerClientEvent(this, "Player:Freeze", value); } }
        public void FreezeAfterMS(int MS, bool value) { try { Alt.Server.TriggerClientEvent(this, "Player:FreezeAfterMS", MS, value); _Freeze = value; } catch { } }
        public void LoadIPL(string IPL) { try { Alt.Server.TriggerClientEvent(this, "Player:LoadIPL", IPL); } catch { } }
        public DateTime Vip_BisZum { get; set; }
        public DateTime Vip_GekauftAm { get; set; }
        public ushort SetArmor { get { return Armor; } set { this.vnxSetStreamSharedElementData("PLAYER_ARMOR", value); Armor = value; } }
        public ushort SetHealth { get { return Health; } set { this.vnxSetStreamSharedElementData("PLAYER_HEALTH", value); Health = value; } }
        public VnXPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            try
            {
                Settings = new Settings(this);
                Reallife = new Reallife(this);
                Tactics = new Tactics(this);
                Zombies = new Zombies(this);
                Race = new Race(this);
                SevenTowers = new SevenTowers(this);
                Phone = new Phone(this);
                Forum = new Forum(this);
                Usefull = new Usefull(this);
                Discord = new Discord(this);
                this.SpawnPlayer(Position);
                Language = (int)_Language_.Main.Languages.English;
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                SetPosition = new Position(152.26f, -1004.47f, -99.00f);
                Dimension = Id;
                SetHealth = 200;
                SetArmor = 0;
                Reallife.Hunger = 60;
                this.RemoveAllPlayerWeapons();
                this.vnxSetStreamSharedElementData("settings_reporter", "ja");
                this.vnxSetStreamSharedElementData("settings_globalchat", "ja");
                this.vnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
                this.vnxSetElementData(_Gamemodes_.Reallife.Vehicles.Verleih.HAVE_PLAYER_RENTED_VEHICLE, 0);
                Username = "Random-Player";
                Playing = false;
                AdminRank = 0;
                Dead = 0;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
    public class MyPlayerFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr playerPointer, ushort id)
        {
            try
            {
                return new VnXPlayer(playerPointer, id);
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); return null; }
        }
    }
}