using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7
{
    internal interface IRadio
    {
        void TurnOn();
        void TurnOff();
        void ChangeStation(string station);
        void ChangeVolume(int volume);
    }
    internal interface ISeats
    {      
        void AdjustPosition();
        void HeatOn();
        void HeatOff();
    }  
    
}
    
