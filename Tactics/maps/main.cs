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
                Team_B_Color = new int[] { 0, 152, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(3077.715f, -4795.332f, 15.2613f),
                    new Vector3(3090.292f, -4791.002f, 15.26161f),
                    new Vector3(3097.125f, -4786.874f, 15.26162f),
                    new Vector3(3090.783f, -4792.346f, 15.26162f),
                },


                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),

            },
            new RoundModel
            {
                Map_Name = "L.S.P.D",
                Team_A_Name = "S.W.A.T",
                Team_A_Skin = "s_m_y_swat_01",
                Team_A_Color = new int[] { 0, 50, 183 },
                Team_A_Spawnpoints = new List<Vector3>{
                    new Vector3(438.94946f,  -991.5033f,  30.678345f),
                    new Vector3(439.06815f,  -993.7846f,  30.678345f),
                    new Vector3(438.94946f,  -995.7758f,  30.678345f),
                    new Vector3(440.822f,    -994.8659f,  30.678345f),
                },
                Team_B_Name = "Yakuza",
                Team_B_Skin = "s_f_y_stripper_01",
                Team_B_Color = new int[] { 152, 0, 0 },
                Team_B_Spawnpoints = new List<Vector3>{
                    new Vector3(378.8176f,  -954.4352f, 29.296753f),
                    new Vector3(378.56705f, -956.5187f, 29.397827f),
                    new Vector3(378.40878f, -958.7341f, 29.313599f),
                    new Vector3(368.58463f, -956.0967f, 29.431519f),
                },

                Custom_Weapon_Map = false,
                Custom_Weapon_Mode_Name = "",
                Custom_Weapons = new List<AltV.Net.Enums.WeaponModel>(),
            },

        };
    }
}
