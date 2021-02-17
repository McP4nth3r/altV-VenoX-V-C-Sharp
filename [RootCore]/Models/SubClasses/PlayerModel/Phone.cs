using System;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class Phone
    {
        private Player _player;
        public int Number { get; set; }
        public bool IsCallActive { get; set; }
        public Phone(Player player)
        {
            try
            {
                _player = player;

            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }

}
