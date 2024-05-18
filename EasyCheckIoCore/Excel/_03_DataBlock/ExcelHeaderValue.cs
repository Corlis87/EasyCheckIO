using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Excel._03_DataBlock
{ 
    public class ExcelHeaderValue
    {
        public int Index { get; }

        public XLCellValue Value { get; set; }


        public ExcelHeaderValue(int index, XLCellValue value)
        {
            Index = index;
            Value = value;
        }
    }
}

