using System;
using AltV.Net.Elements.Entities;
using VenoXV.Core;

namespace VenoXV.Models.SubClasses.PlayerModel
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
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }

}
