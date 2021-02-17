using System;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Discord
    {
        private Player _player;
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public string Avatar { get; set; }
        public string Discriminator { get; set; }

        public Discord(Player player)
        {
            try
            {
                _player = player;
                Id = String.Empty;
                Name = String.Empty;
                IsOpen = false;
                Avatar = String.Empty;
                Discriminator = String.Empty;
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }
}
