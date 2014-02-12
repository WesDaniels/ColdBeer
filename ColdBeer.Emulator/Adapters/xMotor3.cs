using ColdBeer.Components.Motor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolBeer.Emulator.Adapters
{
    public class xMotor3 : IMotor
    {

        public void SetSpeed(int percent)
        {
            Emulator.xMotor3_SetSpeed = percent.ToString();
        }

        public void Direction(ColdBeer.Enums.OneDirection value)
        {
            Emulator.xMoter3_Direction = value.ToString();
        }

        public void Connect(Microsoft.SPOT.Hardware.Cpu.Pin pin1, Microsoft.SPOT.Hardware.Cpu.Pin pin2, Microsoft.SPOT.Hardware.Cpu.PWMChannel channel1)
        {
            throw new NotImplementedException();
        }
    }
}
