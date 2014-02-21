using System;
using Microsoft.SPOT;
using System.Threading;
using ColdBeer.Controllers.DriveTrain;
using ColdBeer.Components.Red;
using ColdBeer.Controllers.RedStream;

namespace ColdBeer.Controllers
{
    public class Captain
    {
        IDriveTrain _driveTrain;
        IRedStream _redStream;
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

        public void ConnectDriveTrain(IDriveTrain driveTrain)
        {
            _driveTrain = driveTrain;

            ThreadStart delegateDrive = new ThreadStart(ThreadDrive);
            Thread threadDrive = new Thread(delegateDrive);

            // Start driving thread
            threadDrive.Start();
        }

        public void ConnectRedStream(IRedStream redStream)
        {
            _redStream = redStream;
            _redStream.Command += new RedStreamReceivedEventHandler(RemoteControlCommandReceived);
        }

        private void RemoteControlCommandReceived(string data){
            // todo: interprit data received
        }

        public void ConenctPingStream(PingStream pingStream)
        {
            _pingStream = pingStream;

            ThreadStart delagateDetect = new ThreadStart(ThreadDetect);
            Thread threadDetect = new Thread(delagateDetect);

            // Start Obsticle detection thread
            threadDetect.Start();
        }
    }
}