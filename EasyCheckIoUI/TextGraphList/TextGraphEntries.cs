using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoUI.TextGraphList
{
    public class TextGraphEntries
    {
        #region Property

        public int Start { get; }
        public int? End { get; }
        public string Message { get; }
        #endregion

        #region TextGraphEntries
        public TextGraphEntries(int start, string message, int? end = null)
        {
            Start = start;
            End = end;
            Message = message;
        }
        #endregion
    }
}

