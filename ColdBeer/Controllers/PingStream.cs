
using Microsoft.SPOT;
using ColdBeer.Components.Ping;
using System.Collections;
using ColdBeer.Classes;
using ColdBeer.Utilities;
using System.Threading;
using ColdBeer.Enums;
using System;
using ColdBeer.Classes.PingList;

namespace ColdBeer.Controllers
{
    public class PingStream
    {
        private IPing _ping;

        public PingList PingList = new PingList();

        /// <summary>
        /// Negotiates between sending and receiving pings
        /// </summary>
        /// <param name="ping"></param>
        public PingStream(IPing ping)
        {
            _ping = ping;
            _ping.Change += new ChangedEventHandler(pingCaptured);

            PingList.Add(System.DateTime.Now.Ticks);
        }

        /// <summary>
        /// This gets called whenever a ping is received
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="time"></param>
        private void pingCaptured(uint data1, uint data2, DateTime time)
        {
            PingList.Add(System.DateTime.Now.Ticks);
        }
    }
}
