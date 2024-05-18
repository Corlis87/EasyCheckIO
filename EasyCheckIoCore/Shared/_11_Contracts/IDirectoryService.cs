using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface IDirectoryService

    {
        Task<OperationResult<string>> GetExcelFile();
        Task<OperationResult<string>> SelectFolder();
    }
}
