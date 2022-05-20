using System;
using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Data;
using VenoX.Core._Gamemodes_.Reallife.factions;
using VenoX.Core._Gamemodes_.Reallife.globals;
using VenoX.Core._RootCore_;
using VenoX.Core._RootCore_.Database;
using VenoX.Core._RootCore_.Models;
using VenoX.Debug;

namespace VenoX.Core._Gamemodes_.Reallife.gangwar.v2
{

    public class GangwarArea
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int BlipRgba { get; set; }
        public int Radius { get; set; }
        public int Rotation { get; set; }
        public Position Tk { get; set; }
        public int IdOwner { get; set; }
        public DateTime Cooldown { get; set; }
        public ColShapeModel TkColShapeModel { get; set; }
        public ColShapeModel AreaColShapeModel { get; set; }
        public bool IsRunning { get; set; }
        public VehicleModel[] Vehicles { get; set; }
        public List<GangwarRound> Rounds { get; set; }

        public GangwarArea()
        {
            Rounds = new List<GangwarRound>();
        }

        public GangwarArea(string name, Position position, int radius, Position tk, int id, int rotation, DateTime cooldown) : this()
        {
            Name = name;
            Position = position;
            Radius = radius;
            Tk = tk;
            IdOwner = id;
            Rotation = rotation;
            BlipRgba = Allround.GetFactionFactionBlipRgba(IdOwner);
            Cooldown = cooldown;
        }

        public void Update()
        {
            //RageAPI.SendTranslatedChatMessageToAll(this.Name + ": Update RadarArea");
            _RootCore_.VenoX.TriggerEventForAll("AreaBlip:Create", Name, Position.X, Position.Y, Position.Z, Radius, BlipRgba, Rotation);
        }

        public void Update(VnXPlayer player)
        {
            // RageAPI.SendTranslatedChatMessageToAll(this.Name + ": Update RadarArea ( " +player.Username + " )");
            _RootCore_.VenoX.TriggerClientEvent(player, "AreaBlip:Create", Name, Position.X, Position.Y, Position.Z, Radius, BlipRgba, Rotation);
        }

        public void CreateArea()
        {
            try
            {
                /* GANGWAR TK */
                TkColShapeModel = RageApi.CreateColShapeSphere(Tk, GangwarManager.TkRange);
                //ToDo Create Marker NAPI.Marker.CreateMarker(3, this.TK, new Position(0, 0, 0), new Position(0, 0, 0), 0.75f, new Rgba(200, 200, 200, 150), true, 0);

                RageApi.CreateTextLabel("TK", new Position(Tk.X, Tk.Y, Tk.Z + 0.13f), 20.0f, 2f, 4, new[] { 0, 150, 200, 255 });
                TkColShapeModel.VnxSetElementData(GangwarManager.TkType, true);

                /* GANGWAR GEBIET */
                AreaColShapeModel = RageApi.CreateColShapeSphere(Position, Radius);
                AreaColShapeModel.VnxSetElementData(GangwarManager.AreaType, true);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public bool SetOwner(int factionId)
        {
            try
            {
                if (IsRunning) return false;
                if (factionId <= 0 || factionId > 13) return false;
                // Change everything
                IdOwner = factionId;
                BlipRgba = Allround.GetFactionFactionBlipRgba(factionId);
                Database.UpdateGw(this);
                Update();

                return true;
            }
            catch { return false; }
        }

        public bool IsAttackable()
        {
            if (DateTime.Now <= Cooldown)
            {
                return false;
            }

            return true;
        }

        public void SetCooldown(double minutes)
        {
            Cooldown = DateTime.Now.AddMinutes(minutes);
        }

        public GangwarRound GetCurrentRound() => Rounds[0];

        public TimeSpan GetLeftTime()
        {
            return DateTime.Now - Cooldown;
        }

        public void Inform(VnXPlayer player)
        {
            string gangRgbaChat = FactionChat.GetFactionRgba(IdOwner);
            player.SendTranslatedChatMessage(gangRgbaChat + "Gebiet: " + Name);
            player.SendTranslatedChatMessage(gangRgbaChat + "Gang: " + Faction.GetFactionNameById(IdOwner));
            player.SendTranslatedChatMessage(gangRgbaChat + "Nächster Attack möglich: " + Cooldown);
        }

        public Rgba GangwarIVehicleRgbas(int factionId)
        {
            return factionId switch
            {
                Constants.FactionLcn => new Rgba(80, 80, 80, 255),
                Constants.FactionYakuza => new Rgba(100, 0, 0, 255),
                Constants.FactionNarcos => new Rgba(225, 225, 0, 255),
                Constants.FactionSamcro => new Rgba(100, 50, 100, 255),
                Constants.FactionBallas => new Rgba(138, 43, 226, 255),
                Constants.FactionCompton => new Rgba(85, 107, 47, 255),
                _ => new Rgba(255, 255, 255, 255),
            };
        }
        public void CreateIVehicles()
        {
            try
            {
                Vehicles = new[]
                {
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(Tk.X+10, Tk.Y+10, Tk.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(Tk.X-10, Tk.Y+10, Tk.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(Tk.X+10, Tk.Y-10, Tk.Z), new Rotation(0, 0, 355)),
                    (VehicleModel)Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Burrito3, new Position(Tk.X-10, Tk.Y-10, Tk.Z), new Rotation(0, 0, 355)),
                };

                foreach (VehicleModel veh in Vehicles)
                {
                    veh.EngineOn = true;
                    veh.PrimaryColorRgb = GangwarIVehicleRgbas(GetCurrentRound().AttackerId);
                    veh.Kms = 0;
                    veh.Gas = 100;
                    veh.NotSave = false;
                    veh.Dimension = GangwarManager.GwDim;
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void RemoveElements()
        {
            try
            {
                foreach (VehicleModel veh in Vehicles)
                {
                    //veh.Remove();
                    RageApi.DeleteVehicleThreadSafe(veh);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void FreezeElements(bool state)
        {
            try
            {
                foreach (VehicleModel veh in Vehicles)
                {
                    veh.Frozen = state;
                    veh.Locked = state;
                    //veh.Locked = state;
                    //AltV.Net.Async.AltAsync.SetLockStateAsync(veh, state);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void Stop()
        {
            RemoveElements();
            IsRunning = false;
            GetCurrentRound().Stop();
        }

        public void Attack(VnXPlayer player)
        {
            try
            {
                if (IsRunning) return;
                IsRunning = true;
                Rounds.Insert(0, new GangwarRound(this, IdOwner, player.Reallife.Faction));

                CreateIVehicles();
                AddPlayer(player);
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }

        public void AddPlayer(VnXPlayer player)
        {
            try
            {
                if (!GetCurrentRound().IsPlayerJoined(player))
                {
                    GetCurrentRound().AddPlayer(player);
                }
            }
            catch(Exception ex){ExceptionHandling.CatchExceptions(ex);}
        }
    }
}