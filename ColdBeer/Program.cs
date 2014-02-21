using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using ColdBeer.Controllers;
using ColdBeer.Components.Motor;
using ColdBeer.Components.Ping;
using ColdBeer.Controllers.DriveTrain;
using ColdBeer.Controllers.RedStream;
using ColdBeer.Components.Red;

namespace ColdBeer
{
    public class Program
    {
        private static IDriveTrain DriveTrain()
        {
            IMotor motorL = new Motor();
            IMotor motorR = new Motor();

            motorL.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);
            motorR.Connect(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, PWMChannels.PWM_PIN_D5);

            DriveTrain driveTrain = new DriveTrain();
            driveTrain.ConnectFour(motorL, motorR);

            return driveTrain;
        }

        private static IRedStream RedStream()
        {
            IRed red = new Red();
            red.Connect(Pins.GPIO_PIN_D7);

            IRedStream redStream = new RedStream();
            redStream.Connect(red);

            return redStream;
        }

        public static void Main()
        {
            Captain captain = new Captain();

            captain.ConnectDriveTrain(DriveTrain());
            captain.ConnectRedStream(RedStream());

            // keep program running
            Thread.Sleep(Timeout.Infinite);
        }

    }
}
