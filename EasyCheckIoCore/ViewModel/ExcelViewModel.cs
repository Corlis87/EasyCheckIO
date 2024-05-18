using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Excel._08_Builder;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class ExcelViewModel : BaseViewModel
    {
        #region Fields

        private readonly IExcelLgc _excelLgc;

        #endregion

        #region Properties

        #region FilePath
        [ObservableProperty]
        private string _FilePath;
        #endregion

        #endregion

        #region ctr
        public ExcelViewModel(ICoreServices coreServices, IExcelLgc excelLgc) : base(coreServices)
        {
        _excelLgc = excelLgc;
            _FilePath = "C:\\Users\\wawaw\\Documents\\PLCTAGS.xlsx";
        }

        #endregion

        #region Method

        #region ImportAll

        [RelayCommand]

        public void ImportAll()
        {
            var excelbuilder = new ExcelBuilder().OpenFile(FilePath, 1);
            excelbuilder.ReadColumns(new List<string>(){"Name","Path" });
        }
        #endregion

        #endregion
    }
}
