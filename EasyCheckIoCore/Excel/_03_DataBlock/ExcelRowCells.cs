using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCore.Excel._03_DataBlock
{
    public class ExcelRowCells
    {
        public int row { get; set; }

        public List<ExcelCellValue> Cells { get; set; }

        public ExcelRowCells()
        {
            Cells = new List<ExcelCellValue>();
        }
    }
}
