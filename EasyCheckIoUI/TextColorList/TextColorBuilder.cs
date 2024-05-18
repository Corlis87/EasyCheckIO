using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace EasyCheckIoUI.TextGraphList
{
    public class TextColorBuilder
    {
        #region Property   
        private TextColorManager TextColorManager;
        #endregion

        #region ctr
        public TextColorBuilder()
        {
        }
        #endregion

        #region CreateItem

        public TextColorBuilder CreateItem(bool isEnum)
        {

            TextColorManager = new TextColorManager(isEnum);
            return this;
        }
        #endregion

        #region AddMessage
        public TextColorBuilder AddMessage(int start,Color color, int? end = null)
        {
            TextColorManager.Entries.Add(new TextColorEntries(start, color, end));

            return this;
        }
        #endregion

        #region Build
        public TextColorManager Build()
        {
            return TextColorManager;
        }
        #endregion
    }
}
