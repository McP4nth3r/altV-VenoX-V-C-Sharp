using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;

namespace VenoXV._RootCore_.Models
{
    public class SyncClass
    {
        public List<LabelModel> CurrentLabels = new List<LabelModel>();
        public List<MarkerModel> CurrentMarker = new List<MarkerModel>();
        public List<ObjectModel> CurrentObjs = new List<ObjectModel>();
        public SyncClass(Player player)
        {
            try
            {
            }
            catch (Exception ex) { Core.Debug.CatchExceptions(ex); }
        }
    }

}
