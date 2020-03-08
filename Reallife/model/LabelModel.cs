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
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Size { get; set; }
        public int Font { get; set; }
        public Rgba LabelColor { get; set; }
        public int Dimension { get; set; }
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
