using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using VenoXV.Reallife.anzeigen.Usefull;
using VenoXV.Core;
using VenoXV.Reallife.database;
using VenoXV.Reallife.Globals;

namespace VenoXV.Reallife.gangwar.v2
{

    public class GangwarArea
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int BlipRgba { get; set; }
        public int Radius { get; set; }
        public int Rotation { get; set; }
        public Position TK { get; set; }
        public int IDOwner { get; set; }
        public DateTime Cooldown { get; set; }
        public IColShape TKIColShape { get; set; }
        public IColShape AreaIColShape { get; set; }
        public bool isRunning { get; set; }
        public IVehicle[] IVehicles { get; set; }
        public List<GangwarRound> Rounds { get; set; }

        public GangwarArea()
        {
            this.Rounds = new List<GangwarRound>();
        }

        public GangwarArea(string name, Position position, int radius, Position tk, int id, int rotation, DateTime cooldown) : this()
        {
            this.Name = name;
            this.Position = position;
            this.Radius = radius;
            this.TK = tk;
            this.IDOwner = id;
            this.Rotation = rotation;
            this.BlipRgba = Allround.GetFactionFactionBlipRgba(this.IDOwner);
            this.Cooldown = cooldown;
        }

        public void Update()
        {
            //RageAPI.SendChatMessageToAll(this.Name + ": Update RadarArea");
            Alt.EmitAllClients("gw:ca", this.Name, this.Position.X, this.Position.Y, this.Position.Z, this.Radius, this.BlipRgba, this.Rotation);
        }

        public void Update(IPlayer player)
        {
           // RageAPI.SendChatMessageToAll(this.Name + ": Update RadarArea ( " +player.GetVnXName<string>() + " )");
            AltV.Net.Alt.Server.TriggerClientEvent(player, "gw:ca", this.Name, this.Position.X, this.Position.Y, this.Position.Z, this.Radius, this.BlipRgba, this.Rotation);
        }

        public void CreateArea()
        {
            try
            {
                /* GANGWAR TK */
                this.TKIColShape = Alt.CreateColShapeSphere(this.TK, gangwar.v2.GangwarManager.TKRange);
                //ToDo Create Marker NAPI.Marker.CreateMarker(3, this.TK, new Position(0, 0, 0), new Position(0, 0, 0), 0.75f, new Rgba(200, 200, 200, 150), true, 0);

                RageAPI.CreateTextLabel("TK", new Position(this.TK.X, this.TK.Y, this.TK.Z + 0.13f), 20.0f, 2f, 4, new int[] { 0, 150, 200, 255 });
                this.TKIColShape.SetData(gangwar.v2.GangwarManager.TKType, true);

                /* GANGWAR GEBIET */
                this.AreaIColShape = Alt.CreateColShapeSphere(this.Position, this.Radius);
                this.AreaIColShape.SetData(gangwar.v2.GangwarManager.AreaType, true);
            }
            catch { }
        }

        public bool SetOwner(int factionId)
        {
            try
            {
                if (!this.isRunning)
                {
                    if (factionId > 0 && factionId <= 13)
                    {
                        // Change everything
                        this.IDOwner = factionId;
                        this.BlipRgba = Allround.GetFactionFactionBlipRgba(factionId);
                        Database.UpdateGW(this);
                        Update();

                        return true;
                    }
                }
                return false;
            }
            catch { return false; }
        }

        public bool isAttackable()
        {
            if (DateTime.Now <= this.Cooldown)
            {
                return false;
            }

            return true;
        }

        public void setCooldown(double minutes)
        {
            this.Cooldown = DateTime.Now.AddMinutes(minutes);
        }

        public GangwarRound GetCurrentRound() => this.Rounds[0];

        public TimeSpan GetLeftTime()
        {
            return DateTime.Now - this.Cooldown;
        }
        
        public void Inform(IPlayer player)
        {
            string Gang_Rgba_Chat = factions.FactionChat.GetFactionRgba(this.IDOwner);
            player.SendChatMessage(Gang_Rgba_Chat + "Gebiet: " + this.Name);
            player.SendChatMessage(Gang_Rgba_Chat + "Gang: " + factions.Faction.GetPlayerFactionName(this.IDOwner));
            player.SendChatMessage(Gang_Rgba_Chat + "Nächster Attack möglich: " + this.Cooldown);
        }

        public Rgba GangwarIVehicleRgbas(int factionId)
        {
            switch(factionId)
            {
                case Constants.FACTION_COSANOSTRA: return new Rgba(80, 80, 80,255);
                case Constants.FACTION_YAKUZA: return new Rgba(100, 0, 0, 255);
                case Constants.FACTION_MS13: return new Rgba(225, 225, 0, 255);
                case Constants.FACTION_SAMCRO: return new Rgba(100, 50, 100, 255);
                case Constants.FACTION_BALLAS: return new Rgba(138, 43, 226, 255);
                case Constants.FACTION_GROVE: return new Rgba(85, 107, 47, 255);
                default: return new Rgba(255, 255, 255, 255);
            }
        }
        public void CreateIVehicles()
        {
            try
            {
                this.IVehicles = new IVehicle[]
                {
                    Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X+10, this.TK.Y+10, this.TK.Z), new Rotation(0, 0, 355)),
                    Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X-10, this.TK.Y+10, this.TK.Z), new Rotation(0, 0, 355)),
                    Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X+10, this.TK.Y-10, this.TK.Z), new Rotation(0, 0, 355)),
                    Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X-10, this.TK.Y-10, this.TK.Z), new Rotation(0, 0, 355)),
                };

                foreach (var veh in this.IVehicles)
                {
                    veh.EngineOn = true;
                    veh.SetData(EntityData.VEHICLE_MODEL, "burrito3");
                    veh.SetData(EntityData.VEHICLE_FACTION, 0);
                    veh.SetData(EntityData.VEHICLE_OWNER, "GANGWAR");
                    veh.SetData(EntityData.VEHICLE_Rgba_TYPE, Constants.VEHICLE_Rgba_TYPE_CUSTOM);
                    veh.SetData(EntityData.VEHICLE_FIRST_Rgba, "255,255,255");
                    veh.SetData(EntityData.VEHICLE_SECOND_Rgba, "0,255,0");
                    veh.SetData(EntityData.VEHICLE_PEARLESCENT_Rgba, 0);
                    veh.SetData(EntityData.VEHICLE_PRICE, 0);
                    veh.SetData(EntityData.VEHICLE_PARKING, 0);
                    veh.SetData(EntityData.VEHICLE_PARKED, 0);
                    veh.PrimaryColorRgb = GangwarIVehicleRgbas(GetCurrentRound().AttackerId);
                    Core.VnX.VehiclevnxSetSharedData(veh, "kms", 0);
                    Core.VnX.VehiclevnxSetSharedData(veh, "gas", 100);
                    veh.SetData(EntityData.VEHICLE_NOT_SAVED, true);
                    veh.Dimension = GangwarManager.GW_DIM;
                }
            }
            catch { }
        }

        public void RemoveElements()
        {
            try
            {
                foreach (var veh in this.IVehicles)
                {
                    veh.Remove();
                }
            }
            catch { }
        }

        public void FreezeElements(bool state)
        {
            try
            {
                foreach (var veh in this.IVehicles)
                {
                    Alt.EmitAllClients("FreezeVEHICLEPLAYER_VnX", veh, state);
                    //veh.Locked = state;
                    //AltV.Net.Async.AltAsync.SetLockStateAsync(veh, state);
                }
            }
            catch { }
        }

        public void Stop()
        {
            this.RemoveElements();
            this.isRunning = false;
            this.GetCurrentRound().Stop();
        }

        public void Attack(IPlayer player)
        {
            try
            {
                if (!this.isRunning)
                {
                    this.isRunning = true;
                    this.Rounds.Insert(0, new GangwarRound(this, this.IDOwner, player.vnxGetElementData<int>(EntityData.PLAYER_FACTION)));

                    this.CreateIVehicles();
                    this.AddPlayer(player);
                }
            }
            catch { }
        }

        public void AddPlayer(IPlayer player)
        {
            try
            {
                if (!this.GetCurrentRound().isPlayerJoined(player))
                {
                    this.GetCurrentRound().AddPlayer(player);
                }
            }
            catch { }
        }
    }
}