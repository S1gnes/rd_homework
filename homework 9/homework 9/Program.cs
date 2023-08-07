using homework_9;

void carfunction(Car ourCar)
{
    ourCar.getSpeed();
    ourCar.accelerate();
    ourCar.getSpeed();
    ourCar.brake();
    ourCar.getSpeed();
    IRadio radio = (IRadio)ourCar;
    radio.TurnOn();
    radio.ChangeStation("FM 98.7");
    radio.ChangeVolume(10);
    radio.TurnOff();
    ISeats seats = (ISeats)ourCar;
    seats.AdjustPosition();
    seats.HeatOn();
    seats.HeatOff();
}
Console.WriteLine("Choose your car:");
Console.WriteLine("1. Mazda");
Console.WriteLine("2. Audi");
int car = Convert.ToInt32(Console.ReadLine());
Car ourCar;
switch (car)
{
    case 1:
        ourCar = new Mazda();
        carfunction(ourCar);
        break;
    case 2:
        ourCar = new Audi();
        carfunction(ourCar);
        break;
    default:
        Console.WriteLine("Invalid input");
        break;
}