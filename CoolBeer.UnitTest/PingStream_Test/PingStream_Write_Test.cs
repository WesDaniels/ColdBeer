using ColdBeer.Classes;
using ColdBeer.Components.Ping;
using ColdBeer.Controllers;
using ColdBeer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoolBeer.Emulator.PingStream_Test
{
    [TestClass]
    public class PingStream_Write_Test
    {
        private void Faux_ReceiveMessage(IPing faux_Ping)
        {
            PacketList packetList = new PacketList();
            packetList.Add(Packet.BeginTransmission);
            packetList.Add(Packet.Ping);
            packetList.Add(Packet.EndTransmission);

            string stream = packetList.ToBinary();

            Thread.Sleep(100);

            faux_Ping.Send();
            for (int i = 0; i < stream.Length; i++)
            {
                Thread.Sleep(int.Parse(stream[i].ToString()) + 1);
                faux_Ping.Send();
            }
        }

        [TestMethod]
        public void Test1()
        {
            PacketList packetList = new PacketList();
            packetList.Add(Packet.Ping);

            MessageList messageList = new MessageList();
            messageList.Add(packetList);

            Faux_Write_Ping faux_Ping = new Faux_Write_Ping();
            PingStream pingStream = new PingStream(faux_Ping);

            Console.WriteLine(pingStream.SendPing());

            string binary = string.Empty;
            for (int i = 1; i <faux_Ping.SendCalls.Count; i++)
            {
                //Console.WriteLine((faux_Ping.SendCalls[i] - faux_Ping.SendCalls[i - 1]) / 10000);
                binary = binary + ((faux_Ping.SendCalls[i] - faux_Ping.SendCalls[i - 1]) / 10000 - 1).ToString();
                Console.WriteLine(binary);
            }

            Console.WriteLine(faux_Ping.SendCalls.Count());
        }
    }
}
