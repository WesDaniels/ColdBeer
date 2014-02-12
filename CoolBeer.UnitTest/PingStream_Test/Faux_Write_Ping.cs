using ColdBeer.Components.Ping;
using Microsoft.SPOT.Hardware;
using System;
using System.Collections.Generic;

namespace CoolBeer.Emulator.PingStream_Test
{
    public class Faux_Write_Ping : IPing
    {
        public event ChangedEventHandler Change;

        public List<long> SendCalls = new List<long>();

        public void Connect(Cpu.Pin pinTrig, Cpu.Pin pinEcho)
        {
        }

        public void Send()
        {
            SendCalls.Add(DateTime.Now.Ticks);
            //Change(1, 2, System.DateTime.Now);
        }
    }
}
