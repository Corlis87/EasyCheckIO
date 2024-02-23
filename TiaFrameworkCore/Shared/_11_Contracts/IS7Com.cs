using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface IS7Com
    {
        OperationResult Connect(S7NetConfig HwConfig);
        OperationResult Disconnect();
        void RefreshTagsTask();
       // void AdjMultiVrb(IEnumerable<S7Tag> s7ModulesList);
        event Action TagsChanged;
        void CalculateBuffer(IEnumerable<S7Tag> s7ModulesList);
        void CreateContentFromVariableList(IEnumerable<S7Tag> s7ModulesList);
    }
}
