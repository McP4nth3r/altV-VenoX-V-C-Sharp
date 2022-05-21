using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;

namespace VenoX.Core._Gamemodes_.Race.model
{
    public class MapModel
    {
        public string MapName { get; set; }
        public List<Position> RaceCheckpoints { get; set; }
        public uint PlayerVehicleHash { get; set; }
        public List<SpawnModel> PlayerSpawnPoints { get; set; }
        public Vector3 PlayerRotation { get; set; }
        public string PlayerSkin { get; set; }
    }
}
