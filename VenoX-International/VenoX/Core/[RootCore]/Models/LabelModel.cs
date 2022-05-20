namespace VenoX.Core._RootCore_.Models
{
    public class LabelModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Size { get; set; }
        public int Font { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public int ColorA { get; set; }
        public int Dimension { get; set; }
        public float Range { get; set; }
        public bool Translate { get; set; }
        public bool IsHouseLabel { get; set; }
        public int HouseLabelId { get; set; }
        public VnXPlayer VisibleOnlyFor { get; set; }


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
         *   Core.Globals.Functions.LabelList.Add(label);
         */
    }
}
