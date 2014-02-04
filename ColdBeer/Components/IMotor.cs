using ColdBeer.Enums;
using Microsoft.SPOT.Hardware;

namespace ColdBeer.Components
{
    interface IMotor
    {
        void SetSpeed(int percent);

        void Direction(OneDirection value);

        void Connect(Cpu.Pin pin1, Cpu.Pin pin2, Cpu.PWMChannel channel1);
    }
}
