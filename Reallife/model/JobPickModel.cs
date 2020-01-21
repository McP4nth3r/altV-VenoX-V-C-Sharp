using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;

namespace VenoXV.Reallife.model
{
    public class JobPickModel
    {
        public string job { get; set; }
        public Position position { get; set; }
        public string deIScription { get; set; }

        public JobPickModel(string job, Position position, string deIScription)
        {
            this.job = job;
            this.position = position;
            this.deIScription = deIScription;
        }
    }
}
