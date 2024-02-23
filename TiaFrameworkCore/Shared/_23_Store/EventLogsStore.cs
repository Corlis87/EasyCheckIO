using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;

namespace TiaFrameworkCore.Shared._23_Store
{
    public class EventLogsStore
    {
        #region Property

        #region Errors
        public IEnumerable<EventMsg> ErrMsg => _ErrMsg;

        private List<EventMsg> _ErrMsg;
        #endregion

        #region CoraMsg
        public IEnumerable<EventMsg> CoraMsg => _CoraMsg;

        private List<EventMsg> _CoraMsg;
        #endregion

        #endregion

        #region Event

        public event Action<string> ErrorChanged;

        #endregion

        #region ctr
        public EventLogsStore()
        {
            _ErrMsg = new List<EventMsg>();
            _CoraMsg = new List<EventMsg>();
        }


        #endregion

        #region Method

        #region AddErrMsg
        public void AddErrMsg(EventMsg message)
        {
            _ErrMsg.Insert(0, message);
            OnErrorChanged(message.Message);
        }

        #endregion

        #region GetErrorMessages
        public IEnumerable<EventMsg> GetErrMsg()
        {
            return ErrMsg;
        }
        #endregion

        #region GetCoraMessages
        public IEnumerable<EventMsg> GetCoraMsg()
        {
            return CoraMsg;
        }
        #endregion

        #endregion

        #region Event
        private void OnErrorChanged(string message)
        {
            ErrorChanged?.Invoke(message);
        }
        #endregion
    }
}

