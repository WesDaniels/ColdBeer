using System;
using Microsoft.SPOT;
using ColdBeer.Components;
using ColdBeer.Enums;
using System.Threading;

namespace ColdBeer.Controllers
{
    class ThrottledMotor
    {
        private IMotor _motor;
        private int _speedStep = 10;

        private int _speed = 0;

        // unit of measure to adjust the throttle by (-1 when in revsese)
        private int signedUnit
        {
            get
            {
                switch (direction)
                {
                    case OneDirection.Forwards:
                        return 1;
                    case OneDirection.Stopped:
                        return 0;
                    case OneDirection.Backwards:
                        return -1;
                }
                throw new Exception("Invalid direction.");
            }
        }

        // maintain speed of the motor
        private int speed
        {
            get
            {
                if (_speed < 0 || _speed > 100)
                {
                    throw new Exception("_speed is at an invalid level that could harm the egnine, exceptable range is (0-100 %).");
                }
                else
                {
                    return _speed;
                }
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Invalid number specified for _speed that could harm egnine, exceptable range is (0-100 %).");
                }
                else
                {
                    _speed = value;
                    _motor.SetSpeed(speed);
                    if (_speed == 0)
                    {
                        direction = OneDirection.Stopped;
                    }
                }
            }
        }

        private OneDirection _direction = new OneDirection();

        // maintain motor direction
        private OneDirection direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if ((value == OneDirection.Forwards && _direction == OneDirection.Backwards) ||
                    (value == OneDirection.Backwards && _direction == OneDirection.Forwards))
                {
                    throw new Exception("Engine can not switch between Forwards to Reverse, must transition through Stopped.");
                }
                else if (value == _direction)
                {
                    throw new Exception("Engine is attempting to be put in state it already is.");
                }
                else
                {
                    _direction = value;
                    _motor.Direction(_direction);
                }
            }
        }

        // Access controls to a motor
        public ThrottledMotor(IMotor motor)
        {
            _motor = motor;
            speed = 0;
        }

        // increase the speed of the engine by 1 unit
        public void Forward()
        {
            if (direction == OneDirection.Stopped)
            {
                direction = OneDirection.Forwards;
            }

            for (int i = 1; i < _speedStep; i++)
            {
                speed = speed + signedUnit >= 0 & speed + signedUnit <= 100 ? speed + signedUnit : speed;
                Thread.Sleep(5);
            }
        }

        // decrease the speed of the engine by 1 unit
        public void Reverse()
        {
            if (direction == OneDirection.Stopped)
            {
                direction = OneDirection.Backwards;
            }

            for (int i = 1; i < _speedStep; i++)
            {
                speed = speed - signedUnit >= 0 & speed - signedUnit <= 100 ? speed - signedUnit : speed;
                Thread.Sleep(5);
            }
        }
    }
}
