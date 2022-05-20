using System;
using AltV.Net.Elements.Entities;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
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
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }

}
