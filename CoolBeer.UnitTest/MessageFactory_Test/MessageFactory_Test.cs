using ColdBeer.Classes.PingList;
using ColdBeer.Utilities.MessageFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolBeer.Emulator.MessageFactory_Test
{
    [TestClass]
    public class MessageFactory_Test
    {

        [TestMethod]
        public void MessageFactory_Message_Count()
        {
            Faux_PingList faux = new Faux_PingList();
            Assert.AreEqual(MessageFactory.GetMessageCount(faux),2);
        }

        [TestMethod]
        public void MessageFactory_Message_At_Index()
        {
            Faux_PingList faux = new Faux_PingList();
            Assert.AreEqual(MessageFactory.GetMessageAt(faux,1),"0000000000000101");
        }
    }
}
