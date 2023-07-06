using ConsoleApp3;
PhoneBook phoneBook = new PhoneBook();
while (true)
{   
    Console.WriteLine("1. Find person");
    Console.WriteLine("2. Add person");
    Console.WriteLine("3. Phone Book");
    Console.WriteLine("4. Exit");
    int process = int.Parse(Console.ReadLine());
    switch (process)
    {
        case 1:
            Console.WriteLine("\n1. Find by name");
            Console.WriteLine("2. Find by number\n");
            int process2 = int.Parse(Console.ReadLine());
            switch (process2)
            {
                case 1:
                    Console.WriteLine("\nEnter name:");
                    string name = Console.ReadLine();
                    phoneBook.FindPerson(name);
                    break;
                case 2:
                    Console.WriteLine("\nEnter number:");
                    int number = int.Parse(Console.ReadLine());
                    phoneBook.FindPerson(number);
                    break;
            }
            break;
        case 2:
            Console.WriteLine("\nEnter name");
            string name2 = Console.ReadLine();
            Console.WriteLine("\nEnter number");
            int number2 = int.Parse(Console.ReadLine());
            phoneBook.addPerson(name2, number2);
            break;
        case 3:
            foreach (var entry in phoneBook.phoneBook)
            {
                Console.WriteLine("Name: " + entry.name + " Number: " + entry.number);
            }
            Console.WriteLine("\n");
            break;
        case 4:
            return;

       
    }
}

