using ColdBeer.Controllers;
using CoolBeer.Emulator.ThrottledMotor_Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoolBeer.Emulator.ThrottledMotor_Test.cs
{
    [TestClass]
    public class ThrottledMotor_Test
    {
        [TestMethod]
        public void Throttled_Motor_Max_Speed_Limited_To_100()
        {
            Faux_Motor _fauxMotor = new Faux_Motor();
            ThrottledMotor _throttledMotor = new ThrottledMotor(_fauxMotor);

            // no matter how many times we go forward, max is 100 exception never gets throw
            for (int i = 0; i < 20; i++)
            {
                _throttledMotor.Forward();
            }

            foreach (string command in _fauxMotor.Stack)
            {
                Console.WriteLine(command);
            }
        }

        [TestMethod]
        public void Throttled_Motor_Min_Speed_Limited_To_0()
        {
            Faux_Motor _fauxMotor = new Faux_Motor();
            ThrottledMotor _throttledMotor = new ThrottledMotor(_fauxMotor);

            // no matter how many times we go in reverse, max is 100 exception never gets throw
            for (int i = 0; i < 20; i++)
            {
                _throttledMotor.Reverse();
            }

            foreach (string command in _fauxMotor.Stack)
            {
                Console.WriteLine(command);
            }
        }

        [TestMethod]
        public void Throttled_Motor_Transitions_Between_Forward_And_Reverse()
        {
            Faux_Motor _fauxMotor = new Faux_Motor();
            ThrottledMotor _throttledMotor = new ThrottledMotor(_fauxMotor);

            // cross back and forth inbetween reverse and forawrd, hopefully cause no errors
            for (int i = 0; i < 3; i++)
            {
                _throttledMotor.Reverse();
            }

            for (int i = 0; i < 4; i++)
            {
                _throttledMotor.Forward();
            }

            for (int i = 0; i < 5; i++)
            {
                _throttledMotor.Reverse();
            }

            foreach (string command in _fauxMotor.Stack)
            {
                Console.WriteLine(command);
            }
        }
    }
}
