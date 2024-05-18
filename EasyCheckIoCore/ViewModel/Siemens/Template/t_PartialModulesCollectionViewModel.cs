using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._24_Messenger;

namespace TiaFrameworkCore.ViewModel
{ 

 public partial class t_PartialModulesCollectionViewModel : ObservableObject

{
    private readonly IS7Lgc _S7Lgc;

    #region HwDeviceCollection

    [ObservableProperty]
    private ObservableCollection<t_PartialModuleViewModel> _Tags;

    #endregion

    #region ctr
    public t_PartialModulesCollectionViewModel(IS7Lgc s7Lgc)
    {
        _Tags = new ObservableCollection<t_PartialModuleViewModel>();
        _S7Lgc = s7Lgc;
        WeakReferenceMessenger.Default.Register<AddItemMessage>(this, (r, m) =>
        {
            ModulesCollectionChanged(r, m);
        }
);
    }
        #region ModuleCollectionsChange
        private void ModulesCollectionChanged(object r, AddItemMessage m)
        {
            Tags.Clear();
            foreach (var item in _S7Lgc.Param.Tags)
            {
                Tags.Add(new t_PartialModuleViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(), item));
            }
        }
        #endregion

        #region ModuleCollectionsChange
        public void ModulesCollectionChanged()
        {
            Tags.Clear();
            foreach (var item in _S7Lgc.Param.Tags)
            {
                Tags.Add(new t_PartialModuleViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(), item));
            }
        }
        #endregion

        [RelayCommand]
        public void Remove(t_PartialModuleViewModel sender)
        {
            if (sender != null)
            {
                _S7Lgc.Param.Tags.Remove(sender.Tag);
                Tags.Remove(sender);
            }
        }
        #region Events

        #endregion

        #endregion
    }
}