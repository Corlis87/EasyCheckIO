using CommunityToolkit.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.Shared._11_Contracts;

namespace EasyCheckIoCore.Shared._22_Services
{
    public class DirectoryService : IDirectoryService
    {
        private FilePickerFileType _ExcelFileType;
        public DirectoryService()
        {
            Initialize();
        }

        protected void Initialize()
        {
            _ExcelFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                {DevicePlatform.Android,new[]{ "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel" } },
                {DevicePlatform.WinUI,new[]{".xlsx"} }

            });

        }
        public async Task<OperationResult<string>> GetExcelFile()
        {
            OperationResult<string> result = new OperationResult<string>();
            var filepicker = await FilePicker.PickAsync(new PickOptions { PickerTitle = "Import Tags", FileTypes = _ExcelFileType });
            if (filepicker != null)
            {
                result.Content = filepicker.FullPath;
                result.IsSuccess = true;
            }
            return result;
        }

        public async Task<OperationResult<string>> SelectFolder()
        {
            var cancel = new CancellationTokenSource();

            OperationResult<string> result = new OperationResult<string>();
            var folderpicker = await FolderPicker.Default.PickAsync(cancel.Token);
            if (folderpicker != null)
            {
                result.Content = folderpicker.Folder.Path;
                result.IsSuccess = true;
            }
            return result;
        }


   
    }
}
