using System;

namespace VenoXV.Models
{
    public class LoadingModel
    {
        // Preload
        public DateTime EventSend { get; set; }
        public string EventText { get; set; }
        public string EventName { get; set; }
        public object[] EventArgs { get; set; }
        public bool Send { get; set; }
    }
}
