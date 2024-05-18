using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_Models;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IEventLogsService
    {
        void ReadSystemEventDB(string level);
        void NextPageSystemEventDB(string level);
        void PreviewPageSystemEventDB(string level);
        void ClearPageSystemEventDB(string level);
        List<EventLogData> SystemEventLogList { get; }
    }
}
