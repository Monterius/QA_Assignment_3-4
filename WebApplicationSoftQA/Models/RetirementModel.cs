namespace WebApplicationSoftQA.Models
{
    public class RetirementModel
    {
        public int Age { get; set; }
        public int Salary { get; set; }
        public int SavingsGoal { get; set; }
        public float PercentSaved { get; set; }
        public string Results { get; }
        
        public RetirementModel(string results)
        {
            Results = results;
        }

        public RetirementModel() {}
    }
}