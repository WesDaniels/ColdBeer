using ColdBeer.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoolBeer.UnitTest.Motor_Tests
{
    [TestClass]
    public class Motor_Test
    {
        [TestMethod,
        ExpectedException(typeof(NullReferenceException))]
        public void Motor_Runs_At_0()
        {
            IMotor _motor = new Motor();
            _motor.SetSpeed(0);
        }

        [TestMethod,
        ExpectedException(typeof(NullReferenceException))]
        public void Motor_Runs_At_100()
        {
            IMotor _motor = new Motor();
            _motor.SetSpeed(100);
        }

        [TestMethod,
        ExpectedException(typeof(Exception))]
        public void Motor_Exception_Above_100()
        {
            IMotor _motor = new Motor();
            _motor.SetSpeed(101);
        }

        [TestMethod,
        ExpectedException(typeof(Exception))]
        public void Motor_Exception_Below_0()
        {
            IMotor _motor = new Motor();
            _motor.SetSpeed(-1);
        }
    }
}
