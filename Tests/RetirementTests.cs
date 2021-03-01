using SoftwareQAProject1;
using Xunit;

namespace Tests
{
    public class RetirementTests
    {
        [Theory]
        [InlineData(45, 100000, 0.15f, 500000, "Savings per year: $20,250\nYears until goal is meet: 25\nAge when goal will be meet: 70")]
        [InlineData(25, 65000, 0.10f, 1500000, "Savings per year: $8,775\nYears until goal is meet: 171\nGoal will not be meet")]
        public void get_age_for_savings_goal_test(int age, int salary, float percentageSaved, int savingsGoal, string output)
        {
            Assert.Equal(output, Retirement.CalculateAgeForSavingsGoal(age, salary, percentageSaved, savingsGoal));
        }

        [Theory]
        [InlineData(100000, 0.15f, 20250)]
        [InlineData(65000, 0.10f, 8775)]
        public void savings_per_year_test(int salary, float percentSaved, int output)
        {
            Assert.Equal(output, Retirement.GetSavingsPerYear(salary, percentSaved));
        }

        [Theory]
        [InlineData(500000, 20250, 25)]
        [InlineData(1500000,8775, 171)]
        public void years_until_goal_meet_test(int goal, int savingsPerYear, int output)
        {
            Assert.Equal(output, Retirement.GetYearsUntilGoalMeet(goal, savingsPerYear));
        }

        [Theory]
        [InlineData(45, 25, 70)]
        public void age_when_goal_meet_test(int age, int yearsTil, int output)
        {
            Assert.Equal(output, Retirement.GetAgeWhenGoalMeet(age, yearsTil));
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(100, false)]
        [InlineData(50, true)]
        public void is_accepted_age_test(int age, bool result)
        {
            Assert.Equal(result, age.IsAcceptedAge());
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(100000, true)]
        [InlineData(500001, false)]
        public void is_accepted_salary_test(int salary, bool result)
        {
            Assert.Equal(result, salary.IsAcceptedSalary());
        }

        [Theory]
        [InlineData(99, true)]
        [InlineData(101, false)]
        [InlineData(68, true)]
        public void can_meet_goal_test(int age, bool result)
        {
            Assert.Equal(result, Retirement.CanMeetGoal(age));
        }
    }
}