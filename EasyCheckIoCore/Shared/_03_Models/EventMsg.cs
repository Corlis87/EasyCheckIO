using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._03_DataBlock
{
    public class EventMsg
    {
        public byte Code { get; }
        public string Message { get; }
        public string TypeError { get; }
        public DateTime DateTime { get; }


        public EventMsg(byte code, string message, string typeerror, DateTime datetime)
        {
            Code = code;
            Message = message;
            TypeError = typeerror;
            DateTime = datetime;
        }
    }
}
