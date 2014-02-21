using System;
using Microsoft.SPOT;
using ColdBeer.Components.Motor;

namespace ColdBeer.Controllers
{
    public class DriveTrain
    {
        ThrottledMotor _left;
        ThrottledMotor _right;

        public void ConnectFour(IMotor left, IMotor right)
        {
            _left = new ThrottledMotor(left);
            _right = new ThrottledMotor(right);
        }

        public void Forward()
        {
            _left.Forward();
            _right.Forward();
        }

        public void Right()
        {
            _left.Forward();
            _right.Reverse();
        }

        public void Left()
        {
            _right.Forward();
            _left.Reverse();
        }

        public void Reverse()
        {
            _left.Reverse();
            _right.Reverse();
        }

    }
}
