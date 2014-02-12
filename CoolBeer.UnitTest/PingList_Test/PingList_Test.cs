using ColdBeer.Classes.PingList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
namespace CoolBeer.Emulator.PingList_Test
{
    [TestClass]
    public class PingList_Test
    {
        [TestMethod]
        public void PingList_Starts_Empty()
        {
            PingList pingList = new PingList();

            Assert.AreEqual(pingList.Length(), 0);
        }

        [TestMethod]
        public void PingList_Adds_Values()
        {
            PingList pingList = new PingList();

            pingList.Add(DateTime.Now.Ticks);
            pingList.Add(DateTime.Now.Ticks);
            pingList.Add(DateTime.Now.Ticks);
            pingList.Add(DateTime.Now.Ticks);

            Assert.AreEqual(pingList.Length(), 4);
        }

        [TestMethod]
        public void PingList_PingAt_Return_Value()
        {
            PingList pingList = new PingList();

            long check = DateTime.Now.Ticks;

            pingList.Add(check);

            Assert.AreEqual(check, pingList.PingAt(0));
        }

        [TestMethod]
        public void PingList_ToBinary()
        {
            PingList pingList = new PingList();

            pingList.Add(DateTime.Now.Ticks);
            Thread.Sleep(1);
            pingList.Add(DateTime.Now.Ticks);
            Thread.Sleep(2);
            pingList.Add(DateTime.Now.Ticks);
            Thread.Sleep(3);
            pingList.Add(DateTime.Now.Ticks);
            Thread.Sleep(2);
            pingList.Add(DateTime.Now.Ticks);

            Console.WriteLine(pingList.ToBinary(0));

            Assert.AreEqual(pingList.ToBinary(0), "0121");
        }
    }
}
