using System;
using Microsoft.SPOT;
using System.Collections;

namespace ColdBeer.Classes
{
    public class MessageList
    {
        private ArrayList _messages = new ArrayList();

        public PacketList MessageAt(int index)
        {
            return (PacketList)_messages[index];
        }

        public void Add(PacketList message)
        {
            _messages.Add(message);
        }

        public int Length()
        {
            return _messages.Count;
        }
    }
}
