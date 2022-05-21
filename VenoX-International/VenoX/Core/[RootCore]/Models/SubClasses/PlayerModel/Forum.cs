using System;
using AltV.Net.Elements.Entities;
using VenoX.Debug;

namespace VenoX.Core._RootCore_.Models.SubClasses.PlayerModel
{
    public class Forum
    {
        private Player _player;
        public int Uid { get; set; }
        public Forum(Player player)
        {
            try
            {
                _player = player;
                Uid = -1;
            }
            catch (Exception ex) { ExceptionHandling.CatchExceptions(ex); }
        }
    }

}
