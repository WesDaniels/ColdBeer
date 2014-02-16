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
            Motor motorFL = new Motor();
            Motor motorFR = new Motor();
            Motor motorBL = new Motor();
            Motor motorBR = new Motor();

            motorFL.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);
            motorFR.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);
            motorBL.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);
            motorBR.Connect(Pins.GPIO_PIN_D7, Pins.GPIO_PIN_D4, PWMChannels.PWM_PIN_D6);

            DriveTrain driveTrain = new DriveTrain();
            driveTrain.ConnectFour(motorFL,motorFR,motorBL,motorBR);

            Ping ping = new Ping();
            ping.Connect(Pins.GPIO_PIN_D1,Pins.GPIO_PIN_D2);

            PingStream pingStream = new PingStream(ping);

            Captain captain = new Captain(driveTrain,pingStream);

            // keep program running
            while (true)
            {
                Thread.Sleep(5000);
            }
        }

    }
}
