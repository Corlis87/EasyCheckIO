using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Excel._03_DataBlock
{
    public class ExcelCellValue
    {
        public string ColumnName { get; set; }

        public XLCellValue Value { get; set; }


        public ExcelCellValue(XLCellValue columnName, XLCellValue value)
        {
            ColumnName = columnName.GetText();
            Value = value;
        }
    }
}
