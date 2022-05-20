namespace VenoX.Core._Gamemodes_.Reallife.model
{        // Tactics
    public class Tactics
    {
        public int Fid { get; set; }
        public string Kills { get; set; }
        public string Tode { get; set; }
        public string SpielzeitTactics { get; set; }
        public string SocialState { get; set; }
        public int ColorStorageTacticsR { get; set; }
        public int ColorStorageTacticsG { get; set; }
        public int ColorStorageTacticsB { get; set; }

    }
    public class Reallife
    {
        public int Fid { get; set; }
        public string Fraktion { get; set; }
        public int Lspd { get; set; }
        public int Lcn { get; set; }
        public int Yakuza { get; set; }
        public int News { get; set; }
        public int Fbi { get; set; }
        public int Vl { get; set; }
        public int Usarmy { get; set; }
        public int Samcro { get; set; }
        public int Medic { get; set; }
        public int Mechaniker { get; set; }
        public int Ballas { get; set; }
        public int Grove { get; set; }
        public int Totalplayers { get; set; }
        public int FactionColorR { get; set; }
        public int FactionColorG { get; set; }
        public int FactionColorB { get; set; }
    }

    public class ScoreboardModel
    {
        public int Fid { get; set; }
        public string SpielerName { get; set; }
        public string Spielzeit { get; set; }
        public string SozialerStatus { get; set; }
        public string Vip { get; set; }
        public string Ping { get; set; }

        public Reallife Reallife { get; }
        public Tactics Tactics { get; }
        public int VipColorR { get; set; }
        public int VipColorG { get; set; }
        public int VipColorB { get; set; }
    }
}
