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
                PlayerVehicleHash = Alt.Hash("SultanRS"),
                PlayerSpawnPoints = new List<SpawnModel>
                {
                    new SpawnModel()
                    {
                        Position = new Vector3(2916f, 3707.855f, 52.06079f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2910.5671f, 3709.8726f, 52.043945f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2908.4834f, 3702.1318f, 52.043945f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2914.0747f, 3700.6814f, 52.06079f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
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
                PlayerSpawnPoints = new List<SpawnModel>
                {
                    new SpawnModel()
                    {
                        Position = new Vector3(2916f, 3707.855f, 52.06079f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2910.5671f, 3709.8726f, 52.043945f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2908.4834f, 3702.1318f, 52.043945f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(2914.0747f, 3700.6814f, 52.06079f),
                        Rotation = new Vector3(0,0,0),
                        Spawned = false
                    },

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
                MapName = "Highway-LS",
                PlayerVehicleHash = Alt.Hash("T20"),
                PlayerSpawnPoints = new List<SpawnModel>
                {
                    new SpawnModel()
                    {
                        Position = new Vector3(-2399.3801f, -253.17363f, 14.620483f),
                        Rotation = new Vector3(0.015625f, 0f, 1.046875f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2396.9407f, -250.07472f, 14.603638f),
                        Rotation = new Vector3(0.015625f, 0f, 1.0625f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2387.8682f, -256.07474f, 14.350952f),
                        Rotation = new Vector3(0.015625f, 0f, 1f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2389.7012f, -259.0022f, 14.350952f),
                        Rotation = new Vector3(0.015625f, 0f, 1.0625f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2381.077f, -264.52747f, 14.11499f),
                        Rotation = new Vector3(0f, 0f, 1.015625f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2379.4153f, -261.7187f, 14.11499f),
                        Rotation = new Vector3(0.015625f, 0f, 1f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2401.8594f, -257.09012f, 14.637329f),
                        Rotation = new Vector3(0.015625f, 0f, 1f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2392.6418f, -262.93185f, 14.367798f),
                        Rotation = new Vector3(0.015625f, 0f, 1f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2383.9648f, -268.36484f, 14.131836f),
                        Rotation = new Vector3(0f, 0f, 1.015625f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2405.1033f, -261.62637f, 14.637329f),
                        Rotation = new Vector3(0.015625f, 0f, 1.015625f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2395.978f, -267.6791f, 14.367798f),
                        Rotation = new Vector3(0.015625f, 0f, 0.96875f),
                        Spawned = false
                    },
                    new SpawnModel()
                    {
                        Position = new Vector3(-2387.7231f, -273.3231f, 14.131836f),
                        Rotation = new Vector3(0.015625f, -0.015625f, 0.96875f),
                        Spawned = false
                    },

                },
                RaceCheckpoints = new List<Position>
                {
                    new Vector3(-2532.1978f, -186.15823f, 18.934082f),
                    new Vector3(-2610f, -130.87912f, 20.147217f),
                    new Vector3(-2677.9253f, -46.25934f, 15.429321f),
                    new Vector3(-2804.9802f, 42.79121f, 14.199219f),
                    new Vector3(-2965.2263f, 102.98901f, 13.221924f),
                    new Vector3(-3011.855f, 310.7868f, 14.148682f),
                    new Vector3(-3030.4878f, 699.45496f, 22.304077f),
                    new Vector3(-3155.921f, 952.2198f, 14.013916f),
                    new Vector3(-3097.5562f, 1270.8132f, 19.557495f),
                    new Vector3(-2983.49f, 1565.3802f, 28.369995f),
                    new Vector3(-3021.389f, 1909.0286f, 27.931885f),
                    new Vector3(-2931.9165f, 2131.411f, 39.962646f),
                    new Vector3(-2786.5056f, 2217.521f, 25.151611f),
                    new Vector3(-2687.7627f, 2405.8945f, 16.002197f),
                    new Vector3(-2615.1956f, 2910.1055f, 16.019043f),
                    new Vector3(-2591.3274f, 3163.2922f, 13.710571f),
                    new Vector3(-2567.7363f, 3357.0593f, 12.76709f),
                    new Vector3(-2474.5188f, 3645.2834f, 13.188232f),
                    new Vector3(-2430.1582f, 3834.0396f, 22.48938f),
                    new Vector3(-2332.1406f, 4096.009f, 33.526f),
                    new Vector3(-2207.4329f, 4333.477f, 49.213135f),
                    new Vector3(-2152.1274f, 4436.2812f, 62.490845f),
                    new Vector3(-1977.7054f, 4540.813f, 56.37439f),
                    new Vector3(-1790.4396f, 4729.0156f, 56.357544f),
                    new Vector3(-1537.2924f, 4963.701f, 61.463013f),
                    new Vector3(-1291.622f, 5245.556f, 52.195557f),
                    new Vector3(-1066.734f, 5331.1123f, 45.16919f),
                    new Vector3(-692.8483f, 5540.624f, 37.165527f),
                    new Vector3(-543.24396f, 5747.3013f, 35.68274f),
                    new Vector3(-382.73407f, 5990.2812f, 30.846924f)
                },
                PlayerRotation = new Rotation(0,0,0.25f),
                PlayerSkin = "s_f_y_stripper_01",
            }
        };
    }
}
