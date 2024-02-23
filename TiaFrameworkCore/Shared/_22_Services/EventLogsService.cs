using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._23_Store;

namespace TiaFrameworkCore.Shared._22_Services
{
    public class EventLogsService : IEventLogsService
    {
        #region Property

        #region Injections
        private readonly EventLogsStore _EventLogsStore;
        #endregion

        #endregion

        #region ctr
        public EventLogsService(EventLogsStore eventlogsstore)
        {
            _EventLogsStore = eventlogsstore;
        }
        #endregion

        #region UpdateErrorMessage
        public void UpdateErrorMessage(byte code, string message, string TypeError)
        {
            var NewEvent = new _03_DataBlock.EventMsg(code, message, TypeError, DateTime.Now);
            _EventLogsStore.AddErrMsg(NewEvent);
        }
        #endregion


    }
}
