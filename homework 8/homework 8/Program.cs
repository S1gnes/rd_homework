using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace generics_lol
{
    internal abstract class Program
    {
        private static int FindElement(IReadOnlyList<object> arr, object val)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                if (arr[i] == val) { return i; };
            }
            return -1;
        }

        private static int FindElement(IReadOnlyList<int> arr, int val)
        {
            for (var i = 0; i < arr.Count; i++)
            {
                if (arr[i] == val) { return i; };
            }
            return -1;
        }

        private static void Main(string[] args)
        {
            const int n = 2000000;

            var intArray = new int[n];
            var objectArray = new object[n];

            var random = new Random();
            for (var i = 0; i < n - 1; i++)
            {
                intArray[i] = random.Next();
                objectArray[i] = random.Next();

            }

            var stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            var number1 = FindElement(intArray, -1);
            stopWatch1.Stop();

            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            var number2 = FindElement(objectArray, -1);
            stopwatch2.Stop();

            Console.WriteLine("intArray: " + stopWatch1.Elapsed.TotalMicroseconds);
            Console.WriteLine("objectArray: " + stopwatch2.Elapsed.TotalMicroseconds);
        }
    }
}
