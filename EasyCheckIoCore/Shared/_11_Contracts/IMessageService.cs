using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IMessageService
    {
        Task DisplayAlert(string title, string msg);
        Task DisplayAlert(string title, string msg, string pos, string neg);
    }
}
