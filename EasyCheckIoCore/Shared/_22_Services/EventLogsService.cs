﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._23_Store;
using EasyCheckIoCore.Shared._03_Models;
using Serilog;

namespace EasyCheckIoCore.Shared._22_Services
{
    public class EventLogsService : IEventLogsService
    {
        #region Fields

        private SystemEventLogStore SystemEventLogStore;

        #endregion

        #region Property
        public List<EventLogData> SystemEventLogList => SystemEventLogStore.Entity;
        #endregion

        #region ctr
        public EventLogsService()
        {
            SystemEventLogStore = new SystemEventLogStore();
        }
        #endregion

        public void ReadSystemEventDB(string level)
        {
            SystemEventLogStore.ReadEventLogDatabase(level);
        }

        public void NextPageSystemEventDB(string level)
        {
            SystemEventLogStore.NextPage(level);
        }

        public void PreviewPageSystemEventDB(string level)
        {
            SystemEventLogStore.PreviewPage(level);
        }

        public void ClearPageSystemEventDB(string level)
        {
            SystemEventLogStore.Clear();
        }


    }
}
