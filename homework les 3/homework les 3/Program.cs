using System;

namespace ConsoleApp12
{
    class Program
    {
        static bool CheckIfPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            int divisor = 2;

            while (number > divisor)
            {
                if (number % divisor == 0)
                {
                    return false;
                }

                divisor++;
            }

            return true;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                bool isPrime = CheckIfPrime(number);
                if (isPrime)
                {
                    Console.WriteLine(number + " is a prime number");
                }
                else
                {
                    Console.WriteLine(number + " is NOT a prime number");
                }
            }
        }
    }
}
