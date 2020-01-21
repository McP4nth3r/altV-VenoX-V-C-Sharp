using System;

namespace VenoXV.Reallife.model
{
    public class JobModel
    {
        public string deIScriptionMale { get; set; }
        public string deIScriptionFemale { get; set; }
        public int job { get; set; }
        public int salary { get; set; }

        public JobModel(string deIScriptionMale, string deIScriptionFemale, int job, int salary)
        {
            this.deIScriptionMale = deIScriptionMale;
            this.deIScriptionFemale = deIScriptionFemale;
            this.job = job;
            this.salary = salary;
        }
    }
}
