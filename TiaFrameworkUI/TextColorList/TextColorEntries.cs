using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkUI.TextGraphList
{
    public class TextColorEntries
    {
        #region Property

        public int Start { get; }
        public int? End { get; }
        public Color Color { get; }
        #endregion

        #region TextGraphEntries
        public TextColorEntries(int start,Color color, int? end = null)
        {
            Start = start;
            End = end;
            Color=color;
        }
        #endregion
    }
}

