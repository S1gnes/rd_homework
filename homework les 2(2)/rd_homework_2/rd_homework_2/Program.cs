using System;

namespace rd_homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write 5 numbers:");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            int z = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int a = Convert.ToInt32(Console.ReadLine());
            int[] h = { x, y, z, b, a };
            int max = int.MinValue;
            int min = int.MaxValue;
            foreach (int number in h)
            {
                if (number > max)
                {
                    max = number;
                }
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine(max - min);
        }
    }
}
