using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

public class Data
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

public class XMLManager
{
    public Data data { get; set; }

    public void Save(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        using (StreamWriter writer = new StreamWriter(filename))
        {
            serializer.Serialize(writer, data);
        }
    }

    public void Load(string filename)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        using (StreamReader reader = new StreamReader(filename))
        {
            data = (Data)serializer.Deserialize(reader);
        }
    }
}

public class JSONManager
{
    public Data data { get; set; }

    public void Save(string filename)
    {
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(filename, json);
    }

    public void Load(string filename)
    {
        string json = File.ReadAllText(filename);
        data = JsonConvert.DeserializeObject<Data>(json);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();

        Console.Write("Введіть вік: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введіть електронну пошту: ");
        string email = Console.ReadLine();

        Data data = new Data { Name = name, Age = age, Email = email };

        XMLManager xmlManager = new XMLManager { data = data };
        JSONManager jsonManager = new JSONManager { data = data };

        xmlManager.Save("data.xml");
        jsonManager.Save("data.json");

        xmlManager.Load("data.xml");
        jsonManager.Load("data.json");

        Console.WriteLine($"XML: Name - {xmlManager.data.Name}, Age - {xmlManager.data.Age}, Email - {xmlManager.data.Email}");
        Console.WriteLine($"JSON: Name - {jsonManager.data.Name}, Age - {jsonManager.data.Age}, Email - {jsonManager.data.Email}");
    }
}
