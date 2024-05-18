using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface ICoreServices
    {
        INavigationService NavigationService { get; }
        IMessageService MessageService { get; }
    }
}
