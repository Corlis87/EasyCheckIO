using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._06_Enum
{
    public enum eS7io:int
    {
        [Description("I")]
        Input,
        [Description("O")]
        Output,
        [Description("AI")]
        AnalogicInput,
        [Description("AO")]
        AnalogicOutput,
    }
}
