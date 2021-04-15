using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SoftwareQAProject1
{
    internal static class Program
    {
        private const string MainMenuKeyword = "MAIN";
        private const string ExitApplicationKeyword = "EXIT";
        private const string ClearConsoleKeyword = "CLEAR";
        
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            while (true)
            {
                Console.WriteLine("Available Functions:\n \n" +
                                  "1. Body Mass Index\n" +
                                  "2. Retirement\n" +
                                  $"3. Exit Application (or type '{ExitApplicationKeyword}')\n" +
                                  $"\nType '{ClearConsoleKeyword}' to clear the console window\n" +
                                  $"Type '{MainMenuKeyword}' at any point to go back to the main menu\n" +
                                  $"Type '{ExitApplicationKeyword}' at any point to exit the application");
                
                Console.Write("\nType the corresponding number to execute a function: ");

                var input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!int.TryParse(input, out var function))
                {
                    Console.WriteLine("\nNot a valid input\n");
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
                    default: Console.WriteLine($"\nNumber {function} does not have a corresponding function\n");
                        continue;
                }
                break;
            }
        }

        private static bool IsExitApplicationKeyword(this string value) => value.ToUpper() == ExitApplicationKeyword;

        private static bool IsMainMenuKeyword(this string value) => value.ToUpper() == MainMenuKeyword;

        private static bool IsClearConsoleKeyword(this string value) => value.ToUpper() == ClearConsoleKeyword;

        private static string TryEvaluateKeyword(string input, [CallerMemberName] string callerName = "")
        {
            if (input.IsClearConsoleKeyword())
            {
                Console.Clear();
                typeof(Program).GetMethod(callerName, BindingFlags.NonPublic | BindingFlags.Static)?.Invoke(null, null);
                return null;
            }
            if (input.IsExitApplicationKeyword()) { Environment.Exit(0); return null; }
            if (!input.IsMainMenuKeyword()) return input;
            
            Console.WriteLine();
            Main(); 
            return null;
        }

        private static void WriteOutput(string output)
        {
            Console.Clear();
            Console.WriteLine("\n-------------------------------------------\n");
            Console.WriteLine(output);
            Console.WriteLine("\n-------------------------------------------\n");
        }

        private static void BodyMassIndexFunction()
        {
            while (true)
            {
                Console.WriteLine("---------------- Body Mass Index ----------------\n");
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
                Console.WriteLine("---------------- Retirement ----------------\n");
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

                if (!float.TryParse(input, out var percentSaved) || percentSaved < 0)
                {
                    Console.WriteLine("Not a valid input");
                    RetirementFunction();
                    continue;
                }

                Console.Write("Enter desired savings goal: ");

                input = TryEvaluateKeyword(Console.ReadLine());
                if (input == null) return;

                if (!int.TryParse(input, out var goal) || goal < 0)
                {
                    Console.WriteLine("Not a valid input");
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