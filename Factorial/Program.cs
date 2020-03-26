using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        public static int Main(string[] args)
        {
			try
			{
				int number = Convert.ToInt32(args[0]);
				if (number ==0)
				{
					Console.WriteLine("Factorial =1");
				}
				else if(number < 0)
				{
					Console.WriteLine("Please enter Positive number");
				}
				else
				{
					double fac = 1;
					for (int i = 1; i <= number; i++)
					{
						fac *= i;
					}
					Console.WriteLine($"Factorial of{number} is {fac}" );
				}
				return 0;

			}
			catch (OverflowException)
			{
				Console.WriteLine($"number must be between 0 and {int.MaxValue}");
				return 1;
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalide number");
				return 1;
			}
			catch (Exception)
			{
				Console.WriteLine("There is a problem plz try later");
				return 1;
			}
		}
    }
}
