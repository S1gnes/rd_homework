namespace homework_9
{
    internal interface IRadio
    {
        void TurnOn();
        void TurnOff();
        void ChangeStation(string station);
        void ChangeVolume(int volume);
    }
}
