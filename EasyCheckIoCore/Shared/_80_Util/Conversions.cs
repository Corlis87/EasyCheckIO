using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._80_Util
{
    public class Conversions
    {
        private static string DecimalToBinary(object s)
        {
            if (s is byte _byte)
                return "0b" + Convert.ToString(_byte, 2).PadLeft(8, '0');
            else if (s is short _short)
                return "0b" + Convert.ToString(_short, 2).PadLeft(16, '0');
            else if (s is int _int)
                return "0b" + Convert.ToString(_int, 2).PadLeft(32, '0');
            else return "NaN";
        }

        public static string ToBinary(object s)
        {
          return  DecimalToBinary(s);
        }
    }
}
