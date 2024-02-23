using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface IEventLogsService
    {
        void UpdateErrorMessage(byte code, string message, string TypeError);
    }
}
