using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Discord
    {
        private Player Player;
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string Avatar { get; set; }
        public string Discriminator { get; set; }

        public Discord(Player player)
        {
            try
            {
                Player = player;
                ID = String.Empty;
                Name = String.Empty;
                IsOpen = false;
                Avatar = String.Empty;
                Discriminator = String.Empty;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }
}
