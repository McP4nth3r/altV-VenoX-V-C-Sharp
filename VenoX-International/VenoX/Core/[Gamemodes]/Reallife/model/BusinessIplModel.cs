using AltV.Net.Data;

namespace VenoX.Core._Gamemodes_.Reallife.model
{
    public class BusinessIplModel
    {
        public int Type { get; set; }
        public string Ipl { get; set; }
        public Position Position { get; set; }

        public BusinessIplModel(int type, string ipl, Position position)
        {
            this.Type = type;
            this.Ipl = ipl;
            this.Position = position;
        }
    }
}
