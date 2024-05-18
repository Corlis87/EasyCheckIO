using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._06_Enum;

namespace TiaFrameworkCore.Shared._80_Util
{
    public static class LoggerUtil
    {

    public static void RegistLogMessage(eLogLevel logLevel,string message)
        {
            switch (logLevel) 
            {
                case eLogLevel.Warning:
                    Log.Warning(message);
                    break;
                case eLogLevel.Error:
                    Log.Error(message);
                    break;
                case eLogLevel.Verbose:
                    Log.Verbose(message);
                    break;
                case eLogLevel.Debug:
                    Log.Debug(message);
                    break;
                case eLogLevel.Information:
                    Log.Information(message);
                    break;
                default:
                    throw new Exception(message);

            }
        }
    }
}
