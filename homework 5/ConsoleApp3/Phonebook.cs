using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class PhoneBookEntity
    {
        public string name;
        public int number;
    }

    internal class PhoneBook
    {
        public List<PhoneBookEntity> phoneBook = new List<PhoneBookEntity>
        {
            new PhoneBookEntity { name = "John", number = 1234567890 },
            new PhoneBookEntity { name = "Jane", number = 1234567891 },
        };

        public void addPerson(string name, int number)
        {
            Console.WriteLine("Adding " + name + " to phonebook");
            Console.WriteLine("Adding " + number + " to phonebook");
            phoneBook.Add(new PhoneBookEntity { name = name, number = number });
        }

        public void FindPerson(string name)
        {
            foreach (var entry in phoneBook)
            {
                if (entry.name == name)
                {
                    Console.WriteLine("Name: " + entry.name + " Number: " + entry.number);
                }

            }
        }
        public void FindPerson(int number)
        {
            foreach (var entry in phoneBook)
            {
                if (entry.number == number)
                {
                    Console.WriteLine("Name: " + entry.name + " Number: " + entry.number);
                }

            }


        }
    }
}
    

