using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.Vehicles;
using VenoXV._Globals_;
using VenoXV._RootCore_.Models;
using VenoXV.Core;
using VenoXV.Models.SubClasses.PlayerModel;
using Main = VenoXV._Language_.Main;

namespace VenoXV.Models
{
    public class VnXPlayer : Player
    {
        //Main
        private int _UID { get; set; }
        public int UID { get => _UID;
            set { _UID = value; this.VnxSetStreamSharedElementData(EntityData.PlayerUid, value); } }

        private string _Username { get; set; }

        public string Username { get => _Username;
            set { _Username = value; this.VnxSetStreamSharedElementData(EntityData.PlayerName, value); } }

        private int _AdminRank { get; set; }

        public int AdminRank { get => _AdminRank;
            set { _AdminRank = value; this.VnxSetStreamSharedElementData(EntityData.PlayerAdminRank, value); } }

        public int Language { get; set; }

        // Gamemode Classes
        public _RootCore_.Models.Reallife Reallife { get; }

        public Zombies Zombies { get; }

        public Tactics Tactics { get; }

        public _RootCore_.Models.SevenTowers SevenTowers { get; }

        public Race Race { get; }

        public Inventory Inventory { get; }

        public Shooter Shooter { get; }

        public Phone Phone { get; }

        public _RootCore_.Models.Discord Discord { get; }

        public Forum Forum { get; }

        public SyncClass Sync { get; }

        public Usefull Usefull { get; }

        // Settings - Classes
        public Settings Settings { get; }

        public Position SetPosition { set => Alt.Emit("GlobalSystems:PlayerPosition", this, value); }

        private int _Sex { get; set; }

        public int Sex { get => _Sex;
            set => _Sex = value;
        }

        private int _Gamemode { get; set; }

        public int Gamemode { get => _Gamemode;
            set { _Gamemode = value; this.VnxSetElementData(EntityData.PlayerCurrentGamemode, value); } }

        public int Dead { get; set; }

        private int _Played { get; set; }

        public int Played { get => _Played;
            set => _Played = value;
        }

        private bool _Playing { get; set; }

        public bool Playing { get => _Playing;
            set { _Playing = value; this.VnxSetElementData(_Gamemodes_.Reallife.Globals.EntityData.PlayerPlaying, value); } }

        public string VipPaket { get; set; }

        public void DrawWaypoint(float posX, float posY) { try { VenoX.TriggerClientEvent(this, "Player:SetWaypoint", posX, posY); } catch(Exception ex){Core.Debug.CatchExceptions(ex);} }
        public void SetTeam(int team) { try { Alt.Emit("GlobalSystems:PlayerTeam", this, team); } catch(Exception ex){Core.Debug.CatchExceptions(ex);} }

        private bool _Freeze { get; set; }

        public bool Freeze { get => _Freeze;
            set { _Freeze = value; VenoX.TriggerClientEvent(this, "Player:Freeze", value); } }
        public void FreezeAfterMs(int ms, bool value) { try { VenoX.TriggerClientEvent(this, "Player:FreezeAfterMS", ms, value); _Freeze = value; } catch(Exception ex){Core.Debug.CatchExceptions(ex);} }
        public void LoadIpl(string ipl) { try { VenoX.TriggerClientEvent(this, "Player:LoadIPL", ipl); } catch(Exception ex){Core.Debug.CatchExceptions(ex);} }

        public DateTime VipTill { get; set; }

        public DateTime VipBought { get; set; }

        public List<VnXPlayer> NearbyPlayers { get; }

        public ushort SetArmor { get => Armor;
            set { this.VnxSetStreamSharedElementData("PLAYER_ARMOR", value); Armor = value; } }
        public ushort SetHealth { get => Health;
            set { this.VnxSetStreamSharedElementData("PLAYER_HEALTH", value); Health = value; } }

        public List<LoadingModel> PreloadEvents { get; }

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
                Reallife = new _RootCore_.Models.Reallife(this);
                Tactics = new Tactics(this);
                Zombies = new Zombies(this);
                Race = new Race(this);
                Inventory = new Inventory(this);
                SevenTowers = new _RootCore_.Models.SevenTowers(this);
                Shooter = new Shooter(this);
                Phone = new Phone(this);
                Forum = new Forum(this);
                Usefull = new Usefull(this);
                Discord = new _RootCore_.Models.Discord(this);
                Sync = new SyncClass(this);
                this.SpawnPlayer(Position);
                Language = (int)Main.Languages.English;
                Position rotation = new Position(0.0f, 0.0f, 0.0f);
                SetPosition = new Position(152.26f, -1004.47f, -99.00f);
                Dimension = Id;
                SetHealth = 200;
                SetArmor = 0;
                Reallife.Hunger = 60;
                this.RemoveAllPlayerWeapons();
                this.VnxSetStreamSharedElementData("settings_reporter", "ja");
                this.VnxSetStreamSharedElementData("settings_globalchat", "ja");
                this.VnxSetStreamSharedElementData("SocialState_NAMETAG", "VenoX");
                this.VnxSetElementData(Verleih.HavePlayerRentedVehicle, 0);
                Username = "Random-Player";
                Playing = false;
                AdminRank = 0;
                Dead = 0;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }

        public sealed override Position Position
        {
            get => base.Position;
            set => base.Position = value;
        }

        public sealed override int Dimension
        {
            get => base.Dimension;
            set => base.Dimension = value;
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