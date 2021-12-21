using System;

namespace VenoXV._Preload_.Model
{
    public class BanModel
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string HardwareId { get; set; }
        public string HardwareIdExHash { get; set; }
        public string SocialClubId { get; set; }
        public string Ip { get; set; }
        public string DiscordId { get; set; }
        public string Admin { get; set; }
        public DateTime BannedTill { get; set; }
        public DateTime BanCreated { get; set; }
        public string Reason { get; set; }
        public string BanType { get; set; }
    }
}
