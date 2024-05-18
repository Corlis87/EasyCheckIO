using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Serilog;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._03_Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class EventLogViewModel : BaseViewModel
    {
        #region Fields

        private readonly IEventLogsService EventLogsService;

        [ObservableProperty]
        List<EventLogData> _SystemEventLogList;
        #endregion

        #region Proprieties

        [ObservableProperty]
        private string _SelectedLevel="All";

        #endregion

        #region ctr
        public EventLogViewModel(ICoreServices coreServices,IEventLogsService eventLogsService) : base(coreServices)
        {
            EventLogsService = eventLogsService;
        }

        #endregion

        #region Method

        #region ClearSystemEventLog

        [RelayCommand]
        public void ClearSystemEventLog()
        {
            EventLogsService.ClearPageSystemEventDB(SelectedLevel);
            SystemEventLogList= EventLogsService.SystemEventLogList; 
        }

        #endregion

        #region RefreshSystemEventLog

        [RelayCommand]
        public void RefreshSystemEventLog()
        {
            EventLogsService.ReadSystemEventDB(SelectedLevel);
            SystemEventLogList= EventLogsService.SystemEventLogList; 
        }

        #endregion

        #region NextPageSystemEventLog

        [RelayCommand]
        public void NextPageSystemEventLog()        
        {
            EventLogsService.NextPageSystemEventDB(SelectedLevel);
            SystemEventLogList = EventLogsService.SystemEventLogList;
        }

        #endregion

        #region PreviewPageSystemEventLog

        [RelayCommand]
        public void PreviewPageSystemEventLog()
        {
            EventLogsService.PreviewPageSystemEventDB(SelectedLevel);
            SystemEventLogList = EventLogsService.SystemEventLogList;
        }
        #endregion

        #endregion

    }
}
