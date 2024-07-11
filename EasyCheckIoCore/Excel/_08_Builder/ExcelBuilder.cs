using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Excel._15_Extensions;
using EasyCheckIoCore.Excel._03_DataBlock;
using EasyCheckIoCore.Siemens._03_DataBlock;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Maui.Storage;
using EasyCheckIoCore.ViewModel;
using Serilog;
using EasyCheckIoCore.Shared._03_DataBlock;

namespace EasyCheckIoCore.Excel._08_Builder
{
    public class ExcelBuilder
    {
        #region Properties
        IXLWorkbook _WorkBook { get; set; }
        IXLWorksheet _WorkSheet { get; set; }
        List<ExcelRowCells> Values { get; set; }
        List<string> ColumnsList { get; set; }

        #endregion

        #region Methods

        #region OpenFile
        public ExcelBuilder OpenFile(string filename, int sheet)
        {
            _WorkBook = new XLWorkbook(filename);
            _WorkSheet = _WorkBook.Worksheet(sheet);
            Values = new List<ExcelRowCells>();
            return this;
        }
        #endregion

        #region CreateFile
        public ExcelBuilder CreateWorkSheet()
        
        {
            _WorkBook = new XLWorkbook();
            _WorkSheet = _WorkBook.Worksheets.Add("Page1");
            return this;
        }

        #endregion

        #region AddClass

        public ExcelBuilder AddList<T>(List<T> list)
        {
            _WorkSheet.Cell("A1").InsertData(list);
            return this;
        }
        #endregion

        #region ReadColumns
        public ExcelBuilder ReadColumns(List<int> columns)
        {
            var headers = _WorkSheet.FirstRow().Cells().Select((v, i) => new { Value = v.Value, Index = i + 1 });

            var rows = _WorkSheet.RowsUsed().Count();

            for (int row = 2; row < rows; row++)
            {
                Values.Add(new ExcelRowCells());
                foreach (var column in columns)
                {
                    foreach (var header in headers)
                    {
                        if (column == header.Index)
                        {
                            Values[row - 2].row = row;
                            Values[row - 2].Cells.Add(new ExcelCellValue(header.Value, _WorkSheet.Row(row).Cell(column).Value));
                        }
                    }
                }
            }
            return this;

        }

        public ExcelBuilder ReadColumns(List<string> columns)
        {
            var headers = _WorkSheet.FirstRow().Cells().Select((v, i) => new { Value = v.Value, Index = i + 1 });

            var rows = _WorkSheet.RowsUsed().Count();

            for (int row = 2; row < rows; row++)
            {
                Values.Add(new ExcelRowCells());
                foreach (var column in columns)
                {
                    foreach (var header in headers)
                    {
                        if (column == header.Value.GetText())
                        {
                            Values[row - 2].row = row;
                            Values[row - 2].Cells.Add(new ExcelCellValue(header.Value, _WorkSheet.Row(row).Cell(header.Index).Value));
                        }
                    }
                }
            }
            return this;

        }
        #endregion

        #region BuildS7Tags
        public List<S7Tag> BuildS7Tags()
        {

            var list = new List<S7Tag>();
            string[] str = new string[] { "Name", "Data Type", "Logical Address", "Comment" };
            foreach (var value in Values)
            {
                try
                {
                    var tag = new S7Tag();
                if (value.Cells[0].ColumnName == str[0])
                    tag.Name = value.Cells[0].Value.GetText();
                if (value.Cells[1].ColumnName == str[1])
                    tag.DataType = value.Cells[1].Value.GetDataType();
                if (value.Cells[2].ColumnName == str[2])
                    tag = value.Cells[2].Value.GetS7Io(tag);
                if (value.Cells[3].ColumnName == str[3])
                    tag.Comment = value.Cells[3].Value.GetText();
 
                    list.Add(new S7Tag(tag.Name, tag.IO, tag.Byte, tag.Bit, tag.Comment, tag.DataType, "", 0));
                }
                catch (Exception ex)
                {
                    var a = new OperationResult(false,ex.Message +" Row: "+value.row, Shared._06_Enum.eLogLevel.Error);
                }
            

            }
            return list;
        }
        #endregion

        #region BuildColumnsList

        public Dictionary<string,List<XLCellValue>> BuildColumnsList()
        {
            var list = new Dictionary<string, List<XLCellValue>>();

            list.Add("Name", new List<XLCellValue>());

                foreach (var item in Values)
                {
                foreach (var item2 in item.Cells)
                {
                    if(item2.Value.GetText() == "Name")
                    {
                        list["Name"].Add(item2.Value);
                    }
                }
                }
            return list;
        }
        #endregion

        #region SaveExcelFile
        public void SaveExcelFile(string path)
        {
            _WorkBook.SaveAs(path);
        }

        public ExcelBuilder PopulateS7Tags(List<t_S7TagViewModel> list)
        {
            _WorkSheet.Cell("A1").Value= "Name";
            _WorkSheet.Cell("B1").Value = "Address";
            _WorkSheet.Cell("C1").Value = "Comment";
            _WorkSheet.Cell("D1").Value = "Tested";
            _WorkSheet.Cell("E1").Value = "Notes";
            for (int i = 0; i < list.Count; i++)
            {
                _WorkSheet.Cell("A" + (i + 2)).Value = list[i].Name;
                _WorkSheet.Cell("B" + (i + 2)).Value = list[i].Address;
                _WorkSheet.Cell("C" + (i + 2)).Value = list[i].Comment;
                switch(list[i].Status)
                {
                    case 0:
                        _WorkSheet.Cell("D" + (i + 2)).Style.Fill.BackgroundColor= XLColor.Red;
                        break;
                    case 1:
                        _WorkSheet.Cell("D" + (i + 2)).Style.Fill.BackgroundColor = XLColor.Yellow;
                        break;
                    case 2:
                        _WorkSheet.Cell("D" + (i + 2)).Style.Fill.BackgroundColor = XLColor.Green;
                        break;
                }
              
                _WorkSheet.Cell("E" + (i + 2)).Value = list[i].Notes;
            }

            return this;
        }

        #endregion

        #region SaveAtStreamFile
        public Stream SaveAtStreamFile()
        {
            Stream streamexcel = new MemoryStream();
          _WorkBook.SaveAs(streamexcel);
            streamexcel.Position = 0;
            return streamexcel;
         
        }

        #endregion

        #endregion
    }
}
