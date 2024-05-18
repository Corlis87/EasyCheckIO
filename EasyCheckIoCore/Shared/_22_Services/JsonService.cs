using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Text;
using System.Text.Json;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;


namespace TiaFrameworkCore.Shared._22_Services
{
    public class JsonService : IJsonService
    {
        public OperationResult<List<string>> ReadJsonFilesInFolder()
        {
            try
            {
                var result = new DirectoryInfo(FileSystem.AppDataDirectory).GetFiles("*.json").Select(o => o.Name).ToList();
                return new OperationResult<List<string>> { Content = result, IsSuccess = true };
            }
            catch (Exception)
            {
                return new OperationResult<List<string>> { Content = null, IsSuccess = false };
            }
        }

        public async Task<OperationResult> SaveJsonFileInFolder<T>(string filename, T value, CancellationToken cancellation)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string data = System.Text.Json.JsonSerializer.Serialize<T>(value, options);
            var path = Path.Combine(FileSystem.AppDataDirectory, filename+".json"); 
            await File.WriteAllTextAsync(path, data, cancellation);
            return new OperationResult { IsSuccess = true };
        }

        public async Task<OperationResult<T>> LoadJsonFile<T>(string filename)
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, filename);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var rawdata = File.ReadAllText(path);
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(rawdata));
            if (File.Exists(path))
            {
                var rawData = File.ReadAllText(path);
                var readHC = await JsonSerializer.DeserializeAsync<T>(stream, options);
                return new OperationResult<T> { Content = readHC, IsSuccess = true };
            }
            return new OperationResult<T> { IsSuccess = false,Message="File Not Found" };
        }

        public OperationResult DeleteJsonFileInFolder(string filename)
        {
            try
            {
                var result = new DirectoryInfo(FileSystem.AppDataDirectory).GetFiles("*.json");
                foreach ( var file in result) 
                {
                    if (file.Name == filename)
                    {
                        file.Delete();
                        break;
                    }
                }
                return new OperationResult {  IsSuccess = true };
            }
            catch (Exception)
            {
                return new OperationResult { IsSuccess = false };
            }
        }
    }
}
