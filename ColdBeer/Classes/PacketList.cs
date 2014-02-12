using System;
using Microsoft.SPOT;
using System.Collections;
using ColdBeer.Enums;
using ColdBeer.Utilities;

namespace ColdBeer.Classes
{
    public class PacketList
    {
        private ArrayList _packets = new ArrayList();

        public long Start;

        public long End;

        public void Add(Packet packet)
        {
            _packets.Add(packet);
        }

        public Packet PacketAt(int index)
        {
            return (Packet)_packets[index];
        }

        public string ToBinary()
        {
            string binary = _packets.MessagesToBinary();
            return binary;
        }
    }
}
