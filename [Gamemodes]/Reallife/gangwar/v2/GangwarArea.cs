using AltV.Net;
using AltV.Net.Data;
using System;
using System.Collections.Generic;
using VenoXV._Gamemodes_.Reallife.Globals;
using VenoXV._RootCore_.Database;
using VenoXV._RootCore_.Models;
using VenoXV.Core;

namespace VenoXV._Gamemodes_.Reallife.gangwar.v2
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
        public ColShapeModel TKColShapeModel { get; set; }
        public ColShapeModel AreaColShapeModel { get; set; }
        public bool isRunning { get; set; }
        public VehicleModel[] IVehicles { get; set; }
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
            //RageAPI.SendTranslatedChatMessageToAll(this.Name + ": Update RadarArea");
            Alt.EmitAllClients("AreaBlip:Create", this.Name, this.Position.X, this.Position.Y, this.Position.Z, this.Radius, this.BlipRgba, this.Rotation);
        }

        public void Update(VnXPlayer player)
        {
            // RageAPI.SendTranslatedChatMessageToAll(this.Name + ": Update RadarArea ( " +player.Username + " )");
            AltV.Net.Alt.Server.TriggerClientEvent(player, "AreaBlip:Create", this.Name, this.Position.X, this.Position.Y, this.Position.Z, this.Radius, this.BlipRgba, this.Rotation);
        }

        public void CreateArea()
        {
            try
            {
                /* GANGWAR TK */
                this.TKColShapeModel = RageAPI.CreateColShapeSphere(this.TK, gangwar.v2.GangwarManager.TKRange);
                //ToDo Create Marker NAPI.Marker.CreateMarker(3, this.TK, new Position(0, 0, 0), new Position(0, 0, 0), 0.75f, new Rgba(200, 200, 200, 150), true, 0);

                RageAPI.CreateTextLabel("TK", new Position(this.TK.X, this.TK.Y, this.TK.Z + 0.13f), 20.0f, 2f, 4, new int[] { 0, 150, 200, 255 });
                this.TKColShapeModel.vnxSetElementData(gangwar.v2.GangwarManager.TKType, true);

                /* GANGWAR GEBIET */
                this.AreaColShapeModel = RageAPI.CreateColShapeSphere(this.Position, this.Radius);
                this.AreaColShapeModel.vnxSetElementData(gangwar.v2.GangwarManager.AreaType, true);
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

        public void Inform(VnXPlayer player)
        {
            string Gang_Rgba_Chat = Factions.FactionChat.GetFactionRgba(this.IDOwner);
            player.SendTranslatedChatMessage(Gang_Rgba_Chat + "Gebiet: " + this.Name);
            player.SendTranslatedChatMessage(Gang_Rgba_Chat + "Gang: " + factions.Faction.GetFactionNameById(this.IDOwner));
            player.SendTranslatedChatMessage(Gang_Rgba_Chat + "Nächster Attack möglich: " + this.Cooldown);
        }

        public Rgba GangwarIVehicleRgbas(int factionId)
        {
            return factionId switch
            {
                Constants.FACTION_LCN => new Rgba(80, 80, 80, 255),
                Constants.FACTION_YAKUZA => new Rgba(100, 0, 0, 255),
                Constants.FACTION_NARCOS => new Rgba(225, 225, 0, 255),
                Constants.FACTION_SAMCRO => new Rgba(100, 50, 100, 255),
                Constants.FACTION_BALLAS => new Rgba(138, 43, 226, 255),
                Constants.FACTION_COMPTON => new Rgba(85, 107, 47, 255),
                _ => new Rgba(255, 255, 255, 255),
            };
        }
        public void CreateIVehicles()
        {
            try
            {
                this.IVehicles = new VehicleModel[]
                {
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X+10, this.TK.Y+10, this.TK.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X-10, this.TK.Y+10, this.TK.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X+10, this.TK.Y-10, this.TK.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(this.TK.X-10, this.TK.Y-10, this.TK.Z), new Rotation(0, 0, 355)),
                };

                foreach (var veh in this.IVehicles)
                {
                    veh.EngineOn = true;
                    veh.PrimaryColorRgb = GangwarIVehicleRgbas(GetCurrentRound().AttackerId);
                    veh.Kms = 0;
                    veh.Gas = 100;
                    veh.NotSave = false;
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
                    //veh.Remove();
                    RageAPI.DeleteVehicleThreadSafe(veh);
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
                    veh.Frozen = state;
                    veh.Locked = state;
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

        public void Attack(VnXPlayer player)
        {
            try
            {
                if (!this.isRunning)
                {
                    this.isRunning = true;
                    this.Rounds.Insert(0, new GangwarRound(this, this.IDOwner, player.Reallife.Faction));

                    this.CreateIVehicles();
                    this.AddPlayer(player);
                }
            }
            catch { }
        }

        public void AddPlayer(VnXPlayer player)
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