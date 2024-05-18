using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Siemens._03_DataBlock;
using EasyCheckIoCore.Shared._23_Store;
using EasyCheckIoCore.Excel._08_Builder;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Storage;
using DocumentFormat.OpenXml.Spreadsheet;

namespace EasyCheckIoCore.ViewModel
{
    public partial class SiemensLoadTagsViewModel : BaseViewModel
    {
        #region Fields

        private readonly IJsonService _JsonService;
        private readonly IS7Lgc _S7Lgc;
        private readonly IDirectoryService _DirectoryService;
        #endregion

        #region Properties

        #region NotificationViewModel

        private MessageNotifyViewModel _MessageNotify;

        public MessageNotifyViewModel MessageNotifyViewModel
        {
            get { return _MessageNotify; }
            set
            {
                SetProperty(ref _MessageNotify, value);
            }
        }
        #endregion

        #region SaveTags
        [ObservableProperty]
        private List<string> _SavedTags;

        #endregion

        #region IsSelectFileMenuVisible

        [ObservableProperty]
        private bool _IsSelectFileMenuVisible;

        #endregion

        #region SelectedFile

        [ObservableProperty]
        private string _SelectedFile;
        #endregion

        #endregion

        #region ctr
        public SiemensLoadTagsViewModel(ICoreServices coreServices, IJsonService jsonService, IS7Lgc s7Lgc, IDirectoryService directoryService) : base(coreServices)
        {
            _DirectoryService = directoryService;
            _JsonService = jsonService;
            _S7Lgc = s7Lgc;
            _SavedTags = new List<string>();
            MessageNotifyViewModel = new();
            RefreshSaveFiles();
        }

        #endregion

        #region Method

        #region ExportExcelFile
        [RelayCommand]
        public async Task ExportExcelFile()
        {

                var excelStreamFile = new ExcelBuilder()
                    .CreateWorkSheet()
                    .PopulateS7Tags(_S7Lgc.ViewValue.Tags.ToList())
                    .SaveAtStreamFile();
                await FileSaver.SaveAsync("CheckIO.xlsx", excelStreamFile);
                excelStreamFile.Close();
        }




        #endregion

        #region SelectFile

        [RelayCommand]
        public void SelectFile()
        {
            IsSelectFileMenuVisible = true;
        }
        #endregion

        #region LoadFile
        [RelayCommand]
        public async Task LoadFile()
        {
            CancellationTokenSource CancelSaveFile = new();
            var minimumRefreshTimeTask = Task.Delay(TimeSpan.FromSeconds(1), CancelSaveFile.Token);
            try
            {
                var result = await _JsonService.LoadJsonFile<List<S7Tag>>(SelectedFile);
                _S7Lgc.CompileS7Tags(result.Content);
            }
            catch (Exception ex)
            {
                MessageNotifyViewModel.UpdateMessage(ex.Message, true);
            }
            finally
            {
                await minimumRefreshTimeTask.ConfigureAwait(false);
                MessageNotifyViewModel.UpdateMessage("Backup Loaded Success", false);
            }



        }
        #endregion

        #region RemoveFile

        [RelayCommand]
        public void RemoveFile()
        {
            var result = _JsonService.DeleteJsonFileInFolder(SelectedFile);
            if (result.IsSuccess)
                MessageNotifyViewModel.UpdateMessage("File Remove Success", false);
            else
                MessageNotifyViewModel.UpdateMessage(result.Message, true);

            RefreshSaveFiles();
        }
        #endregion

        #region CloseMenu

        [RelayCommand]
        public void CloseMenu()
        {
            IsSelectFileMenuVisible = false;
        }
        #endregion

        #region RefreshSavefiles
        public void RefreshSaveFiles()
        {
            var result = _JsonService.ReadJsonFilesInFolder();
            SavedTags = result.Content;
        }
        #endregion

        #endregion
    }
}
