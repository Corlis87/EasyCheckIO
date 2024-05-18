using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Excel._15_Extensions;
using TiaFrameworkCore.Shared._03_DataBlock;

namespace TiaFrameworkCore.Excel._13_Helper
{
    public class ExcelFile

    {
        public IXLWorkbook _WorkBook { get; set; }
        public IXLWorksheet _WorkSheet { get; set; }

        #region OpenFile
        public ExcelFile OpenFile(string filename, int sheet)
        {
            _WorkBook = new XLWorkbook(filename);
            _WorkSheet = _WorkBook.Worksheet(sheet);

            return this;
        }
        #endregion


    }

}


