using System;
using Microsoft.SPOT;
using ColdBeer.Classes.PingList;
using System.Text.RegularExpressions;

namespace ColdBeer.Utilities.MessageFactory
{
    public static class MessageFactory
    {
        public static int GetMessageCount(IPingList pingList)
        {
            string stream = pingList.ToBinary(0);
            Regex regex = new Regex("0000[01]{8}0101");
            MatchCollection mc = regex.Matches(stream);

            return mc.Count;
        }

        public static string GetMessageAt(IPingList pingList, int index)
        {
            string stream = pingList.ToBinary(0);
            Regex regex = new Regex("0000[01]{8}0101");
            MatchCollection mc = regex.Matches(stream);

            return mc[index].ToString();
        }
    }
}
