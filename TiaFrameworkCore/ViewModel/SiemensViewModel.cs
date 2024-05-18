using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._24_Messenger;

namespace TiaFrameworkCore.ViewModel
{
    public partial class SiemensViewModel : BaseViewModel
    {

        #region Fields

        private IS7Lgc _S7Lgc;
        private readonly IDirectoryService _DirectoryService;
        private readonly IExcelLgc _ExcelLgc;

        #endregion

        #region Property
        public t_PartialModulesCollectionViewModel HwDeviceListPartialViewModel { get; }
        #endregion

        #region ctr
        public SiemensViewModel(ICoreServices coreServices, 
            IS7Lgc s7Lgc, 
            IDirectoryService directoryService, 
            IExcelLgc excelLgc) : base(coreServices)
        {
            _S7Lgc = s7Lgc;
            _DirectoryService = directoryService;
            _ExcelLgc = excelLgc;
            HwDeviceListPartialViewModel = new t_PartialModulesCollectionViewModel(_S7Lgc);

        }

        #endregion

        #region Method

        #region Add

        [RelayCommand]
        public async Task Add()
        {
            await NavigationService.NavigateToHwDeviceConfigView();
        }
        #endregion 

        #region Edit
        [RelayCommand]
        public async Task Edit()
        {
            await NavigationService.NavigateToHwDeviceEditPlcProfileView();
        }

        #endregion

        #region ImportTags
        [RelayCommand]

        public async Task ImportTags()
        {
            var filePathString = await _DirectoryService.GetExcelFile();
            if (filePathString.IsSuccess)
            {
                var result = _ExcelLgc.ImportTags(filePathString.Content);
                _S7Lgc.Param.Tags = result;
                HwDeviceListPartialViewModel.ModulesCollectionChanged();
            }
        }

        #endregion

        #region ClearAll

        [RelayCommand]
        public void ClearAll()
        {
            _S7Lgc.Param.Tags.Clear();
            HwDeviceListPartialViewModel.ModulesCollectionChanged();
        }

        #endregion

        #region CompilePage

        [RelayCommand]

        public void CompilePage()
        {
            NavigationService.NavigateToCompilePageView();
        }

        #endregion;

        #endregion

        #region Events





        #endregion
    }
}
