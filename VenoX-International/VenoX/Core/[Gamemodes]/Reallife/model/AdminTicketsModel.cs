namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class AdminTickets
    {
        public int Id { get; set; }
        public int PlayerSqlid { get; set; }

        public string PlayerSocialClub { get; set; }

        public string PlayerName { get; set; }

        public string Betreff { get; set; }

        public string Frage { get; set; }

        public string Status { get; set; }
    }
}
