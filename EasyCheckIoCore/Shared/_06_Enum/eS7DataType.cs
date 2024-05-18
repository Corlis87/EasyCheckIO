using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._06_Enum
{
    public enum eS7DataType
    {
        [Description("Boolean")]
        BOOL = 1,
        [Description("Byte")]
        BYTE = 2,
        [Description("Integer")]
        INT = 5,
        [Description("Double Integer")]
        DINT = 7,
        [Description("Real")]
        REAL = 8
    }
}
