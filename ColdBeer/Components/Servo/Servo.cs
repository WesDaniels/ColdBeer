using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace ColdBeer.Components.Servo
{
    public class Servo : IServo
    {
        /// <summary>
        /// PWM handle
        /// </summary>
        private PWM servo;

        /// <summary>
        /// Timings range
        /// </summary>
        private int[] range = new int[2];

        /// <summary>
        /// Set servo inversion
        /// </summary>
        private bool inverted = false;

        /// <summary>
        /// Create the PWM Channel, set it low and configure timings
        /// </summary>
        /// <param name="pin"></param>
        public void Connect(Cpu.PWMChannel channelPin)
        {
            // Init the PWM pin
            servo = new PWM((Cpu.PWMChannel)channelPin, 20000, 1500, PWM.ScaleFactor.Microseconds, false);

            servo.DutyCycle = 0;
            // Typical settings
            range[0] = 1000;
            range[1] = 2000;
        }

        public void Dispose()
        {
            disengage();
            servo.Dispose();
        }

        /// <summary>
        /// Allow the user to set cutom timings
        /// </summary>
        /// <param name="fullLeft"></param>
        /// <param name="fullRight"></param>
        private void setRange(int fullLeft, int fullRight)
        {
            range[1] = fullLeft;
            range[0] = fullRight;
        }

        /// <summary>
        /// Disengage the servo. 
        /// The servo motor will stop trying to maintain an angle
        /// </summary>
        private void disengage()
        {
            servo.DutyCycle = 0;
        }

        public void SetDegrees(int degree)
        {
            Degree = degree;
        }

        /// <summary>
        /// Set the servo degree
        /// </summary>
        private double Degree
        {
            set
            {
                /// Range checks
                if (value > 180)
                    value = 180;

                if (value < 0)
                    value = 0;

                // Are we inverted?
                if (inverted)
                    value = 180 - value;

                // Set the pulse
                //servo.SetPulse(20000, (uint)map((long)value, 0, 180, range[0], range[1]));
                servo.Duration = (uint)map((long)value, 0, 180, range[0], range[1]);
            }
        }

        /// <summary>
        /// Convert degree of an angle to servo duration 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="in_min"></param>
        /// <param name="in_max"></param>
        /// <param name="out_min"></param>
        /// <param name="out_max"></param>
        /// <returns></returns>
        private long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }
    }
}
