using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._80_Util;

namespace TiaFrameworkCore.Shared._03_DataBlock
{
    public class OperationResult
    {

        #region Property

        #region IsSuccess

        public bool IsSuccess { get; set; }

        #endregion

        #region Code

        public int Code { get; set; }

        #endregion

        #region Message

        public string Message { get; set; } = string.Empty;

        #endregion

        #endregion

        #region ctr
        public OperationResult() { }
        public OperationResult(bool issuccess)
        {
            IsSuccess = issuccess;
        }
        public OperationResult(bool issuccess, string message,eLogLevel logLevel)
        {
            IsSuccess = issuccess;
            Message = message;
            LoggerUtil.RegistLogMessage(logLevel, message);
        }
        public OperationResult(bool issuccess, int code)
        {
            IsSuccess = issuccess;
            Code = code;
        }
        public OperationResult(bool issuccess, int code, string message,eLogLevel logLevel)
        {
            IsSuccess = issuccess;
            Code = code;
            Message = message;
            LoggerUtil.RegistLogMessage(logLevel, message);
        }
        #endregion
    }

    public class OperationResult<T> : OperationResult
    {
        public OperationResult() { }
        public OperationResult(T content, bool isSuccess)
        {
            Content = content;
            IsSuccess = isSuccess;
        }
        public OperationResult(T content, bool isSuccess, string message,eLogLevel logLevel)
        {
            Content = content;
            IsSuccess = isSuccess;
            Message = message;
            LoggerUtil.RegistLogMessage(logLevel, message);
        }


        public T Content { get; set; }
    }

}

