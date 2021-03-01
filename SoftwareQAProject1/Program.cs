using System;

namespace SoftwareQAProject1
{
    internal static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Available Functions:\n \n1. Body Mass Index\n2. Retirement\n3. Exit Application");
                Console.Write("\nType the corresponding number to execute a function: ");

                if (!int.TryParse(Console.ReadLine(), out var function))
                {
                    Console.WriteLine("Not a valid number");
                    Main();
                }
                
                Console.WriteLine();

                switch (function)
                {
                    case 1: BodyMassIndexFunction();
                        break;
                    case 2: RetirementFunction();
                        break;
                    case 3: Environment.Exit(0);
                        break;
                    default: Console.WriteLine($"Number {function} does not have a corresponding function");
                        continue;
                }
                break;
            }
        }

        private static void BodyMassIndexFunction()
        {
            Console.Write("Height in decimal form (Ex. 5 foot 3 inches would be 5.25): ");

            if (!float.TryParse(Console.ReadLine(), out var height) || height < 0)
            {
                Console.WriteLine("Not a valid height");
                BodyMassIndexFunction();
            }
            
            Console.Write("Weight in pounds (lbs): ");

            if (!float.TryParse(Console.ReadLine(), out var pounds) || pounds < 0)
            {
                Console.WriteLine("Not a valid weight");
                BodyMassIndexFunction();
            }

            var output = BodyMassIndex.Calculate(height, pounds);
            Console.WriteLine($"\n{output}\n");
            Main();
        }

        private static void RetirementFunction()
        {
            Console.Write("Enter age: ");

            if (!int.TryParse(Console.ReadLine(), out var age))
            {
                Console.WriteLine("Not a valid integer");
                RetirementFunction();
            }
            
            Console.Write("Enter salary: ");

            if (!int.TryParse(Console.ReadLine(), out var salary))
            {
                Console.WriteLine("Not a valid integer");
                RetirementFunction();
            }
            
            Console.Write("Enter percentage saved in decimal form (Ex. 25% = 0.25): ");

            if (!float.TryParse(Console.ReadLine(), out var percentSaved))
            {
                Console.WriteLine("Not a valid float");
            }
            
            Console.Write("Enter desired savings goal: ");
            
            if (!int.TryParse(Console.ReadLine(), out var goal))
            {
                Console.WriteLine("Not a valid integer");
                RetirementFunction();
            }

            var output = Retirement.CalculateAgeForSavingsGoal(age, salary, percentSaved, goal);
            Console.WriteLine($"\n{output}\n");
            Main();
        }
    }
}