using System;

namespace homework_les_2_1_
{
    class Program
    {
        static string SplitNumber(int number)
        {
            string result = "";

            while (number > 0)
            {
                int digit = number % 10;
                result = digit + " " + result;
                number /= 10;
            }

            return result;
        }
        static void Main(string[] args)
        {
            bool banana = true;
            while (banana)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= 10000 && number <= 99999)
                {
                    Console.WriteLine(SplitNumber(number));
                }
                else
                {
                    Console.WriteLine("Number is NOT five digit");
                }
            }
        }    
    }
}
