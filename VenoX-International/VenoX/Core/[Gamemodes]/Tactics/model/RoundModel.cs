using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Enums;

namespace VenoX.Core._Gamemodes_.Tactics.model
{
    public class RoundModel
    {
        public string MapName { get; set; }
        public List<Vector3> TeamASpawnpoints { get; set; }
        public List<Vector3> TeamBSpawnpoints { get; set; }
        public string TeamAName { get; set; }
        public string TeamBName { get; set; }
        public int[] TeamAColor { get; set; }
        public int[] TeamBColor { get; set; }
        public string TeamASkin { get; set; }
        public string TeamBSkin { get; set; }
        public bool CustomWeaponMap { get; set; }
        public List<WeaponModel> CustomWeapons { get; set; }
        public List<MapVehicleModel> CustomVehicles { get; set; }
        public string CustomWeaponModeName { get; set; }
        public string TeamAWinnerText { get; set; }
        public string TeamBWinnerText { get; set; }
    }
}
