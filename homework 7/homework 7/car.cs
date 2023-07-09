using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7
{
    abstract class car
    {
        public abstract void getSpeed();
        public abstract void brake();
        public abstract void accelerate();
        public bool radioStatus;
    }
    class toyota : car, IRadio, ISeats
    {   
        private int speed = 0;
        private int acceleratespeed = 60;
        private int brakespeed = 40;
        private bool radioStatus = false;
        private string station = "FM 107.7";
        private int volume = 0;
        public override void getSpeed()
        {
            Console.WriteLine("The speed of the toyota is " + speed + " kph");
        }
        public override void brake()
        {
            speed = speed - brakespeed;        
        }
        public override void accelerate()
        {
            speed = speed + acceleratespeed;          
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
    class daewoo : car, IRadio, ISeats
    {
        private int speed = 0;
        private int acceleratespeed = 90;
        private int brakespeed = 60;
        private bool radioStatus = false;
        private string station = "FM 107.7";
        private int volume = 0;

        public override void getSpeed()
        {
            Console.WriteLine("The speed of the daewoo is " + speed + " kph");
        }
        public override void brake()
        {
            speed = speed - brakespeed;
        }
        public override void accelerate()
        {
            speed = speed + acceleratespeed;
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
    class ford : car, IRadio, ISeats
    {
        private int speed = 0;
        private int acceleratespeed = 20;
        private int brakespeed = 5;
        private bool radioStatus = false;
        private string station = "FM 107.7";
        private int volume = 0;

        public override void getSpeed()
        {
            Console.WriteLine("The speed of the ford is " + speed + " kph");
        }
        public override void brake()
        {
            speed = speed - brakespeed;
        }
        public override void accelerate()
        {
            speed = speed + acceleratespeed;
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

