using ColdBeer.Enums;
using Microsoft.SPOT.Hardware;
using System;
using ColdBeer;

namespace ColdBeer.Components.Motor
{
    class Motor : IMotor
    {
        public static uint PWM_PERIOD = 20000;
        public static uint PWM_DURATION = 1500;

        private OutputPort _port1, _port2;
        private PWM _signalPort;

        // connect to a motor
        public void Connect(Cpu.Pin pin1, Cpu.Pin pin2, Cpu.PWMChannel channel1)
        {
            _port1 = new OutputPort(pin1, false);
            _port2 = new OutputPort(pin2, false);
            _signalPort = new PWM(channel1, PWM_PERIOD, PWM_DURATION, PWM.ScaleFactor.Microseconds, false);
        }

        // set speed in current direction to percent
        public void SetSpeed(int percent)
        {
            if (percent > 100)
            {
                throw new Exception("Can not set speed to greater than 100%");
            }
            else if (percent < 0)
            {
                throw new Exception("Can not set speed to less than 0%");
            }
            else
            {
                // do magic
                uint finalVal = 0;
                if (percent > 0)
                {
                    finalVal = (uint)(((percent) / 100d) * 30d) + 70;
                }
                _signalPort.DutyCycle = finalVal;
                if (finalVal == 0)
                {
                    Direction(OneDirection.Stopped);
                }
            }
        }

        // set digital signals for each direction
        public void Direction(OneDirection value)
        {
            switch (value)
            {
                case OneDirection.Forwards:
                    _port1.Write(true);
                    _port2.Write(false);
                    break;
                case OneDirection.Backwards:
                    _port1.Write(false);
                    _port2.Write(true);
                    break;
                case OneDirection.Stopped:
                    _port1.Write(false);
                    _port2.Write(false);
                    break;
            }
        }
    }
}
