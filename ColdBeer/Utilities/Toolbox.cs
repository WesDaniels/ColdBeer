using System;
using Microsoft.SPOT;
using ColdBeer.Enums;
using System.Collections;

namespace ColdBeer.Utilities
{
    static class Toolbox
    {
        public static string PacketToBinary(this Packet packet)
        {
            int decimalNumber = (int)packet;
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }

            while(result.Length < 4)
            {
                result = "0" + result;
            }

            return result;
        }

        public static string MessagesToBinary(this ArrayList messages)
        {
            string result = string.Empty;

            foreach (Packet packet in messages)
            {
                result += packet.PacketToBinary();
            }

            return result;
        }
    }
}
