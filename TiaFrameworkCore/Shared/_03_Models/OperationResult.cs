using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public OperationResult(int code, string msg)
        {
            Code = code;
            Message = msg;
        }
        public OperationResult(int code, bool issuccess)
        {
            IsSuccess = issuccess;
            Code = code;
        }
        public OperationResult(int code, string msg, bool issuccess)
        {
            IsSuccess = issuccess;
            Code = code;
            Message = msg;
        }
        #endregion
    }

    public class OperationResult<T> : OperationResult
    {
        //
        // Riepilogo:
        //     用户自定义的泛型数据
        public T Content { get; set; }
    }
}
