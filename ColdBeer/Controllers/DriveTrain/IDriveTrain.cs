using ColdBeer.Components.Motor;

namespace ColdBeer.Controllers.DriveTrain
{
    public interface IDriveTrain
    {
        void ConnectFour(IMotor left, IMotor right);

        void Forward();

        void Right();

        void Left();

        void Reverse();
    }
}
