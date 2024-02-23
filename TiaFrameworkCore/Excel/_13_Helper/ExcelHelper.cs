using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using ClosedXML.Excel;
using TiaFrameworkCore.Excel._03_DataBlock;

namespace TiaFrameworkCore.Excel._13_Helper
{
    public static class ExcelHelper

    {

        #region ReadHeaderColumns
        public static List<ExcelHeaderValue> ReadHeaderColumns(ExcelFile excelfile)
        {
            var HeaderValue = new List<ExcelHeaderValue>();
            var headers = excelfile._WorkSheet.FirstRow().Cells().Select((v, i) => new { v.Value, Index = i + 1 });


            foreach (var header in headers)
            {
                HeaderValue.Add(new ExcelHeaderValue(header.Index, header.Value));
            }

            return HeaderValue;

        }
        #endregion

        #region ReadColumns
        public static List<ExcelColumnsCells> ReadColumns(ExcelHeaderValue excelHeader, ExcelFile excelFile)
        {

            var ColumnsValue = new List<ExcelColumnsCells>();
            var rows = excelFile._WorkSheet.RowsUsed().Count();
            var column = new ExcelColumnsCells();
            column.columns = excelHeader.Index;
            for (int row = 2; row < rows; row++)
            {
                column.Cells.Add(new ExcelCellValue(excelHeader.Value, excelFile._WorkSheet.Row(row).Cell(row).Value));
            }
            return ColumnsValue;
        }
        #endregion
    }
}
