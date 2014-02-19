using System;
using Microsoft.SPOT;
using System.Collections;
using System.Text;

namespace ColdBeer.Classes.PingList
{
    /// <summary>
    /// List<long> - This a Collection of long's representing ticks at which a ping was received
    /// </summary>
    public class PingList : IPingList
    {
        private ArrayList _pingTimes = new ArrayList();

        /// <summary>
        /// returns the number of pings in our collection
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return _pingTimes.Count;
        }

        /// <summary>
        /// add a new ping received timestamp to our collection
        /// </summary>
        /// <param name="time">a ping was received</param>
        public void Add(long time)
        {
            _pingTimes.Add(time);
        }

        /// <summary>
        /// lookup a ping timestamp from our collection
        /// </summary>
        /// <param name="index">of a timestamp in our collection</param>
        /// <returns></returns>
        public long PingAt(int index = -1)
        {
            index = index == -1 ? _pingTimes.Count : index;
            return (long)_pingTimes[index];
        }

        /// <summary>
        /// convert the ping received timestamps into binary string
        /// </summary>
        /// <param name="from">time first ping received</param>
        /// <param name="to">time last ping was received</param>
        /// <returns></returns>
        public string ToBinary(int from, int to = -1)
        {
            to = to == -1 ? _pingTimes.Count - 1 : to;
            long elapsed;
            long start;
            long end;
            long bit;

            StringBuilder binary = new StringBuilder();

            for (int i = from; i < to; i++)
            {
                start = (long)_pingTimes[i];
                end = (long)_pingTimes[i+1];
                elapsed = (end - start);
                bit = elapsed / 10000;
                binary.Append(bit - 2);
            }

            return binary.ToString();
        }
    }
}
