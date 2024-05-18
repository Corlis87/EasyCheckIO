using System;
using System.Text.Json;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.Shared._11_Contracts;

namespace EasyCheckIoCore.Shared._11_Contracts
{
    public interface IJsonService
    {
        OperationResult<List<string>> ReadJsonFilesInFolder();
        Task<OperationResult> SaveJsonFileInFolder<T>(string filename, T value, CancellationToken cancellation);
        Task<OperationResult<T>> LoadJsonFile<T>(string filename);
        OperationResult DeleteJsonFileInFolder(string filename);
    }
}
