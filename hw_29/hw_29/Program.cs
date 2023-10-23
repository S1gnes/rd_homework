using System;
using System.Reflection;

class MyClass
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new MyClass();
        string message = "Hello World";

        if (args.Length > 0)
        {
            string methodName = args[0];

            try
            {
                Type type = obj.GetType();
                MethodInfo methodInfo = type.GetMethod(methodName);

                if (methodInfo != null)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(string))
                    {
                        methodInfo.Invoke(obj, new object[] { message });
                    }
                    else
                    {
                        Console.WriteLine("Method does not accept a string parameter.");
                    }
                }
                else
                {
                    Console.WriteLine("Method not found: " + methodName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        else
        {
            obj.Print(message);
        }
    }
}
