using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IStore<T> where T : class
    {
        T Entity { get; }
        void Clear();
        void NextPage(string level);
        void PreviewPage(string level);
        string TotalRecords { get; }
        string PageNumText { get; }

    }
}