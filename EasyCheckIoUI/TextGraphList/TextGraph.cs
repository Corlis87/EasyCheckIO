using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkUI.TextGraphList
{
    public static class TextGraph
    {
        static Dictionary<string, TextGraphManager> Table = new Dictionary<string, TextGraphManager>();

        #region AddTable
        public static void AddTable(string name, TextGraphManager table)
        {
            Table.Add(name, table);
        }

        #endregion

        #region GetMessage
        public static string GetMessage(string key, int value)
        {
            return Table[key].GetMessage(value);
        }
        #endregion

        #region GetIndex
        public static object GetIndex(string key, string value, Type t = null)
        {
            if (Table[key].IsEnum)
                return Table[key].GetIndexFromEnum(value, t);
            else
                return Table[key].GetIndexFromString(value);
        }

        #endregion

        #region GetList

        public static string[] GetList(string key)
        {
            return Table[key].GetStrings();
        }
        #endregion

        #region Initialize
        public static void Initialize()
        {
            var builder = new TextGraphBuilder();

            builder = new TextGraphBuilder();
            var HwDeviceType = builder.CreateItem(true)
                .AddMessage(0, "8Bits Input")
                .AddMessage(1, "16Bits Input")
                .AddMessage(2, "32Bits Input")
                .AddMessage(3, "Analogic Input")
                .AddMessage(4, "8Bits Output")
                .AddMessage(5, "16Bits Output")
                .AddMessage(6, "32Bits Output")
                .AddMessage(7, "Analogic Output")
                .Build();

            AddTable(nameof(HwDeviceType), HwDeviceType);

            var S7Io = builder.CreateItem(true)
             .AddMessage(0, "Input")
             .AddMessage(1, "Output")
             .AddMessage(2, "Analogic Input")
             .AddMessage(3, "Analogic Output")
             .Build();

            AddTable(nameof(S7Io), S7Io);

            var S7IoAbbreviantion = builder.CreateItem(true)
           .AddMessage(0, "I")
           .AddMessage(1, "Q")
           .AddMessage(2, "IW")
           .AddMessage(3, "QW")
           .Build();

            AddTable(nameof(S7IoAbbreviantion),S7IoAbbreviantion);
   

            var S7DataType = builder.CreateItem(true)
                .AddMessage(1, "BOOL")
                .AddMessage(2, "BYTE")
                .AddMessage(5, "INT")
                .AddMessage(7, "DINT")
                .AddMessage(8, "REAL")
                .Build();

            AddTable(nameof(S7DataType), S7DataType);

            var S7ConvertType = builder.CreateItem(false)
               .AddMessage(0, "Standard")
               .AddMessage(1, "Binary")
               .Build();

            AddTable(nameof(S7ConvertType),S7ConvertType);

            var TestedStatus = builder.CreateItem(false)
            .AddMessage(0, "Not tested")
            .AddMessage(1, "Partialy tested")
            .AddMessage(2, "Tested")
            .Build();

            AddTable(nameof(TestedStatus), TestedStatus);

            var FilterType = builder.CreateItem(true)
         .AddMessage(0, "Address")
         .AddMessage(1, "Description")
         .AddMessage(2, "Name")
         .Build();

            AddTable(nameof(FilterType),FilterType);
        }
        #endregion
    }
}
