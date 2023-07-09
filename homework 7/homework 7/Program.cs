using homework_7;
internal class Program
{
     static void carfunction(car ourCar)
    {
        ourCar.getSpeed();
        ourCar.accelerate();
        ourCar.getSpeed();
        ourCar.brake();
        ourCar.getSpeed();
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Choose your car:");
        Console.WriteLine("1. Toyota");
        Console.WriteLine("2. Daewoo");
        Console.WriteLine("3. Ford");
        int car = Convert.ToInt32(Console.ReadLine());
        car ourCar; 
        switch (car)
        {
            case 1:
                ourCar = new toyota();
                carfunction(ourCar);
                break;
            case 2:
                ourCar = new daewoo();
                carfunction(ourCar);
                break;
            case 3:
                ourCar = new ford();
                carfunction(ourCar);
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
      

    }
}