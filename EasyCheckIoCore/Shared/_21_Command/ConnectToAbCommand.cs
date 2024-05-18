using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._21_Command
{
    public class LoginCommand : AsyncCommandBase
    {


        public LoginCommand(Action<Exception> onException) : base(onException)
        {
        }

        protected override async Task ExecuteAsync(object parameter)
        {

        }
    }
}