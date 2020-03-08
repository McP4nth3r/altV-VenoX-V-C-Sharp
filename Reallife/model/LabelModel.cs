using AltV.Net.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace VenoXV.Reallife.model
{
    public class LabelModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }
        public int Color { get; set; }
        public float Range { get; set; }

        /*
         * public static List<LabelModel> LabelList = new List<LabelModel>();
         * 
         *   LabelModel label = new LabelModel();
         *   Position pos = LSPD;
         *   label.Name = "Test";
         *   label.Text = "VenoX ist kuhl";
         *   label.posX = pos.X;
         *   label.posY = pos.Y;
         *   label.posZ = pos.Z;
         *   label.Color = 3;
         *   label.Range = 3.5;
         *   VenoXV.Globals.Functions.LabelList.Add(label);
         */
    }
}
