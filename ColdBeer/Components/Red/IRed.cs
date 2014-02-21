using Microsoft.SPOT.Hardware;
using System;

namespace ColdBeer.Components.Red
{
    public delegate void RedReceivedEventHandler(uint data1, uint data2, DateTime time);

    public interface IRed
    {
        event RedReceivedEventHandler Change;

        void Connect(Cpu.Pin portId);

        bool CurrentState();
    }
}
