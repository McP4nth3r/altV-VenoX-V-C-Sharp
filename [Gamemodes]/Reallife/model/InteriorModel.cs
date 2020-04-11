using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class InteriorModel
    {
        public string captionMessage { get; set; }
        public Position entrancePosition { get; set; }
        public Position exitPosition { get; set; }
        public string iplName { get; set; }
        public int blipId { get; set; }
        public Blip blip { get; set; }
       
        //public TextLabel textLabel { get; set; }
        //public TextLabel textLabel { get; set; }
        public string blipName { get; set; }

        public int labelRgbaR { get; set; }
        public int labelRgbaG { get; set; }
        public int labelRgbaB { get; set; }
        public int BlipRgba { get; set; }

        public InteriorModel(string captionMessage, Position entrancePosition, Position exitPosition, string iplName, int blipId, string blipName, int labelRgbaR, int labelRgbaG, int labelRgbaB, int BlipRgba)
        {
            this.captionMessage = captionMessage;
            this.entrancePosition = entrancePosition;
            this.exitPosition = exitPosition;
            this.iplName = iplName;
            this.blipId = blipId;
            this.blipName = blipName;
            this.labelRgbaR = labelRgbaR;
            this.labelRgbaG = labelRgbaG;
            this.labelRgbaB = labelRgbaB;
            this.BlipRgba = BlipRgba;
        }
    }
}
