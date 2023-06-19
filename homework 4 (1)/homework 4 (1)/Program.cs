Console.WriteLine("5 array numbers:");
int[] numbers = new int[5];
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Your number:");
int searchNumber = int.Parse(Console.ReadLine());
int position = Array.IndexOf(numbers, searchNumber);
int x = 0;

if (position != -1)
{
    Console.WriteLine($"Number found at position {position}");
}
else 
{
    Console.WriteLine("The number {0} was not found in the array.", searchNumber);
}