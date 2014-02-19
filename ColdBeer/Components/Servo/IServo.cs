using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace ColdBeer.Components.Servo
{
    interface IServo
    {
        void Connect(Cpu.PWMChannel channelPin);

        void SetDegrees(int degrees);
    }
}
