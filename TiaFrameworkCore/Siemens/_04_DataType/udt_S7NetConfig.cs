using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.Siemens._04_DataType
{
    public struct udt_S7NetConfig
    {
        public string Address;

        public int Rack;

        public int Slot;

        public udt_S7NetConfig(S7NetConfig s7_HwConfig)
        {
            Address = s7_HwConfig.Address;
            Rack = s7_HwConfig.Rack;
            Slot = s7_HwConfig.Slot;
        }

    }
}
