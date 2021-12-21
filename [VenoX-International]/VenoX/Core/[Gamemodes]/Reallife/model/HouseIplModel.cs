using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class HouseIplModel
    {
        public string Ipl { get; set; }
        public Position Position { get; set; }

        public HouseIplModel(string ipl, Position position)
        {
            this.Ipl = ipl;
            this.Position = position;
        }
    }
}
