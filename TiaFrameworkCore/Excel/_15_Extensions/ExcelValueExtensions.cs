using ClosedXML.Excel;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.Excel._15_Extensions
{
    public static class ExcelValueExtensions
    {

        public static S7Tag GetS7Io(this XLCellValue cellvalue, S7Tag tag)
        {
            string a = (string)cellvalue;
            string[] div = a.Split(".");
            Regex rex = new Regex(@"([a-zA-Z]+)(\d+)");
            Match result = rex.Match(div[0]);
            string s7io = result.Groups[1].Value;
            if (div.Length > 1)
                tag.Bit = Convert.ToInt32(div[1]);
            tag.Byte = Convert.ToInt32(result.Groups[2].Value);
            switch (s7io)
            {
                case "I":
                    tag.IO = eS7io.Input;
                    break;
                case "IW":
                    tag.IO = eS7io.AnalogicInput;
                    break;
                case "Q":
                    tag.IO = eS7io.Output;
                    break;
                case "QW":
                    tag.IO = eS7io.AnalogicOutput;
                    break;
                default:
                    throw new ArgumentException("StringToS7Io | Value Not Convertible");
            }
            return tag;

        }

        public static S7WordLength GetDataType(this XLCellValue cellvalue)
        {
            var str = cellvalue.GetText();
            if (string.Equals(str, "bool", StringComparison.CurrentCultureIgnoreCase))
                return S7WordLength.Bit;

            if (string.Equals(str, "byte", StringComparison.CurrentCultureIgnoreCase))
                return S7WordLength.Byte;

            if (string.Equals(str, "int", StringComparison.CurrentCultureIgnoreCase))
                return S7WordLength.Int;

            if (string.Equals(str, "dint", StringComparison.CurrentCultureIgnoreCase))
                return S7WordLength.DInt;

            if (string.Equals(str, "real", StringComparison.CurrentCultureIgnoreCase))
                return S7WordLength.Real;

            throw new ArgumentException("GetDataType | Value Not Convertible");

        }

    }
}