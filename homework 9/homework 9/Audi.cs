namespace homework_9
{
    internal class Audi : Car, IRadio, ISeats
    {
        private int speed = 0;
        private int acceleratespeed = 60;
        private int brakespeed = 40;
        private bool radioStatus = false;
        private string station = "FM 107.7";
        private int volume = 0;
        public override void getSpeed()
        {
            Console.WriteLine("The Mazda speed is {0} mph", speed);
        }
        public override void brake()
        {
            speed -= brakespeed;
            Console.WriteLine("The Mazda is braking. The current speed is {0} mph", speed);
        }
        public override void accelerate()
        {
            speed += acceleratespeed;
            Console.WriteLine("The Mazda is accelerating. The current speed is {0} mph", speed);
        }
        void IRadio.TurnOn()
        {
            Console.WriteLine("Radio is on");
            radioStatus = true;
        }
        void IRadio.TurnOff()
        {
            Console.WriteLine("Radio is off");
            radioStatus = false;
        }
        void IRadio.ChangeStation(string station)
        {
            if (radioStatus == true)
            {
                this.station = station;
                Console.WriteLine("The station is " + station);
            }
            else
            {
                Console.WriteLine("Radio is off");
            }
        }
        void IRadio.ChangeVolume(int volume)
        {
            if (radioStatus == true)
            {
                this.volume = volume;
                Console.WriteLine("The volume is " + volume);
            }
            else
            {
                Console.WriteLine("Radio is off");
            }
        }
        void ISeats.AdjustPosition()
        {
            Console.WriteLine("The position is adjusted");
        }
        void ISeats.HeatOn()
        {
            Console.WriteLine("The seat is heated");
        }
        void ISeats.HeatOff()
        {
            Console.WriteLine("The seat is not heated");
        }
    }
}
