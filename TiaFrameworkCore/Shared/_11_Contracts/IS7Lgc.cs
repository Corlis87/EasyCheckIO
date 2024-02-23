using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Program.Events;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface IS7Lgc
    {
        S7Param Param { get; set; }
        S7ViewValue ViewValue { get; }
        S7DB DB { get; set; }
        OperationResult CompileS7Tags();
        OperationResult Disconnect();
     //   event EventHandler<ValueEventArgs<List<S7Tag>>> TagsChanged;
        OperationResult Connect(S7NetConfig s7HwConfig);
        void RefreshTagsView();
        void RefreshTagsView(IEnumerable<S7Tag> taglist);
        OperationResult CompileS7Tags(List<S7Tag> s7Tags);
    }
}
