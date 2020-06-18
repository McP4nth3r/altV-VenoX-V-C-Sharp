using AltV.Net;
using AltV.Net.Data;
using System.Collections.Generic;
using System.Numerics;
using VenoXV._Gamemodes_.Race.model;

namespace VenoXV._Gamemodes_.Race.maps
{
    public class Main
    {
        public static List<MapModel> RaceMaps = new List<MapModel>
        {
            new MapModel
            {
                MapName = "Highway",
                PlayerVehicleHash = Alt.Hash("Supra2"),
                PlayerSpawnPoints = new List<Position>
                {
                    new Vector3(2916f, 3707.855f, 52.06079f),
                    new Vector3(2910.5671f, 3709.8726f, 52.043945f),
                    new Vector3(2908.4834f, 3702.1318f, 52.043945f),
                    new Vector3(2914.0747f, 3700.6814f, 52.06079f),
                },
                RaceCheckpoints = new List<Position>
                {
                    new Vector3(2936.967f, 3808.1274f, 52.0271f),
                    new Vector3(2936.967f, 3808.1274f, 52.0271f),
                    new Vector3(2895.8506f, 4141.029f, 49.75244f),
                    new Vector3(0,0,0),
                    new Vector3(0,0,0),
                },
                PlayerRotation = new Rotation(0,0,0.25f),
                PlayerSkin = "s_f_y_stripper_01",
            },
            new MapModel
            {
                MapName = "Highway",
                PlayerVehicleHash = Alt.Hash("Supra2"),
                PlayerSpawnPoints = new List<Position>
                {
                    new Vector3(2916f, 3707.855f, 52.06079f),
                    new Vector3(2910.5671f, 3709.8726f, 52.043945f),
                    new Vector3(2908.4834f, 3702.1318f, 52.043945f),
                    new Vector3(2914.0747f, 3700.6814f, 52.06079f),
                },
                RaceCheckpoints = new List<Position>
                {
                    new Vector3(0,0,0),
                    new Vector3(0,0,0),
                    new Vector3(0,0,0),
                    new Vector3(0,0,0),
                    new Vector3(0,0,0),
                },
                PlayerRotation = new Rotation(0,0,0.25f),
                PlayerSkin = "s_f_y_stripper_01",
            },
        };
    }
}
