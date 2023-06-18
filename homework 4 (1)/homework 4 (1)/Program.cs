Console.WriteLine("5 array numbers:");
int[] numbers = new int[5];
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Your number:");
int searchNumber = int.Parse(Console.ReadLine());
int position = Array.IndexOf(numbers, searchNumber) + 1;
int x = 0;

foreach (int item in numbers)
{
    if (item == searchNumber)
        Console.WriteLine($"Number found at position {position}");
    else
    {
        x++;
        if (x == 5)
            Console.WriteLine("The number {0} was not found in the array.", searchNumber);
    }
}
