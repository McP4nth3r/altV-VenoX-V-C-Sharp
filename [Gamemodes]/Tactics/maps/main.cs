using System.Collections.Generic;
using System.Numerics;
using VenoXV.Tactics.model;

namespace VenoXV.Tactics.maps
{
    public class Main
    {
        public static List<RoundModel> TacticMaps = new List<RoundModel>
        {
            new RoundModel
            {
                Map_Name = "Flugzeugträger",
                //Team A
                Team_A_Name = "L.S.P.D",
                Team_A_Skin = "s_f_y_cop_01",
                Team_A_WinnerText = "Das L.S.P.D gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 140, 183 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(3052.326f, -4654.027f, 15.26142f),
                    new Vector3(3045.766f, -4655.521f, 15.2623f),
                    new Vector3(3036.987f, -4658.588f, 15.26142f),
                    new Vector3(3029.982f, -4657.58f, 15.26163f),
                },
                //Team B
                Team_B_Name = "Grove Street",
                Team_B_Skin = "ig_ramp_gang",
                Team_B_WinnerText = "Die Grove Street gewinnt die Runde.",
                Team_B_Color = new int[] { 0, 152, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(3077.715f, -4795.332f, 15.2613f),
                    new Vector3(3090.292f, -4791.002f, 15.26161f),
                    new Vector3(3097.125f, -4786.874f, 15.26162f),
                    new Vector3(3090.783f, -4792.346f, 15.26162f),
                },

                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),

            },
            new RoundModel
            {
                Map_Name = "L.S.P.D",
                Team_A_Name = "S.W.A.T",
                Team_A_Skin = "s_m_y_swat_01",
                Team_A_WinnerText = "Das S.W.A.T Team gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 50, 183 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(438.94946f,  -991.5033f,  30.678345f),
                    new Vector3(439.06815f,  -993.7846f,  30.678345f),
                    new Vector3(438.94946f,  -995.7758f,  30.678345f),
                    new Vector3(440.822f,    -994.8659f,  30.678345f),
                },
                Team_B_Name = "Yakuza",
                Team_B_Skin = "s_f_y_stripper_01",
                Team_B_WinnerText = "Die Yakuza gewinnt die Runde.",
                Team_B_Color = new int[] { 152, 0, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(378.8176f,  -954.4352f, 29.296753f),
                    new Vector3(378.56705f, -956.5187f, 29.397827f),
                    new Vector3(378.40878f, -958.7341f, 29.313599f),
                    new Vector3(368.58463f, -956.0967f, 29.431519f),
                },

                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
            new RoundModel
            {
                Map_Name = "Würfelpark",
                Team_A_Name = "F.I.B",
                Team_A_Skin = "mp_m_fibsec_01",
                Team_A_WinnerText = "Das F.I.B gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 0, 200 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(218.13626f, -939.12524f, 24.140625f),
                    new Vector3(215.98682f, -938.2813f,  24.140625f),
                    new Vector3(214.41759f, -937.5165f,  24.140625f),
                    new Vector3(213.32307f, -936.7253f,  24.140625f),
                },
                Team_B_Name = "Bloodz",
                Team_B_Skin = "ig_claypain",
                Team_B_WinnerText = "Die Bloodz gewinnt die Runde.",
                Team_B_Color = new int[] { 200, 0, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(164.34726f, -912.7253f, 30.223389f),
                    new Vector3(163.72748f, -913.9385f, 30.206543f),
                    new Vector3(162.97583f, -915.54724f, 30.189697f),
                    new Vector3(162.58022f, -916.87915f, 30.172852f),
                },

                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
            new RoundModel
            {
                Map_Name = "Würfelpark",
                Team_A_Name = "Aliens",
                Team_A_Skin = "s_m_m_movalien_01",
                Team_A_WinnerText = "Die Aliens gewinnen die Runde.",
                Team_A_Color = new int[] { 0, 200, 50 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(3539.8022f, 3676.4702f,  28.117188f),
                    new Vector3(3540.765f,  3676.3516f,  28.117188f),
                    new Vector3(3541.6748f, 3676.1143f,  28.117188f),
                    new Vector3(3540.29f,   3674.4922f,    28.117188f),
                },
                Team_B_Name = "Zombies",
                Team_B_Skin = "u_m_y_zombie_01",
                Team_B_WinnerText = "Die Zombies gewinnen die Runde.",
                Team_B_Color = new int[] { 200, 0, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(3569.1824f, 3702.29f, 28.117188f),
                    new Vector3(3568.2065f, 3702.3955f, 28.117188f),
                    new Vector3(3566.9539f, 3702.7122f, 28.117188f),
                    new Vector3(3567.6528f, 3700.8528f, 28.117188f),
                },

                Custom_Weapon_Map = true,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>
                {
                    {(AltV.Net.Enums.WeaponModel) AltV.Net.Alt.Hash("weapon_raypistol")},
                    {(AltV.Net.Enums.WeaponModel) AltV.Net.Alt.Hash("weapon_rayminigun")},
                },
            },

            new RoundModel
            {
                Map_Name = "Sandy-Shores",
                Team_A_Name = "SAMCRO",
                Team_A_Skin = "g_m_y_lost_03",
                Team_A_WinnerText = "Das SAMCRO gewinnt die Runde.",
                Team_A_Color = new int[] { 100, 50, 50 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(1538.8088f, 3613.9253f, 35.345825f),
                    new Vector3(1542.0923f, 3614.2417f, 35.345825f),
                    new Vector3(1544.0967f, 3615.521f, 35.345825f),
                    new Vector3(1544.3868f, 3613.1472f, 35.32898f),
                },
                Team_B_Name = "Narcos",
                Team_B_Skin = "mp_m_execpa_01",
                Team_B_WinnerText = "Die Narcos gewinnen die Runde.",
                Team_B_Color = new int[] { 128, 129, 150 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(1648.3912f, 3540.1714f, 35.952393f),
                    new Vector3(1652.3209f, 3539.3538f, 36.171387f),
                    new Vector3(1652.2021f, 3546.7385f, 35.649048f),
                    new Vector3(1650.5538f, 3545.0242f, 35.68274f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },

            new RoundModel
            {
                Map_Name = "Pier",
                Team_A_Name = "M.W.S.C",
                Team_A_Skin = "csb_mweather",
                Team_A_WinnerText = "Das M.W.S.C Team gewinnt die Runde.",
                Team_A_Color = new int[] { 100, 100, 100 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-1712.5582f, -1118.0571f, 13.137695f),
                    new Vector3(-1713.9824f, -1119.2043f, 13.137695f),
                    new Vector3(-1719.4154f, -1114.5099f, 13.137695f),
                    new Vector3(-1721.5253f, -1121.1165f, 13.137695f),
                },
                Team_B_Name = "S.W.A.T",
                Team_B_Skin = "s_m_y_swat_01",
                Team_B_WinnerText = "Das S.W.A.T Team gewinnt die Runde.",
                Team_B_Color = new int[] { 0, 50, 183 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-1855.0022f, -1219.0417f, 13.00293f),
                    new Vector3(-1850.5846f, -1224.2109f, 13.00293f),
                    new Vector3(-1844.123f,  -1218.3297f, 13.00293f),
                    new Vector3(-1838.9934f, -1218.0923f, 13.00293f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },

            new RoundModel
            {
                Map_Name = "LS-Airport",
                Team_A_Name = "U.S Army",
                Team_A_Skin = "s_m_y_marine_03",
                Team_A_WinnerText = "Die US-Army gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 125, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-856.0879f, -3256.8792f, 14.030762f),
                    new Vector3(-860.62415f, -3264.2637f, 14.047607f),
                    new Vector3(-865.2132f, -3272.0703f, 14.030762f),
                    new Vector3(-869.94727f, -3279.9429f, 14.030762f),
                },
                Team_B_Name = "Terroristen",
                Team_B_Skin = "g_m_m_chicold_01",
                Team_B_WinnerText = "Das Terroristen Team gewinnt die Runde.",
                Team_B_Color = new int[] { 125, 0, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-1151.4462f, -2861.4197f, 13.9296875f),
                    new Vector3(-1147.4506f, -2866.6353f, 13.9296875f),
                    new Vector3(-1144.3121f, -2868.178f, 13.9296875f),
                    new Vector3(-1140.6593f, -2870.789f, 13.9296875f),
                },

                Custom_Vehicles = new List<VehicleModel>
                {
                    new VehicleModel{Vehicle_Hash = AltV.Net.Enums.VehicleModel.Buzzard,Vehicle_Position = new Vector3(-863.0242f,  -3204.5671f, 13.9296875f),Vehicle_Rotation = new Vector3(0,0,0)},
                    new VehicleModel{Vehicle_Hash = AltV.Net.Enums.VehicleModel.Buzzard,Vehicle_Position = new Vector3(-867.87695f, -3212.2417f, 13.9296875f),Vehicle_Rotation = new Vector3(0,0,0)},
                    new VehicleModel{Vehicle_Hash = AltV.Net.Enums.VehicleModel.Buzzard,Vehicle_Position = new Vector3(-873.6f,     -3216.7913f, 13.9296875f),Vehicle_Rotation = new Vector3(0,0,0)},
                    new VehicleModel{Vehicle_Hash = AltV.Net.Enums.VehicleModel.Buzzard,Vehicle_Position = new Vector3(-878.38684f, -3224.6638f, 13.9296875f),Vehicle_Rotation = new Vector3(0,0,0)},
                },
                Custom_Weapon_Map = true,
                Custom_Weapon_Mode_Name = "",
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>
                {
                    {AltV.Net.Enums.WeaponModel.RPG},
                    {AltV.Net.Enums.WeaponModel.CarbineRifle},
                },
            },

        };
    }
}
