Console.WriteLine("Enter the number of prime number you want to find");
int n = int.Parse(Console.ReadLine());
int count = 0;
int i = 2;
 while (count < n)
 {
    if (IsPrime(i))
 {
 count++;
 }
    i++;
 }
Console.WriteLine(i - 1);

        static bool IsPrime(int n)
        {
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }
            int i = 3;
            while (i <= Math.Sqrt(n))
            {
                if (n % i == 0)
                {
                    return false;
                }
                i += 2;
                }
            return true;
        }