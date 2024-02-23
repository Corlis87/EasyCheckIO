using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkUI.TextGraphList
{
    public static class TextColor
    {
        static Dictionary<string, TextColorManager> Table = new Dictionary<string, TextColorManager>();

        #region AddTable
        public static void AddTable(string name, TextColorManager table)
        {
            Table.Add(name, table);
        }

        #endregion

        #region GetMessage
        public static Color GetMessage(string key, int value)
        {
            return Table[key].GetMessage(value);
        }
        #endregion

        #region GetIndex
        public static object GetIndex(string key, Color value, Type t = null)
        {
            if (Table[key].IsEnum)
                return Table[key].GetIndexFromEnum(value, t);
            else
                return Table[key].GetIndexFromString(value);
        }

        #endregion

        #region GetList

        public static Color[] GetList(string key)
        {
            return Table[key].GetStrings();
        }
        #endregion

        #region Initialize
        public static void Initialize()
        {
            var builder = new TextColorBuilder();

            builder = new TextColorBuilder();
            var S7Io = builder.CreateItem(true)
             .AddMessage(0, Colors.YellowGreen)
             .AddMessage(1, Colors.DodgerBlue)
             .AddMessage(2, Colors.Green)
             .AddMessage(3, Colors.Blue)
             .Build();

            AddTable(nameof(S7Io), S7Io);

            var TestedStatus = builder.CreateItem(true)
           .AddMessage(0, Colors.Red)
           .AddMessage(1, Colors.Yellow)
           .AddMessage(2, Colors.Lime)
           .Build();

            AddTable(nameof(TestedStatus), TestedStatus);

            var ConnectionStatus = builder.CreateItem(false)
        .AddMessage(0, Colors.White)
        .AddMessage(1, Colors.Yellow)
        .AddMessage(2, Colors.Lime)
        .Build();

            AddTable(nameof(ConnectionStatus), ConnectionStatus);
        }
        #endregion
    }
}
