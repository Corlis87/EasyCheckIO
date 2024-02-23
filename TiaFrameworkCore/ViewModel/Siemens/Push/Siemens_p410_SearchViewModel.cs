using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class Siemens_p410_SearchViewModel : BaseViewModel
    {
        #region Property

        private readonly IS7Lgc _S7lgc;

        [ObservableProperty]
        private string _SearchText;

        #region Tags

        private ObservableCollection<t_S7TagViewModel> _Tags;

        public ObservableCollection<t_S7TagViewModel> Tags
        {
            get => _Tags;
            set => SetProperty(ref _Tags, value);
        }
        #endregion

        #endregion

        #region ctr
        public Siemens_p410_SearchViewModel(ICoreServices coreServices,IS7Lgc s7Lgc) : base(coreServices)
        {
            _Tags = new ObservableCollection<t_S7TagViewModel>();
            _S7lgc = s7Lgc;
        }
        #endregion

        #region Method

        #region SearchTagCommand

        [RelayCommand]
        public void SearchTag()
        {
            var filterItems = _S7lgc.ViewValue.Tags.Where(value => !string.IsNullOrEmpty(value.Address)&& value.Address.StartsWith(SearchText,StringComparison.OrdinalIgnoreCase))?.ToList();
            Tags.Clear();
            foreach (var value in _S7lgc.ViewValue.Tags)
            {
                if(filterItems.Contains(value))
                {
                    Tags.Add(value);
                }
            }
        }

        #endregion

#endregion
    }
}
