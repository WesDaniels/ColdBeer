using ColdBeer.Components.Motor;
using ColdBeer.Components.Ping;
using System;

namespace CoolBeer.Emulator.Adapters
{
    public class xPing1 : IPing
    {
        public event ChangedEventHandler Change;

        public void Connect(Microsoft.SPOT.Hardware.Cpu.Pin pinTrig, Microsoft.SPOT.Hardware.Cpu.Pin pinEcho)
        {
            //throw new NotImplementedException();
        }

        public void Send()
        {
            //Emulator.xMotor1_SetSpeed = percent.ToString();
            //throw new NotImplementedException();
        }
    }
}
