using System;
using System.Threading;

class Program
{
    static object lockA = new object();
    static object lockB = new object();
    static object lockC = new object();
    static int count = 0;
    static int maxCount = 10;

    static void Main(string[] args)
    {
        Thread threadA = new Thread(PrintA);
        Thread threadB = new Thread(PrintB);
        Thread threadC = new Thread(PrintC);

        threadA.Start();
        threadB.Start();
        threadC.Start();

        threadA.Join();
        threadB.Join();
        threadC.Join();
    }

    static void PrintA()
    {
        while (count < maxCount)
        {
            lock (lockA)
            {
                if (count % 3 == 0)
                {
                    Console.WriteLine("A");
                    count++;
                }
            }
        }
    }

    static void PrintB()
    {
        while (count < maxCount)
        {
            lock (lockB)
            {
                if (count % 3 == 1)
                {
                    Console.WriteLine("B");
                    count++;
                }
            }
        }
    }

    static void PrintC()
    {
        while (count < maxCount)
        {
            lock (lockC)
            {
                if (count % 3 == 2)
                {
                    Console.WriteLine("C");
                    count++;
                }
            }
        }
    }
}
