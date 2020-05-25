﻿using System.Collections.Generic;

namespace VenoXV._Gamemodes_.Tactics.maps
{
    public class Main
    {
        public static List<RoundModel> TacticMaps = new List<RoundModel>
        {
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
            new RoundModel
            {
                Map_Name = "Pissgebiet",
                Team_A_Name = "Yakuza",
                Team_A_Skin = "u_m_y_burgerdrug_01",
                Team_A_WinnerText = "Die Yakuza gewinnt die Runde.",
                Team_A_Color = new int[] { 125, 0, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-2892.91f, -7.8197784f, 7.947998f),
                    new Vector3(-2891.7231f, -7.8857155f, 7.947998f),
                    new Vector3(-2890.378f, -8.360439f, 7.947998f),
                    new Vector3( -2891.789f, -9.83736f, 7.947998f),
                },
                Team_B_Name = "Vagos",
                Team_B_Skin = "u_m_y_mani",
                Team_B_WinnerText = "Die Vagos gewinnt die Runde.",
                Team_B_Color = new int[] { 200, 200, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-2923.622f, 54.105495f, 11.031494f),
                    new Vector3(-2924.8088f, 54.474724f, 11.031494f),
                    new Vector3(-2924.0176f, 55.345055f, 11.031494f),
                    new Vector3(-2925.4946f, 55.964836f, 11.031494f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
            new RoundModel
            {
                Map_Name = "Pennergebiet",
                Team_A_Name = "Penner1",
                Team_A_Skin = "a_m_o_tramp_01",
                Team_A_WinnerText = "Die Penner[1] gewinnen die Runde.",
                Team_A_Color = new int[] { 125, 0, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(1426.9187f, 6327.4814f, 24.073242f),
                    new Vector3(1430.2946f, 6327.7583f, 24.00586f),
                    new Vector3(1432.444f, 6327.9956f, 24.00586f),
                    new Vector3(1434.3165f, 6329.1167f, 23.989014f),
                },
                Team_B_Name = "Penner2",
                Team_B_Skin = "a_m_m_tramp_01",
                Team_B_WinnerText = "Die Penner[2] gewinnen die Runde.",
                Team_B_Color = new int[] { 0, 200, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(1480.9583f, 6403.767f, 22.624146f),
                    new Vector3(1482.6989f, 6403.2793f, 22.523071f),
                    new Vector3(1484.9011f, 6402.5537f, 22.657837f),
                    new Vector3(1482.1187f, 6399.6265f, 22.624146f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
            new RoundModel
            {
                Map_Name = "Bio",
                Team_A_Name = "Bio",
                Team_A_Skin = "a_m_m_bevhills_02",
                Team_A_WinnerText = "Die Bio Menschen gewinnen die Runde.",
                Team_A_Color = new int[] { 125, 0, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(1905.1516f, 4921.556f, 48.84253f),
                    new Vector3(1905.5209f, 4923.178f, 48.87622f),
                    new Vector3(1905.4945f, 4926.6064f, 48.909912f),
                    new Vector3(1905.5604f, 4930.7866f, 48.96045f),
                },
                Team_B_Name = "Compton Family's",
                Team_B_Skin = "mp_m_famdd_01",
                Team_B_WinnerText = "Die Compton Family gewinnen die Runde.",
                Team_B_Color = new int[] { 0, 200, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(1900.3253f, 4996.1143f, 47.831543f),
                    new Vector3(1898.6241f, 4997.9604f, 48.03369f),
                    new Vector3(1902.2902f, 5001.165f, 47.29236f),
                    new Vector3(1903.9253f, 4999.4507f, 47.106934f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
            new RoundModel
            {
                Map_Name = "Baustelle",
                Team_A_Name = "Bauarbeiter",
                Team_A_Skin = "s_m_y_construct_02",
                Team_A_WinnerText = "Die Bauarbeiter gewinnen die Runde.",
                Team_A_Color = new int[] { 255, 255, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-136.73407f, -1080.3956f, 42.13623f),
                    new Vector3(-137.48572f, -1079.4725f, 42.13623f),
                    new Vector3(-136.28572f, -1078.2329f, 42.13623f),
                    new Vector3(-137.28792f, -1076.888f, 42.13623f),
                },
                Team_B_Name = "Ballas",
                Team_B_Skin = "g_m_y_ballaorig_01",
                Team_B_WinnerText = "Die Ballas gewinnen die Runde.",
                Team_B_Color = new int[] { 85, 26, 139 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-164.14944f, -1071.1384f, 36.137695f),
                    new Vector3(-165.36264f, -1071.9165f, 36.137695f),
                    new Vector3(-164.59781f, -1073.6307f, 36.137695f),
                    new Vector3(-162.61978f, -1072.734f, 36.137695f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },
             new RoundModel
            {
                Map_Name = "Gefängnis",
                Team_A_Name = "Inhaftierte",
                Team_A_Skin = "s_m_y_prisoner_01",
                Team_A_WinnerText = "Die Inhaftierten gewinnen die Runde.",
                Team_A_Color = new int[] { 255, 255, 0 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(1648.4835f, 2631.6792f, 45.556763f),
                    new Vector3(1648.378f, 2629.5166f, 45.556763f),
                    new Vector3(1650.9099f, 2629.754f, 45.556763f),
                    new Vector3(1650.7649f, 2631.9429f, 45.556763f),
                },
                Team_B_Name = "Wärter",
                Team_B_Skin = "s_m_m_prisguard_01",
                Team_B_WinnerText = "Die Wärter gewinnen die Runde.",
                Team_B_Color = new int[] { 250,235,215 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(1714.0352f, 2665.8594f, 45.556763f),
                    new Vector3(1713.7847f, 2668.1538f, 45.556763f),
                    new Vector3(1711.8594f, 2668.0747f, 45.556763f),
                    new Vector3(1711.8462f, 2666.1758f, 45.556763f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
             },
              new RoundModel
            {
                Map_Name = "Biker",
                Team_A_Name = "SAMCRO",
                Team_A_Skin = "g_m_y_lost_03",
                Team_A_WinnerText = "SAMCRO gewinnt die Runde.",
                Team_A_Color = new int[] { 100, 50, 50 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(35.406593f, 3718.8396f, 39.524536f),
                    new Vector3(35.96044f, 3720.066f, 39.54138f),
                    new Vector3(37.60879f, 3719.6045f, 39.524536f),
                    new Vector3(38.584618f, 3717.9956f, 39.575073f),
                },
                Team_B_Name = "MayansMC",
                Team_B_Skin = "g_m_y_lost_01",
                Team_B_WinnerText = "Der MayansMC gewinnt die Runde.",
                Team_B_Color = new int[] { 193, 205, 193 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(103.62198f, 3717.9692f, 39.70984f),
                    new Vector3(101.03736f, 3718.4438f, 39.6593f),
                    new Vector3(100.52308f, 3717.4812f, 39.676147f),
                    new Vector3(101.98682f, 3717.3098f, 39.692993f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
              },
              new RoundModel
            {
                Map_Name = "Altruistendorf",
                Team_A_Name = "Altruisten",
                Team_A_Skin = "a_m_o_acult_01",
                Team_A_WinnerText = "Die Altruisten gewinnen die Runde.",
                Team_A_Color = new int[] { 100, 50, 50 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-1163.4198f, 4926.3955f, 222.95166f),
                    new Vector3(-1163.3143f, 4925.13f, 222.88428f),
                    new Vector3(-1161.5077f, 4924.879f, 222.8169f),
                    new Vector3(-1161.0989f, 4926.1055f, 222.86743f),
                },
                Team_B_Name = "Merryweather",
                Team_B_Skin = "s_m_m_chemsec_01",
                Team_B_WinnerText = "Merryweather gewinnt die Runde.",
                Team_B_Color = new int[] { 205, 55, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-1059.2439f, 4904.031f, 211.40955f),
                    new Vector3(-1059.3363f, 4905.7056f, 211.3927f),
                    new Vector3(-1061.2616f, 4905.4023f, 211.66223f),
                    new Vector3(-1061.4725f, 4903.8066f, 211.69592f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
              },
              new RoundModel
            {
                Map_Name = "Holzfäller",
                Team_A_Name = "Holzfäller",
                Team_A_Skin = "s_m_y_construct_01",
                Team_A_WinnerText = "Die Holzfäller gewinnen die Runde.",
                Team_A_Color = new int[] { 205 ,175, 149 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(-583.96484f, 5314.998f, 70.20801f),
                    new Vector3(-583.52966f, 5313.231f, 70.20801f),
                    new Vector3(-581.789f, 5313.1123f, 70.20801f),
                    new Vector3(-580.94507f, 5314.892f, 70.20801f),
                },
                Team_B_Name = "SAMCRO",
                Team_B_Skin = "g_m_y_lost_03",
                Team_B_WinnerText = "SAMCRO gewinnt die Runde.",
                Team_B_Color = new int[] { 100, 50, 50 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(-513.74506f, 5250.6196f, 80.2168f),
                    new Vector3(-512.9275f, 5253.099f, 80.621216f),
                    new Vector3(-512.3077f, 5255.8813f, 80.60437f),
                    new Vector3(-511.47693f, 5259.745f, 80.60437f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
              },
              new RoundModel
            {
                Map_Name = "U-Bahn",
                Team_A_Name = "S.W.A.T",
                Team_A_Skin = "s_m_y_swat_01",
                Team_A_WinnerText = "Das S.W.A.T gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 50, 183 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(129.00659f, -563.74945f, 22.017578f),
                    new Vector3(128.99341f, -565.5165f, 22.017578f),
                    new Vector3(131.8022f, -566.04395f, 22.017578f),
                    new Vector3(132.92308f, -565.0154f, 22.017578f),
                },
                Team_B_Name = "SAMCRO",
                Team_B_Skin = "g_m_y_lost_03",
                Team_B_WinnerText = "SAMCRO gewinnt die Runde.",
                Team_B_Color = new int[] { 100, 50, 50 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(170.51868f, -552.0791f, 21.967041f),
                    new Vector3(170.34726f, -553.7143f, 21.967041f),
                    new Vector3(169.33186f, -554.3472f, 21.967041f),
                    new Vector3(169.96483f, -555.6923f, 21.967041f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
                },
                new RoundModel
            {
                Map_Name = "Rennstrecke",
                Team_A_Name = "S.W.A.T",
                Team_A_Skin = "s_m_y_swat_01",
                Team_A_WinnerText = "Das S.W.A.T gewinnt die Runde.",
                Team_A_Color = new int[] { 0, 50, 183 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(1034.9407f, 2302.51f, 44.832275f),
                    new Vector3(1034.4528f, 2300.7693f, 44.832275f),
                    new Vector3(1033.8726f, 2298.765f, 44.81543f),
                    new Vector3(1032.5275f, 2299.0022f, 44.81543f),
                },
                Team_B_Name = "SAMCRO",
                Team_B_Skin = "g_m_y_lost_03",
                Team_B_WinnerText = "SAMCRO gewinnt die Runde.",
                Team_B_Color = new int[] { 100, 50, 50 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(1018.87915f, 2258.189f, 44.630005f),
                    new Vector3(1019.34064f, 2260.655f, 44.630005f),
                    new Vector3(1016.74286f, 2262.3032f, 44.832275f),
                    new Vector3(1014.55383f, 2259.3757f, 45.152344f),
                },
                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Vehicles = new List<VehicleModel>(),
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
                }

        };
    }
}
