using ColdBeer.Classes;
using ColdBeer.Classes.RedDataList;
using ColdBeer.Components.Red;
using System;
using System.Collections;
using System.Threading;

namespace ColdBeer.Controllers.RedStream
{
    public class RedStream : IRedStream
    {
        private const int TIMEOUT = 20;

        public event RedStreamReceivedEventHandler Command;

        private Timer _timeOutTimer;
        private RedDataList _redDataList = new RedDataList();
        private IRed _red;

        // Watches for IR Commands
        public void Connect(IRed red)
        {
            _red = red;
            _red.Change += new RedReceivedEventHandler(PulseReceived);

            _timeOutTimer = new Timer(new TimerCallback(TimeOut), null, Timeout.Infinite, Timeout.Infinite);
        }

        // Record the timestamp and state
        private void RecordPulse(uint state, DateTime time)
        {
            _redDataList.Add(new RedData
            {
                TimeStamp = time.Ticks / 10,
                State = (state == 1)
            });
        }

        // called when a signal is read
        private void PulseReceived(uint data1, uint data2, DateTime time)
        {
            RecordPulse(data2, time);

            // Reset the timeout timer
            _timeOutTimer.Change(TIMEOUT, Timeout.Infinite);
        }

        // called once signal has finished being read
        private void TimeOut(object o)
        {
            uint state = _red.CurrentState() ? 1U : 0U;

            RecordPulse(state, DateTime.Now);

            // Turn off the timeout timer
            _timeOutTimer.Change(Timeout.Infinite, Timeout.Infinite);

            Command(_redDataList.ToBinary());

            _redDataList.Reset();
        }
    }
}
