using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IExcelLgc
    {
        ObservableCollection<S7Tag> ImportTags(string filename);
    }
}
