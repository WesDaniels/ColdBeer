using ColdBeer.Classes.PingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolBeer.Emulator.MessageFactory_Test
{
    class Faux_PingList : IPingList
    {
        public int Length()
        {
            throw new NotImplementedException();
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
            switch(from){
                case 0:
                    return "000011110000010193500000000000001011115";
                default:
                    return "-1";
            }
        }
    }
}
