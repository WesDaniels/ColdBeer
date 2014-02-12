using ColdBeer.Classes;
using ColdBeer.Enums;
using System;

namespace ColdBeer.Utilities
{
    public class MessageBuilder
    {
        private PacketList _message;

        private bool _started = false;
        private bool _completed = false;

        public MessageBuilder()
        {
            _message = new PacketList();
        }

        public PacketList ToMessage()
        {
            return _message;
        }

        public bool Add(Packet packet)
        {
            switch (packet)
            {
                case Packet.BeginTransmission:
                    if (!_started)
                    {
                        _started = true;
                        _message.Start = DateTime.Now.Ticks;
                        _message.Add(packet);
                    }
                    break;
                case Packet.EndTransmission:
                    if (_started && !_completed)
                    {
                        _completed = true;
                        _message.End = DateTime.Now.Ticks;
                        _message.Add(packet);
                    }
                    break;
                default:
                    if (_started && !_completed)
                    {
                        _message.Add(packet);
                    }
                    break;
            }
            return _completed;
        }
    }
}
