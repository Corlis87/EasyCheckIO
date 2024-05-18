using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;

namespace EasyCheckIoCore.ViewModel
{
    public partial class SiemensSearchViewModel : BaseViewModel
    {
        #region Fields    
        
        private readonly IS7Lgc _S7lgc;

        #endregion

        #region Property
   
        #region Tags

        private ObservableCollection<t_S7TagViewModel> _Tags;

        public ObservableCollection<t_S7TagViewModel> Tags
        {
            get => _Tags;
            set => SetProperty(ref _Tags, value);
        }
        #endregion

        [ObservableProperty]
        private eS7CollectionFilter _SelectedFilter=eS7CollectionFilter.ADDRESS;

        [ObservableProperty]
        private string _SearchText;

        #endregion

        #region ctr
        public SiemensSearchViewModel(ICoreServices coreServices, IS7Lgc s7Lgc) : base(coreServices)
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
            IList<t_S7TagViewModel> filterItems;

            switch (SelectedFilter)
            {
                case eS7CollectionFilter.ADDRESS:            
                    filterItems = FilterForAddress();
                    break;
                case eS7CollectionFilter.NAME:
                    filterItems = FilterForName();
                    break;
                case eS7CollectionFilter.DESCRIPTION:
                    filterItems = FilterForDescription();
                    break;
                default:
                    filterItems = FilterForAddress();
                    break;

            }
            Tags.Clear();
            foreach (var value in _S7lgc.ViewValue.Tags)
            {
                if (filterItems.Contains(value))
                {
                    Tags.Add(value);
                }
            }
        }

        #endregion

        #region FilterForAddress
        private List<t_S7TagViewModel> FilterForAddress()
        {
            return _S7lgc.ViewValue.Tags.Where(value => !string.IsNullOrEmpty(value.Address) && value.Address.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }

        #endregion

        #region FilterForName
        private List<t_S7TagViewModel> FilterForName()
        {
            return _S7lgc.ViewValue.Tags.Where(value => !string.IsNullOrEmpty(value.Name) && value.Name.StartsWith(SearchText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        #endregion

        #region FilterforDescription
        private List<t_S7TagViewModel> FilterForDescription()
        {
            return _S7lgc.ViewValue.Tags.Where(value => !string.IsNullOrEmpty(value.Comment) && value.Comment.ToLower().Contains(SearchText.ToLower())).ToList();
        }

        #endregion

        #endregion
    }
}
