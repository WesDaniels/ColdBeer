
using Microsoft.SPOT;
using ColdBeer.Components.Ping;
using System.Collections;
using ColdBeer.Classes;
using ColdBeer.Utilities;
using System.Threading;
using ColdBeer.Enums;
using System;

namespace ColdBeer.Controllers
{
    public class PingStream
    {
        private static long TICK_DELAY = 0L;//6200L; // An ending adjust facture for overhead, lag, or other variables
        private static long TICK_MMPH = 58; // The distance traveld in 1 tick, as mm
        private static long PACKET_LENGTH = 4;
        private static long ELAPSED_SPAN = 10000;

        private IPing _ping;
        private long _lastTick;
        private long _block = 0;
        private long _blockLength = 0;
        private bool _locked = false;

        public MessageList Messages = new MessageList();
        private MessageBuilder _message = new MessageBuilder();

        private long ping
        {
            set
            {
                // reset and get ready to receive
                if (value > 2 || value < 1)
                {
                    _block = 0;
                    _blockLength = 0;
                }
                else
                {
                    // track elapsed time between received pings
                    _blockLength += 1;
                    _block = _block + ((value - 1) * (long)System.Math.Pow(2, PACKET_LENGTH - _blockLength));

                    if (_blockLength == PACKET_LENGTH)
                    {
                        if(_message.Add((Enums.Packet)_block))
                        {
                            Messages.Add(_message.ToMessage());
                            _message = new MessageBuilder();
                        }
                        _block = 0;
                        _blockLength = 0;
                    }
                }
            }
        }

        public bool SendPing()
        {
            PacketList packetList = new PacketList();
            packetList.Add(Packet.BeginTransmission);
            packetList.Add(Packet.Ping);
            packetList.Add(Packet.EndTransmission);

            int length = Messages.Length();
            bool inRange = false;

            MessageList messageList = new MessageList();
            messageList.Add(packetList);

            Write(messageList);
            // 1.11643701 foot per millisecond
            // 14.33131 milliseconds to travel full distance, 16 fett range
            // 28.663 ms is greatest detectable ping range
            // Only care about objects within ~1 foot
            Thread.Sleep(3);

            if(length < Messages.Length())
            {
                inRange = true;
            }

            // still have to wait full length
            Thread.Sleep(50);

            return inRange;
        } 

        public void Write(MessageList messageList){
            _ping.Send();
            for (int i = 0; i < messageList.MessageAt(0).ToBinary().Length; i++ )
            {
                _ping.Send();
                Thread.Sleep(int.Parse(messageList.MessageAt(0).ToBinary()[i].ToString()) + 1);
            }
        }

        public PingStream(IPing ping)
        {
            _ping = ping;
            _ping.Change += new ChangedEventHandler(pingCaptured);

            _lastTick = System.DateTime.Now.Ticks;
        }

        private void pingCaptured(uint data1, uint data2, DateTime time)
        {
            // Calculate Difference
            long elapsed = time.Ticks - _lastTick - TICK_DELAY;

            // Convert Ticks to Milliseconds
            ping = (elapsed / ELAPSED_SPAN);

            _lastTick = System.DateTime.Now.Ticks;
        }
    }
}
