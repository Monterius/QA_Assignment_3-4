using System;

namespace SoftwareQAProject1
{
    internal static class Program
    {
        private const string MainMenuKeyword = "MAIN";
        private const string ExitApplicationKeyword = "EXIT";
        
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Available Functions:\n \n" +
                                  "1. Body Mass Index\n" +
                                  "2. Retirement\n" +
                                  "3. Exit Application (or type 'EXIT')\n" +
                                  "\nType 'MAIN' at any point to go back to the main menu\n" +
                                  "Type 'EXIT' at any point to exit the application");
                
                Console.Write("\nType the corresponding number to execute a function: ");

                var input = Console.ReadLine();
                if (input.IsExitApplicationKeyword()) Environment.Exit(0);
                if (input.IsMainMenuKeyword()) { Main(); return; }

                if (!int.TryParse(input, out var function))
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

        private static bool IsExitApplicationKeyword(this string value) => value.ToUpper() == ExitApplicationKeyword;

        private static bool IsMainMenuKeyword(this string value) => value.ToUpper() == MainMenuKeyword;

        private static string TryEvaluateKeyword(string input)
        {
            if (input.IsExitApplicationKeyword()) { Environment.Exit(0); return null; }
            if (input.IsMainMenuKeyword()) { Main(); return null; }
            return input;
        }

        private static void WriteOutput(string output)
        {
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine(output);
            Console.WriteLine("-------------------------------------------\n");
        }

        private static void BodyMassIndexFunction()
        {
            while (true)
            {
                Console.WriteLine("---------- Body Mass Index ----------\n");
                Console.Write("Height in decimal form (Ex. 5 foot 3 inches would be 5.25): ");

                var input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!float.TryParse(input, out var height) || height < 0)
                {
                    Console.WriteLine("Not a valid height");
                    continue;
                }

                Console.Write("Weight in pounds (lbs): ");

                input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!float.TryParse(input, out var pounds) || pounds < 0)
                {
                    Console.WriteLine("Not a valid weight");
                    continue;
                }

                var output = BodyMassIndex.Calculate(height, pounds);
                WriteOutput(output);
                Main();
                break;
            }
        }

        private static void RetirementFunction()
        {
            while (true)
            {
                Console.WriteLine("---------- Retirement ----------\n");
                Console.Write("Enter age: ");

                var input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!int.TryParse(input, out var age))
                {
                    Console.WriteLine("Not a valid integer");
                    RetirementFunction();
                    continue;
                }

                Console.Write("Enter salary: ");

                input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!int.TryParse(input, out var salary))
                {
                    Console.WriteLine("Not a valid integer");
                    RetirementFunction();
                    continue;
                }

                Console.Write("Enter percentage saved in decimal form (Ex. 25% = 0.25): ");

                input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!float.TryParse(input, out var percentSaved))
                {
                    Console.WriteLine("Not a valid float");
                    RetirementFunction();
                    continue;
                }

                Console.Write("Enter desired savings goal: ");

                input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!int.TryParse(input, out var goal))
                {
                    Console.WriteLine("Not a valid integer");
                    continue;
                }

                var output = Retirement.CalculateAgeForSavingsGoal(age, salary, percentSaved, goal);
                WriteOutput(output);
                Main();
                break;
            }
        }
    }
}