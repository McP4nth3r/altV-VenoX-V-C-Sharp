namespace VenoXV._Gamemodes_.Reallife.factions.State.LSPD
{
    public class WantedModel
    {
        public string Reason { get; set; }
        public int Wanteds { get; set; }
        public WantedModel(string WantedReason, int WantedCount)
        {
            this.Reason = WantedReason;
            this.Wanteds = WantedCount;
        }
    }
}
