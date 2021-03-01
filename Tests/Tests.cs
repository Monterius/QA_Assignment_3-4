using System;
using SoftwareQAProject1;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(5.25f, 125, 22.7, BmiCategory.Normal)]
        public void body_mass_index_calculator_returns_correct_output(float heightFeet, float weightLbs, float bmi, BmiCategory category)
        {
            Assert.Equal($"Height: {heightFeet.ToInches()} inches\tWeight: {weightLbs} lbs\tBMI: {bmi}.\nYou are {category.ToString()}",
                BodyMassIndex.Calculate(5.25f, 125));
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
        public void get_bmi_value_test(float kg, float meters, float bmi)
        {
            Assert.Equal(bmi, BodyMassIndex.GetBmiValue(kg, meters));
        }

        [Theory]
        [InlineData(5.25f, 63f)]
        public void convert_to_inches_test(float feet, float inches)
        {
            Assert.Equal(inches, feet.ToInches());
        }

        [Theory]
        [InlineData(63f, 1.575f)]
        public void convert_to_meters_test(float inches, float meters)
        {
            Assert.Equal(meters, inches.ToMeters());
        }

        [Theory]
        [InlineData(125, 56.25f)]
        public void convert_to_kilograms_test(float lbs, float kg)
        {
            Assert.Equal(kg, lbs.ToKilograms());
        }
    }
}