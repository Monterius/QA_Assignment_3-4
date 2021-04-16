namespace WebApplicationSoftQA.Models
{
    public class BmiModel
    {
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Results { get; }

        public BmiModel(string results)
        {
            Results = results;
        }

        public BmiModel() {}
    }
}