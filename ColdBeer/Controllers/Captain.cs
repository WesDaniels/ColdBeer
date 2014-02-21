using System;
using Microsoft.SPOT;
using System.Threading;

namespace ColdBeer.Controllers
{
    public class Captain
    {
        DriveTrain _driveTrain;
        PingStream _pingStream;

        // Obsticle detected in path?;
        private bool _blocked = false;

        /// <summary>
        /// Thread for controlling the motors
        /// </summary>
        private void ThreadDrive()
        {
            while (true)
            {
                // while nothings in path drive forward
                _driveTrain.Forward();
                while (!_blocked)
                {
                    Thread.Sleep(100);
                }
                _driveTrain.Reverse();

                // while somethings in path, turn
                _driveTrain.Right();
                while (_blocked)
                {
                    Thread.Sleep(100);
                }
                _driveTrain.Left();
            }
        }

        /// <summary>
        /// Thread that just keeps a look out for obsticles
        /// </summary>
        private void ThreadDetect()
        {
            while (true)
            {
                _blocked = _pingStream.SendPing();
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Captain controls the car operations
        /// </summary>
        /// <param name="driveTrain"></param>
        /// <param name="pingStream"></param>
        public Captain(DriveTrain driveTrain, PingStream pingStream = null)
        {
            _driveTrain = driveTrain;
            _pingStream = pingStream;

            ThreadStart delegateDrive = new ThreadStart(ThreadDrive);
            Thread threadDrive = new Thread(delegateDrive);

            // Start driving thread
            threadDrive.Start();

            if (pingStream != null)
            {

                ThreadStart delagateDetect = new ThreadStart(ThreadDetect);
                Thread threadDetect = new Thread(delagateDetect);

                // Start Obsticle detection thread
                threadDetect.Start();
            }
        }
    }
}
