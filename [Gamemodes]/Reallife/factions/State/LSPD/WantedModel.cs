namespace VenoXV._Gamemodes_.Reallife.factions.State.LSPD
{
    public class WantedModel
    {
        public string Reason { get; set; }
        public int Wanteds { get; set; }
        public string[] ShortReasons { get; set; }
        public string Description { get; set; }

        public WantedModel(string WantedReason, int WantedCount, string[] WantedShortReasons, string Description = "")
        {
            this.Reason = WantedReason;
            this.Wanteds = WantedCount;
            this.ShortReasons = WantedShortReasons;
            this.Description = Description;
        }
    }
}
