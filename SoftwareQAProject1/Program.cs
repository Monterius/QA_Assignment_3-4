using System;

namespace SoftwareQAProject1
{
    internal static class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Functions:\n \n1. Body Mass Index\n2. Retirement\n3. Exit Application");
                Console.Write("\nType the corresponding number to execute a function: ");

                if (!int.TryParse(Console.ReadLine(), out var function))
                {
                    Console.WriteLine("\nNot a valid number");
                    Main();
                }

                switch (function)
                {
                    case 1:
                        BodyMassIndexFunction();
                        break;
                    case 2:
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"Number {function} does not have a corresponding function");
                        continue;
                }
                break;
            }
        }

        private static void BodyMassIndexFunction()
        {
            Console.Write("\nHeight in decimal form (Ex. 5 foot 3 inches would be 5.25): ");

            if (!float.TryParse(Console.ReadLine(), out var height) || height < 0)
            {
                Console.WriteLine("\nNot a valid height");
                BodyMassIndexFunction();
            }
            
            Console.Write("\nWeight in pounds (lbs): ");

            if (!float.TryParse(Console.ReadLine(), out var pounds) || pounds < 0)
            {
                Console.WriteLine("\nNot a valid weight");
                BodyMassIndexFunction();
            }

            var output = BodyMassIndex.Calculate(height, pounds);
            Console.WriteLine($"\n{output}");
            Main();
        }
    }
}