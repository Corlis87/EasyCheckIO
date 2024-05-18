using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Excel._03_DataBlock
{
    public class ExcelColumnsCells
    {
        public int columns { get; set; }

        public List<ExcelCellValue> Cells { get; set; }

        public ExcelColumnsCells()
        {
            Cells = new List<ExcelCellValue>();
        }
    }
}
