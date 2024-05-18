using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Excel._08_Builder;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Excel._03_DataBlock;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.Excel._30_Lgc
{
    public class ExcelLgc : IExcelLgc
    {
        public ExcelDB DB;

        #region ctr
        public ExcelLgc()
        {
            DB = new ExcelDB();
        }
        #endregion

        #region ImportFile
        public ObservableCollection<S7Tag> ImportTags(string filename)
        {
            var excelbuilder = new ExcelBuilder();
            DB.Tags = excelbuilder.OpenFile(filename, 1)
                  .ReadColumns(new List<int> { 1, 3, 4, 5 })
                  .BuildS7Tags();

            return new ObservableCollection<S7Tag>(DB.Tags);
        }

        #endregion

        #region ExportFile

        public void ExportFile()
        {

        }

        #endregion

    }
}
