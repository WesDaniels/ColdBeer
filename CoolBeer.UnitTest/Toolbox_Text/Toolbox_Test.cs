using ColdBeer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColdBeer.Utilities;
using System;
using ColdBeer.Classes;

namespace CoolBeer.Emulator.Toolbox_Text
{
    [TestClass]
    public class Toolbox_Test
    {
        [TestMethod]
        public void PacketToBinary_Converts_BeginTransmission()
        {
            Assert.AreEqual(Packet.BeginTransmission.PacketToBinary(), "0000");
        }

        [TestMethod]
        public void PacketToBinary_Converts_EndTransmission()
        {
            Assert.AreEqual(Packet.EndTransmission.PacketToBinary(), "0101");
        }

        [TestMethod]
        public void MessagesToBinary_Convert()
        {
            //todo: write new test
            /*
            PacketList packetList = new PacketList();
            packetList.Add(Packet.BeginTransmission);
            packetList.Add(Packet.FromCar);
            packetList.Add(Packet.Ping);
            packetList.Add(Packet.EndTransmission);

            Assert.AreEqual(packetList.ToBinary(),"0000000100110101");
            */
        }
    }
}
