using System;

namespace SoftwareQAProject1
{
    public enum BmiCategory { Underweight, Normal, Overweight, Obese }
    public static class BodyMassIndex
    {
        public static string Calculate(float height, float weightInLbs)
        {
            var inches = height.ToInches();
            var meters = ((double) inches).ToMeters();
            var kg = weightInLbs.ToKilograms();
            var bmi = GetBmiValue(kg, meters);
            var category = GetCategory(bmi);
            
            return $"Height: {inches} inches\nWeight: {weightInLbs} lbs\nBMI: {bmi}\nBMI Category: {category.ToString()}";
        }

        public static BmiCategory GetCategory(float bmi)
        {
            if (bmi < 18.5f) return BmiCategory.Underweight;
            if (bmi >= 18.5f && bmi <= 24.9f) return BmiCategory.Normal;
            if (bmi >= 25f && bmi <= 29.9f) return BmiCategory.Overweight;
            return BmiCategory.Obese;
        }

        public static float GetBmiValue(float kg, double meters) => (float) Math.Round(kg / Math.Pow(meters, 2), 1);

        public static float ToInches(this float height) => (float) Math.Round(height * 12, 1);

        public static double ToMeters(this double inches) => Math.Round(inches * 0.025, 5);

        public static float ToKilograms(this float pounds) => (float) Math.Round(pounds * 0.45f, 2);
    }
}