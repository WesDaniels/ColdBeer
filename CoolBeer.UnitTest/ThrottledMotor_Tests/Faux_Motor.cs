using ColdBeer.Components;
using ColdBeer.Enums;
using Microsoft.SPOT.Hardware;
using System;
using System.Collections.Generic;

namespace CoolBeer.Emulator.ThrottledMotor_Tests
{
    class Faux_Motor : IMotor
    {
        // list of all calls made to this class
        private List<string> _stack = new List<string>();

        public List<string> Stack
        {
            get
            {
                return _stack;
            }
            set
            {
                _stack = value;
            }
        }

        public void SetSpeed(int percent)
        {
            Stack.Add("SetSpeed(" + percent + ")");
            // Rule 1: Engine Power can't be greater than 100%
            if (percent > 100)
            {
                throw new Exception("Engine BLEW - RPM's to HIGH!");
            }
            // Rule 2: Engine Power can't be less than 0%
            else if (percent < 0)
            {
                throw new Exception("Engine LOCK - RPM's to LOW!");
            }

        }

        public void Direction(OneDirection value)
        {
            Stack.Add("Direction(" + value + ")");
        }

        public void Connect(Cpu.Pin pin1, Cpu.Pin pin2, Cpu.PWMChannel channel1)
        {
            Stack.Add("Connect(" + pin1 + "," + pin2 + "," + channel1 + ")");
        }
    }
}
