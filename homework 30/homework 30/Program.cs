using System;

class Program
{
    static void Main(string[] args)
    {
        MyObject obj = new MyObject();

        if (args.Length > 0)
        {
            obj.Run(args);
        }
        else
        {
            Console.Write("Введіть кількість елементів масиву: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] data = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть елемент {i + 1}: ");
                data[i] = Console.ReadLine();
            }
            obj.Run(data);
        }
    }
}

class MyObject
{
    public void Run(string[] data)
    {
        MyOtherObject other = new MyOtherObject(data);

        other.Dispose();
    }
}

class MyOtherObject : IDisposable
{
    private string[] data;

    public MyOtherObject(string[] data)
    {

        this.data = data;
    }

    public void Dispose()
    {

        Console.WriteLine($"Кількість елементів у масиві: {data.Length}");


        unsafe
        {
            fixed (string* p = data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine($"Елемент {i + 1}: {p[i]}");
                }
            }
        }

       
        GC.Collect();
        GC.WaitForPendingFinalizers();

        
        Console.WriteLine("Об'єкт MyOtherObject було видалено");
    }
}
