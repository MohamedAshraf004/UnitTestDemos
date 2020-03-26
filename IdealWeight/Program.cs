using System;

namespace IdealWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightCalculator weightCalculator = new WeightCalculator() { Height = 175, Gender = 'w' };
            double weight = weightCalculator.GetIdealBodyWeight();
            Console.WriteLine($"The ideal body weight {weight}");
            if (weight==62.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeeded");
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
            }
            weightCalculator.Gender = 'm';
            weight = weightCalculator.GetIdealBodyWeight();
            if (weight == 62.5)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeeded");
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed");
            }
            Console.ReadKey();
        }
    }
}
