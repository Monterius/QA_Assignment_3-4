using System;

namespace SoftwareQAProject1
{
    public static class Retirement
    {
        public static string CalculateAgeForSavingsGoal(int age, int salary, float percentageSaved, int savingsGoal)
        {
            if (!age.IsAcceptedAge()) return "Not an accepted age! Must be greater than 0 and less than 100";
            if (!salary.IsAcceptedSalary()) return "Not an accepted salary! Must be greater than $0 and less than $500,000";

            var spy = GetSavingsPerYear(salary, percentageSaved);
            var yearsTilGoalMeet = GetYearsUntilGoalMet(savingsGoal, spy);
            var ageWhenGoalMet = GetAgeWhenGoalMet(age, yearsTilGoalMeet);

            return CanMeetGoal(ageWhenGoalMet)
                ? $"Savings per year: {spy:C0}\nYears until goal is meet: {yearsTilGoalMeet}\nAge when goal will be meet: {ageWhenGoalMet}"
                : $"Savings per year: {spy:C0}\nYears until goal is meet: {yearsTilGoalMeet}\nGoal will not be meet";
        }

        public static int GetSavingsPerYear(int salary, float percentSaved) => (int) (salary * percentSaved * 1.35f);

        public static int GetYearsUntilGoalMet(float goal, float savingsPerYear) => (int) Math.Round(goal / savingsPerYear, 0);
        
        public static int GetAgeWhenGoalMet(int age, int yearsTil) => age + yearsTil;

        public static bool IsAcceptedAge(this int age) => age > 0 && age < 100;

        public static bool IsAcceptedSalary(this int salary) => salary > 0 && salary <= 500000;

        public static bool CanMeetGoal(int ageWhenGoalMeet) => ageWhenGoalMeet < 100;
    }
}