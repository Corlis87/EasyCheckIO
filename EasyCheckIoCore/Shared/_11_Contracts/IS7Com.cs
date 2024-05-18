using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IS7Com
    {
        OperationResult Connect(S7NetConfig HwConfig);
        OperationResult Disconnect();
        void RefreshTagsTask();
        void CalculateBuffer(IEnumerable<S7Tag> s7ModulesList);
        void CreateContentFromVariableList(IEnumerable<S7Tag> s7ModulesList);
        event Action TagsChanged;
    }
}
