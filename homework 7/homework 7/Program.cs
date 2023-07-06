using homework_7;
internal class Program
{
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
                ourCar.getSpeed();
                ourCar.accelerate();
                ourCar.getSpeed();
                ourCar.brake();
                ourCar.getSpeed();
                break;
            case 2:
                ourCar = new daewoo();
                ourCar.getSpeed();
                ourCar.accelerate();
                ourCar.getSpeed();
                ourCar.brake();
                ourCar.getSpeed();
                break;
            case 3:
                ourCar = new ford();
                ourCar.getSpeed();
                ourCar.accelerate();
                ourCar.getSpeed();
                ourCar.brake();
                ourCar.getSpeed();
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
      

    }
}