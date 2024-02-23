using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkUI.Services
{
    public class MessageService : IMessageService
    {
        public async Task DisplayAlert(string title, string msg)
        {
            await Shell.Current.DisplayAlert(title, msg, "ok");
        }

        public async Task DisplayAlert(string title, string msg, string pos, string neg)
        {
            await Shell.Current.DisplayAlert(title, msg, pos, neg);
        }
    }
}
