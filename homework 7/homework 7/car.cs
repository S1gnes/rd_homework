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

    }
    class toyota : car
    {   
        private int speed = 0;
        private int acceleratespeed = 60;
        private int brakespeed = 40;

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
    }
    class daewoo : car
    {
        private int speed = 0;
        private int acceleratespeed = 90;
        private int brakespeed = 60;

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
    }
    class ford : car
    {
        private int speed = 0;
        private int acceleratespeed = 20;
        private int brakespeed = 5;

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
    }
}   

