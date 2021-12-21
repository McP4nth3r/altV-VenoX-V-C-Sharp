namespace VenoXV._Gamemodes_.Reallife.factions.State.LSPD
{
    public class WantedModel
    {
        public string Reason { get; set; }
        public int Wanteds { get; set; }
        public string[] ShortReasons { get; set; }
        public string Description { get; set; }

        public WantedModel(string wantedReason, int wantedCount, string[] wantedShortReasons, string description = "")
        {
            Reason = wantedReason;
            Wanteds = wantedCount;
            ShortReasons = wantedShortReasons;
            this.Description = description;
        }
    }
}
