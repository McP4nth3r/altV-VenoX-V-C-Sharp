using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class VnXPlayer : Player
    {

        //Main
        private int _UID { get; set; }
        public int UID { get { return _UID; } set { _UID = value; this.vnxSetStreamSharedElementData(_Globals_.EntityData.PLAYER_UID, value); } }
        private string _Username { get; set; }
        public string Username { get { return _Username; } set { _Username = value; this.vnxSetStreamSharedElementData(_Globals_.EntityData.PLAYER_NAME, value); } }
        private int _AdminRank { get; set; }
        public int AdminRank { get { return _AdminRank; } set { _AdminRank = value; this.vnxSetStreamSharedElementData(_Globals_.EntityData.PLAYER_ADMIN_RANK, value); } }
        public int Language { get; set; }
        // Gamemode Classes
        public Reallife Reallife { get; }
        public Zombies Zombies { get; }
        public Tactics Tactics { get; }
        public SevenTowers SevenTowers { get; }
        public Race Race { get; }
        public Inventory Inventory { get; }
        public Shooter Shooter { get; }
        public Phone Phone { get; }
        public Discord Discord { get; }
        public Forum Forum { get; }
        public SyncClass Sync { get; }
        public Usefull Usefull { get; }
        // Settings - Classes
        public Settings Settings { get; }
        public Position SetPosition { set => Alt.Emit("GlobalSystems:PlayerPosition", this, value); }
        private int _Sex { get; set; }
        public int Sex { get { return _Sex; } set { _Sex = value; } }
        private int _Gamemode { get; set; }
        public int Gamemode { get { return _Gamemode; } set { _Gamemode = value; this.vnxSetElementData(_Globals_.EntityData.PLAYER_CURRENT_GAMEMODE, value); } }
        public int Dead { get; set; }
        private int _Played { get; set; }
        public int Played { get { return _Played; } set { _Played = value; } }
        private bool _Playing { get; set; }
        public bool Playing { get { return _Playing; } set { _Playing = value; this.vnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PLAYER_PLAYING, value); } }
        public string Vip_Paket { get; set; }
        public void DrawWaypoint(float PosX, float PosY) { try { VenoX.TriggerClientEvent(this, "Player:SetWaypoint", PosX, PosY); } catch { } }
        public void SetTeam(int Team) { try { Alt.Emit("GlobalSystems:PlayerTeam", this, Team); } catch { } }
        private bool _Freeze { get; set; }
        public bool Freeze { get { return _Freeze; } set { _Freeze = value; VenoX.TriggerClientEvent(this, "Player:Freeze", value); } }
        public void FreezeAfterMS(int MS, bool value) { try { VenoX.TriggerClientEvent(this, "Player:FreezeAfterMS", MS, value); _Freeze = value; } catch { } }
        public void LoadIPL(string IPL) { try { VenoX.TriggerClientEvent(this, "Player:LoadIPL", IPL); } catch { } }
        public DateTime Vip_BisZum { get; set; }
        public DateTime Vip_GekauftAm { get; set; }
        public List<VnXPlayer> NearbyPlayers { get; set; }
        public ushort SetArmor { get { return Armor; } set { this.vnxSetStreamSharedElementData("PLAYER_ARMOR", value); Armor = value; } }
        public ushort SetHealth { get { return Health; } set { this.vnxSetStreamSharedElementData("PLAYER_HEALTH", value); Health = value; } }
        public List<LoadingModel> PreloadEvents { get; set; }
        public bool Loading { get; set; }
        public bool FinishedPrivacyPolicy { get; set; }
        public bool LoggedInWithShaPassword { get; set; }
        public VnXPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            try
            {
                //Preload : 
                PreloadEvents = new List<LoadingModel>();
                //
                NearbyPlayers = new List<VnXPlayer>();
                Settings = new Settings(this);
                Reallife = new Reallife(this);
                Tactics = new Tactics(this);
                Zombies = new Zombies(this);
                Race = new Race(this);
                Inventory = new Inventory(this);
                SevenTowers = new SevenTowers(this);
                Shooter = new Shooter(this);
                Phone = new Phone(this);
                Forum = new Forum(this);
                Usefull = new Usefull(this);
                Discord = new Discord(this);
                Sync = new SyncClass(this);
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
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
            catch (Exception ex) { Debug.CatchExceptions(ex); return null; }
        }
    }
}