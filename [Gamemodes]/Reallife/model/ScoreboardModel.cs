namespace VenoXV._Gamemodes_.Reallife.model
{        // Tactics
    public class Tactics
    {
        public int FID { get; set; }
        public string kills { get; set; }
        public string tode { get; set; }
        public string SpielzeitTactics { get; set; }
        public string SocialState { get; set; }
        public int ColorStorageTacticsR { get; set; }
        public int ColorStorageTacticsG { get; set; }
        public int ColorStorageTacticsB { get; set; }

    }
    public class Reallife
    {
        public int FID { get; set; }
        public string Fraktion { get; set; }
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
        public int FactionColorR { get; set; }
        public int FactionColorG { get; set; }
        public int FactionColorB { get; set; }
    }

    public class ScoreboardModel
    {
        public int FID { get; set; }
        public string SpielerName { get; set; }
        public string Spielzeit { get; set; }
        public string SozialerStatus { get; set; }
        public string VIP { get; set; }
        public string Ping { get; set; }

        public Reallife Reallife { get; }
        public Tactics Tactics { get; }
        public int VIP_COLOR_R { get; set; }
        public int VIP_COLOR_G { get; set; }
        public int VIP_COLOR_B { get; set; }
    }
}
