using ColdBeer.Components.Ping;
using Microsoft.SPOT.Hardware;
using System;

namespace CoolBeer.Emulator.PingStream_Test
{
    public class Faux_Read_Ping : IPing
    {
        public event ChangedEventHandler Change;

        public void Connect(Cpu.Pin pinTrig, Cpu.Pin pinEcho)
        {
        }

        public void Send()
        {
            Change(1, 2, System.DateTime.Now);
        }
    }
}
