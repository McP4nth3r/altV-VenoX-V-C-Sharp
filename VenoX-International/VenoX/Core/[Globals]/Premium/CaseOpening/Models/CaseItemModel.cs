using System.Collections.Generic;

namespace VenoX.Core._Globals_.Premium.CaseOpening.Models
{
    public class Items
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Url { get; set; }

    }
    public class CaseItemModel
    {
        public string Type { get; set; }
        public List<Items> Items { get; set; }
    }
}
