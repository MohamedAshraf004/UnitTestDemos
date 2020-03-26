using System;

namespace Calculator
{
    public class Calculator
    {
        public static double Divide(double numerator,double denominator)
        {
            return numerator / denominator;
        }
        private static bool IsPositive(int number)
        {
            return number > 0;
        }
        private bool IsNigative(int number)
        {
            return number < 0;
        }
    }
}
