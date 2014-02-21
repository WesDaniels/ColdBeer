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

namespace ColdBeer
{
    public class Program
    {
        public static void Main()
        {
            IMotor motorL = new Motor();
            IMotor motorR = new Motor();

            motorL.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);
            motorR.Connect(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, PWMChannels.PWM_PIN_D5);
            
            DriveTrain driveTrain = new DriveTrain();
            driveTrain.ConnectFour(motorL,motorR);

            //IPing ping = new Ping();
            //ping.Connect(Pins.GPIO_PIN_D1,Pins.GPIO_PIN_D2);

            //PingStream pingStream = new PingStream(ping);

            Captain captain = new Captain(driveTrain);//pingStream);

            // keep program running
            while (true)
            {
                Thread.Sleep(5000);
            }
        }

    }
}
