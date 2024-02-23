using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.Shared._22_Services
{
    public class CoreServices : ICoreServices
    {
        public INavigationService NavigationService { get; }
        public IMessageService MessageService { get; }

        public CoreServices(INavigationService navigationService,
            IMessageService messageService)
        {
            NavigationService = navigationService;
            MessageService = messageService;
        }
    }
}

