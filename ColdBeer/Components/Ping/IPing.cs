using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace ColdBeer.Components.Ping
{
    public delegate void ChangedEventHandler(uint data1, uint data2, DateTime time);

    public interface IPing
    {
        event ChangedEventHandler Change;

        void Connect(Cpu.Pin pinTrig, Cpu.Pin pinEcho);

        void Send();
    }
}
