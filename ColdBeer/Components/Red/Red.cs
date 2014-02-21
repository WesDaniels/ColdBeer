using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using ColdBeer.Classes.RedDataList;
using ColdBeer.Classes;
using System.Text;

namespace ColdBeer.Components.Red
{
    public class Red : IRed
    {
        public event RedReceivedEventHandler Change;

        private InterruptPort _iRInputPin;

        public void Connect(Cpu.Pin portId)
        {
            _iRInputPin = new InterruptPort(portId, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
            _iRInputPin.OnInterrupt += new NativeEventHandler(interIn_OnInterrupt);
        }

        void interIn_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            Change(data1, data2, time);
        }

        public bool CurrentState()
        {
            return _iRInputPin.Read();
        }
    }
}

