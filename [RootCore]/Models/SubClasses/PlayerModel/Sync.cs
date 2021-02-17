using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using VenoXV._Gamemodes_.Reallife.model;
using VenoXV.Core;

namespace VenoXV._RootCore_.Models
{
    public class SyncClass
    {
        public List<LabelModel> CurrentLabels = new List<LabelModel>();
        public List<MarkerModel> CurrentMarker = new List<MarkerModel>();
        public List<ObjectModel> CurrentObjs = new List<ObjectModel>();
        public List<ItemModel> CurrentNearbyItems = new List<ItemModel>();
        public SyncClass(Player player)
        {
            try
            {
            }
            catch (Exception ex) { Debug.CatchExceptions(ex); }
        }
    }

}
