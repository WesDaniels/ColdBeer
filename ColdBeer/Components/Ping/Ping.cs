using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using System.Threading;
using System.Collections;

namespace ColdBeer.Components.Ping
{
    public class Ping : IPing
    {
        public event ChangedEventHandler Change;

        private OutputPort _portOut;
        private InterruptPort _interIn;

        /// <summary>
        /// This interrupt will trigger when detector receives back reflected sonic pulse       
        /// </summary>
        void interIn_OnInterrupt(uint port, uint state, DateTime time)
        {
            Change(port, state, time);
            Reset();
        }

        public void Connect(Cpu.Pin pinTrig, Cpu.Pin pinEcho)
        {
            _portOut = new OutputPort(pinTrig, false);
            _interIn = new InterruptPort(pinEcho, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);
            _interIn.OnInterrupt += new NativeEventHandler(interIn_OnInterrupt);
            Reset();
        }

        public void Send()
        {
            // Trigger Sonic Pulse
            _portOut.Write(false);
        }

        private void Reset()
        {
            // Reset Sensor
            _portOut.Write(true);
            Thread.Sleep(1);
        }
    }
}
