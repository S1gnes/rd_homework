int[] numbers = {1,2,3,4,5};
int length = numbers.Length;
int[] reversedNumbers = new int[length];
for (int i = 0; i < length; i++)
{
    reversedNumbers[i] = numbers[length - i - 1];
}
foreach (int number in reversedNumbers)
{
    Console.WriteLine(number);
}