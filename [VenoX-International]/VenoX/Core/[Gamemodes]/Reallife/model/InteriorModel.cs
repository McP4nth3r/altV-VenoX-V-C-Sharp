using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class InteriorModel
    {
        public string CaptionMessage { get; set; }
        public Position EntrancePosition { get; set; }
        public Position ExitPosition { get; set; }
        public string IplName { get; set; }
        public int BlipId { get; set; }
        public Blip Blip { get; set; }
       
        //public TextLabel textLabel { get; set; }
        //public TextLabel textLabel { get; set; }
        public string BlipName { get; set; }

        public int LabelRgbaR { get; set; }
        public int LabelRgbaG { get; set; }
        public int LabelRgbaB { get; set; }
        public int BlipRgba { get; set; }

        public InteriorModel(string captionMessage, Position entrancePosition, Position exitPosition, string iplName, int blipId, string blipName, int labelRgbaR, int labelRgbaG, int labelRgbaB, int blipRgba)
        {
            this.CaptionMessage = captionMessage;
            this.EntrancePosition = entrancePosition;
            this.ExitPosition = exitPosition;
            this.IplName = iplName;
            this.BlipId = blipId;
            this.BlipName = blipName;
            this.LabelRgbaR = labelRgbaR;
            this.LabelRgbaG = labelRgbaG;
            this.LabelRgbaB = labelRgbaB;
            this.BlipRgba = blipRgba;
        }
    }
}
