namespace VenoXV._Gamemodes_.Reallife.model
{
    public class JobModel
    {
        public string DescriptionMale { get; set; }
        public string DescriptionFemale { get; set; }
        public int Job { get; set; }
        public int Salary { get; set; }

        public JobModel(string descriptionMale, string descriptionFemale, int job, int salary)
        {
            this.DescriptionMale = descriptionMale;
            this.DescriptionFemale = descriptionFemale;
            this.Job = job;
            this.Salary = salary;
        }
    }
}
