using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Program.Extensions;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._24_Messenger;
using EasyCheckIoCore.Shared._80_Util;
using EasyCheckIoCore.Siemens._13_Helper;
using EasyCheckIoCore.Siemens._30_Lgc;

namespace EasyCheckIoCore.ViewModel.Siemens.Template
{
    public partial class t_SaveTagsViewModel : BaseViewModel
    {
        private readonly ICoreServices _CoreServices;
        private readonly IJsonService _JsonService;
        private readonly IEnumerable<t_S7TagViewModel> _S7Tags;

        #region Properties

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotSaveTags))]
        private bool _IsSaveTags;

        public bool IsNotSaveTags=>!IsSaveTags;



        #region FileName

        [ObservableProperty]
        private string _FileName;
        #endregion
        [ObservableProperty]
        private string _Message;

        #endregion

        #region ctr
        public t_SaveTagsViewModel(ICoreServices coreServices, IJsonService jsonService,IEnumerable<t_S7TagViewModel> s7Tags) : base(coreServices)
        {
            _CoreServices = coreServices;
            _JsonService = jsonService;
            _S7Tags= s7Tags;    
        }

        #endregion

        #region SaveFile
        [RelayCommand]
        public async Task SaveFile()
        {
            string message=string.Empty;
            IsSaveTags = true;
            CancellationTokenSource CancelSaveFile = new();
            var minimumRefreshTimeTask = Task.Delay(TimeSpan.FromSeconds(2), CancelSaveFile.Token);
            try
            {
                if (!string.IsNullOrWhiteSpace(FileName))
                {
                    if (_S7Tags.Count() > 0)
                    {
                        var s7tagList = S7Helper.ConvertIenumerableS7TagsViewToS7Tag(_S7Tags);
                        await _JsonService.SaveJsonFileInFolder(FileName, s7tagList, CancelSaveFile.Token).ConfigureAwait(false);
                        message = "Saved";
                    }
                    else
                    {
                        message = "No elements found in the list";
                    }
                }
                else
                    message = "File name cannot be null";
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }
            finally
            {
                await minimumRefreshTimeTask.ConfigureAwait(false);
                IsSaveTags = false;
                Message = message;

            }

        }

        #endregion

    }
}
