using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._06_Enum
{
    public enum eS7CollectionFilter
    {
        [Description("Address")]
        ADDRESS = 0,
        [Description("Description")]
        DESCRIPTION = 1,
        [Description("Name")]
        NAME = 2,
    }
}
