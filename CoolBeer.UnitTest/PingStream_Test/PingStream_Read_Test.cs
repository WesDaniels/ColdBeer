using ColdBeer.Classes;
using ColdBeer.Components.Ping;
using ColdBeer.Controllers;
using ColdBeer.Enums;
using Microsoft.SPOT.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using ColdBeer.Utilities;
using System.Collections;

namespace CoolBeer.Emulator.PingStream_Test
{
    [TestClass]
    public class PingStream_Read_Test
    {
        private void Faux_ReceiveMessage(IPing faux_Ping)
        {
            PacketList packetList = new PacketList();
            packetList.Add(Packet.Ack);
            packetList.Add(Packet.EndTransmission);
            packetList.Add(Packet.BeginTransmission);
            packetList.Add(Packet.FromCar);
            packetList.Add(Packet.Ping);
            packetList.Add(Packet.EndTransmission);
            packetList.Add(Packet.FromPocket);

            string stream = packetList.ToBinary();

            Thread.Sleep(100);

            faux_Ping.Send();
            for (int i = 0; i < stream.Length; i++)
            {
                Thread.Sleep(int.Parse(stream[i].ToString()) + 1);
                faux_Ping.Send();
            }
        }

        private string MessageToReceive()
        {
            PacketList packetList = new PacketList();
            packetList.Add(Packet.BeginTransmission);
            packetList.Add(Packet.FromCar);
            packetList.Add(Packet.Ping);
            packetList.Add(Packet.EndTransmission);

            string stream = packetList.ToBinary();
            return stream;
        }

        [TestMethod]
        public void Pingdom_Receives_Messages()
        {
            IPing faux_Ping = new Faux_Read_Ping();
            PingStream pingStream = new PingStream(faux_Ping);

            Faux_ReceiveMessage(faux_Ping);
            Thread.Sleep(10);

            Assert.AreEqual(pingStream.Messages.MessageAt(0).ToBinary(), MessageToReceive());
        }
    }
}
