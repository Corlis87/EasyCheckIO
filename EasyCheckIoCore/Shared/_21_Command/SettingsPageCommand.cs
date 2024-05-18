using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyCheckIoCore.Shared._21_Command
{
    public class SettingsPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
       
        public void Execute(object parameter)
        {
             Shell.Current.GoToAsync("//Settings");
        }
    }
}
