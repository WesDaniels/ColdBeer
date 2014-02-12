using System;
using Microsoft.SPOT;
using ColdBeer.Components.Motor;

namespace ColdBeer.Controllers
{
    public class DriveTrain
    {
        ThrottledMotor _frontLeft;
        ThrottledMotor _frontRight;
        ThrottledMotor _rearLeft;
        ThrottledMotor _rearRight;

        public void ConnectFour(IMotor frontLeft, IMotor frontRight, IMotor rearLeft, IMotor rearRight)
        {
            _frontLeft = new ThrottledMotor(frontLeft);
            _frontRight = new ThrottledMotor(frontRight);
            _rearLeft = new ThrottledMotor(rearLeft);
            _rearRight = new ThrottledMotor(rearRight);
        }

        public void Forward()
        {
            if (_frontRight != null & _frontLeft != null)
            {
                _frontLeft.Forward();
                _frontRight.Forward();
            }
            if (_rearRight != null & _rearLeft != null)
            {
                _rearRight.Forward();
                _rearLeft.Forward();
            }
        }

        public void Right()
        {
            if (_frontRight != null & _frontLeft != null)
            {
                _frontLeft.Forward();
                _frontRight.Reverse();
            }
            if (_rearRight != null & _rearLeft != null)
            {
                _rearLeft.Forward();
                _rearRight.Reverse();
            }
        }

        public void Left()
        {
            if (_frontRight != null & _frontLeft != null)
            {
                _frontRight.Forward();
                _frontLeft.Reverse();
            }
            if (_rearRight != null & _rearLeft != null)
            {
                _rearRight.Forward();
                _rearLeft.Reverse();
            }
        }

        public void Reverse()
        {
            if (_frontRight != null & _frontLeft != null)
            {
                _frontLeft.Reverse();
                _frontRight.Reverse();
            }
            if (_rearRight != null & _rearLeft != null)
            {
                _rearLeft.Reverse();
                _rearRight.Reverse();
            }
        }

    }
}
