using ColdBeer.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolBeer.Emulator.Adapters
{
    public class xMotor1 : IMotor
    {

        public void SetSpeed(int percent)
        {
            Emulator.xMotor1_SetSpeed = percent.ToString();
        }

        public void Direction(ColdBeer.Enums.OneDirection value)
        {
            Emulator.xMoter1_Direction = value.ToString();
        }

        public void Connect(Microsoft.SPOT.Hardware.Cpu.Pin pin1, Microsoft.SPOT.Hardware.Cpu.Pin pin2, Microsoft.SPOT.Hardware.Cpu.PWMChannel channel1)
        {
            throw new NotImplementedException();
        }
    }
}
