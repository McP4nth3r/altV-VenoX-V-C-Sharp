using System.Collections.Generic;
using System.Numerics;

namespace VenoXV.Tactics.model
{
    public class RoundModel
    {
        public string Map_Name { get; set; }
        public List<Vector3> Team_A_Spawnpoints { get; set; }
        public List<Vector3> Team_B_Spawnpoints { get; set; }
        public string Team_A_Name { get; set; }
        public string Team_B_Name { get; set; }
        public int[] Team_A_Color { get; set; }
        public int[] Team_B_Color { get; set; }
        public string Team_A_Skin { get; set; }
        public string Team_B_Skin { get; set; }
        public bool Custom_Weapon_Map { get; set; }
        public List<AltV.Net.Enums.WeaponModel> Custom_Weapons { get; set; }
        public List<VehicleModel> Custom_Vehicles { get; set; }
        public string Custom_Weapon_Mode_Name { get; set; }
        public string Team_A_WinnerText { get; set; }
        public string Team_B_WinnerText { get; set; }
    }
}
