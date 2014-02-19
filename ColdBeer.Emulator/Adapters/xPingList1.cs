using ColdBeer.Classes.PingList;
using ColdBeer.Components.Motor;
using System;

namespace CoolBeer.Emulator.Adapters
{
    public class xPingList1 : IPingList
    {
        int length = 0;

        public int Length()
        {
            // pretend the ping heard its echo and add a timestamp for it.
            if (Emulator.xPing1_block)
            {
                length += 1;
            }
            return length;
        }

        public void Add(long time)
        {
            throw new NotImplementedException();
        }

        public long PingAt(int index = -1)
        {
            throw new NotImplementedException();
        }

        public string ToBinary(int from, int to = -1)
        {
            throw new NotImplementedException();
        }
    }
}
