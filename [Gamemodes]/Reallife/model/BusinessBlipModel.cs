namespace VenoXV._Gamemodes_.Reallife.model
{
    public class BusinessBlipModel
    {
        public int Id { get; set; }
        public int Blip { get; set; }

        public BusinessBlipModel(int id, int blip)
        {
            this.Id = id;
            this.Blip = blip;
        }
    }
}
