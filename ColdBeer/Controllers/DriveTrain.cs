using System;
using Microsoft.SPOT;
using ColdBeer.Components;

namespace ColdBeer.Controllers
{
    public class DriveTrain
    {
        ThrottledMotor _frontLeft;
        ThrottledMotor _frontRight;
        ThrottledMotor _rearLeft;
        ThrottledMotor _rearRight;

        public void ConnectTwoFront(IMotor frontLeft, IMotor frontRight)
        {
            _frontLeft = new ThrottledMotor(frontLeft);
            _frontRight = new ThrottledMotor(frontRight);
        }

        public void ConnectTwolRear(IMotor frontLeft, IMotor frontRight)
        {
            _rearLeft = new ThrottledMotor(frontLeft);
            _rearRight = new ThrottledMotor(frontRight);
        }

        public void ConnectFour(IMotor frontLeft, IMotor frontRight, IMotor rearLeft, IMotor rearRight)
        {
            _frontLeft = new ThrottledMotor(frontLeft);
            _frontRight = new ThrottledMotor(frontRight);
            _rearLeft = new ThrottledMotor(rearLeft);
            _rearRight = new ThrottledMotor(rearRight);
        }

        public void Forward()
        {
            _frontLeft.Forward();
            _frontRight.Forward();
            _rearRight.Forward();
            _rearLeft.Forward();
        }

        public void Right()
        {
            _frontLeft.Forward();
            _rearLeft.Forward();
            _frontRight.Reverse();
            _rearRight.Reverse();
        }

        public void Left()
        {
            _frontRight.Forward();
            _rearRight.Forward();
            _frontLeft.Reverse();
            _rearLeft.Reverse();
        }

        public void Reverse()
        {
            _frontLeft.Reverse();
            _frontRight.Reverse();
            _rearLeft.Reverse();
            _rearRight.Reverse();
        }

    }
}
