using SoftwareQAProject1;
using Xunit;

namespace Tests
{
    public class BmiTests
    {
        [Theory]
        [InlineData(5.25f, 125, 22.7, BmiCategory.Normal)]
        [InlineData(6.3f, 173, 21.8, BmiCategory.Normal)]
        [InlineData(5.3f, 98, 17.4, BmiCategory.Underweight)]
        [InlineData(5.8f, 199, 29.6, BmiCategory.Overweight)]
        [InlineData(5.5f, 215, 35.5, BmiCategory.Obese)]
        public void body_mass_index_calculator_returns_correct_output(float heightFeet, float weightLbs, float bmi, BmiCategory category)
        {
            Assert.Equal($"Height: {heightFeet.ToInches()} inches\nWeight: {weightLbs} lbs\nBMI: {bmi}\nBMI Category: {category.ToString()}",
                BodyMassIndex.Calculate(heightFeet, weightLbs));
        }

        [Theory]
        [InlineData(22.7f, BmiCategory.Normal)]
        [InlineData(17.6f, BmiCategory.Underweight)]
        [InlineData(28, BmiCategory.Overweight)]
        [InlineData(38.5f, BmiCategory.Obese)]
        public void bmi_category_test(float bmi, BmiCategory category)
        {
            Assert.Equal(category, BodyMassIndex.GetCategory(bmi));
        }

        [Theory]
        [InlineData(56.25f, 1.575f, 22.7f)]
        [InlineData(33.7f, 1.682f, 11.9f)]
        public void get_bmi_value_test(float kg, float meters, float bmi)
        {
            Assert.Equal(bmi, BodyMassIndex.GetBmiValue(kg, meters));
        }

        [Theory]
        [InlineData(5.25f, 63f)]
        [InlineData(5.3f, 63.6f)]
        [InlineData(5.5f, 66f)]
        [InlineData(5.8f, 69.6f)]
        [InlineData(6.3f, 75.6f)]
        public void convert_to_inches_test(float feet, float inches)
        {
            Assert.Equal(inches, feet.ToInches());
        }

        [Theory]
        [InlineData(63, 1.575)]
        [InlineData(66, 1.65)]
        [InlineData(69.6, 1.74)]
        [InlineData(75.6, 1.89)]
        public void convert_to_meters_test(double inches, double meters)
        {
            Assert.Equal(meters, inches.ToMeters());
        }

        [Theory]
        [InlineData(125, 56.25f)]
        [InlineData(199, 89.55f)]
        public void convert_to_kilograms_test(float lbs, float kg)
        {
            Assert.Equal(kg, lbs.ToKilograms());
        }
    }
}