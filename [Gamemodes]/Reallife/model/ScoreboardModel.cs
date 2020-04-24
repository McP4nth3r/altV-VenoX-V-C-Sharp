using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class ScoreboardModel
    {
        public int FID { get; set; }
        public int FIDTactics { get; set; }
        public string SpielerName { get; set; }
        public string Spielzeit { get; set; }
        public string SpielzeitTactics { get; set; }
        public string SozialerStatus { get; set; }
        public string SozialerStatusTactics { get; set; }
        public string VIP { get; set; }
        public string Fraktion { get; set; }
        public string Ping { get; set; }


        // Tactics
        public string kills { get; set; }
        public string tode { get; set; }

        public int ColorStorageR { get; set; }
        public int ColorStorageG { get; set; }
        public int ColorStorageB { get; set; }        
        
        public int ColorStorageTacticsR { get; set; }
        public int ColorStorageTacticsG { get; set; }
        public int ColorStorageTacticsB { get; set; }

        public int ColorStorageVR { get; set; }
        public int ColorStorageVG { get; set; }
        public int ColorStorageVB { get; set; }






        public int LSPD { get; set; }
        public int LCN { get; set; }
        public int YAKUZA { get; set; }
        public int NEWS { get; set; }
        public int FBI { get; set; }
        public int VL { get; set; }
        public int USARMY { get; set; }
        public int SAMCRO { get; set; }
        public int MEDIC { get; set; }
        public int MECHANIKER { get; set; }
        public int BALLAS { get; set; }
        public int GROVE { get; set; }
        public int TOTALPLAYERS { get; set; }
    }
}
