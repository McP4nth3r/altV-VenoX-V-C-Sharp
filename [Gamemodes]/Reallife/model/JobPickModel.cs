using AltV.Net.Data;

namespace VenoXV._Gamemodes_.Reallife.model
{
    public class JobPickModel
    {
        public string Job { get; set; }
        public Position Position { get; set; }
        public string Description { get; set; }

        public JobPickModel(string job, Position position, string description)
        {
            this.Job = job;
            this.Position = position;
            this.Description = description;
        }
    }
}
