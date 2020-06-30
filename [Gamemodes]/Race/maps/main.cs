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
                    new Vector3(2840.2812f, 4307.934f, 49.55017f),
                    new Vector3(2779.5825f, 4515.218f, 46.16333f),
                    new Vector3(2685.6924f, 4912.5757f, 44.09082f),
                    new Vector3(2580.6726f, 5325.0464f, 43.956055f),
                    new Vector3(2400.5803f, 5786.611f, 45.28723f),
                    new Vector3(2270.1362f, 5973.086f, 49.55017f),
                    new Vector3(2095.7407f, 6104.8745f, 50.03882f),
                    new Vector3(2005.266f, 6209.657f, 46.466675f),
                    new Vector3(1790.7032f, 6366.3164f, 38.210205f),
                    new Vector3(1573.6879f, 6423.4814f, 24.140625f),
                    new Vector3(1319.7891f, 6487.0947f, 19.389038f),
                    new Vector3(1114.3649f, 6488.479f, 20.41687f),
                    new Vector3(672.9758f, 6521.288f, 27.460083f),
                    new Vector3(390.35605f, 6573.376f, 26.988281f),
                    new Vector3(95.6044f, 6475.411f, 30.712036f),
                    new Vector3(-162.22418f, 6217.4507f, 30.54358f),
                    new Vector3(-400.08792f, 5970.488f, 31.065918f),
                    new Vector3(-547.46375f, 5743.846f, 35.80078f),
                    new Vector3(-769.1868f, 5497.8857f, 34.16626f),
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
