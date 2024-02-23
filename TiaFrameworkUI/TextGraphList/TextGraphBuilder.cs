using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkUI.TextGraphList
{
    public class TextGraphBuilder
    {
        #region Property   
        private TextGraphManager TextGraphManager;
        #endregion

        #region ctr
        public TextGraphBuilder()
        {
        }
        #endregion

        #region CreateItem

        public TextGraphBuilder CreateItem(bool isEnum)
        {

            TextGraphManager = new TextGraphManager(isEnum);
            return this;
        }
        #endregion

        #region AddMessage
        public TextGraphBuilder AddMessage(int start, string text, int? end = null)
        {
            TextGraphManager.Entries.Add(new TextGraphEntries(start, text, end));

            return this;
        }
        #endregion

        #region Build
        public TextGraphManager Build()
        {
            return TextGraphManager;
        }
        #endregion
    }
}
