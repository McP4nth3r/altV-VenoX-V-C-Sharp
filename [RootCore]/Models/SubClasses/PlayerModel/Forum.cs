using AltV.Net.Elements.Entities;
using System;

namespace VenoXV._RootCore_.Models
{
    public class Forum
    {
        private Player Player;
        public int UID { get; set; }
        public Forum(Player player)
        {
            try
            {
                Player = player;
                UID = -1;
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

}
