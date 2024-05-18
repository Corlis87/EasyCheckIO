using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._80_Util;
using TiaFrameworkCore.Siemens._13_Helper;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.ViewModel
{
    public partial class t_S7TagViewModel : BaseViewModel
    {

        #region Properties

        #region Name
        [ObservableProperty]
        private string _Name = string.Empty;


        #endregion

        #region IO
        [ObservableProperty]
        private eS7io _IO = eS7io.Input;

        #endregion

        #region DataType
        [ObservableProperty]
        private S7WordLength _DataType = S7WordLength.Byte;

        #endregion

        #region Byte
        [ObservableProperty]
        private int _Byte;



        #endregion

        #region Bit
        [ObservableProperty]
        private int _Bit;

        #endregion

        #region Address

        [ObservableProperty]

        private string _Address;
        #endregion

        #region Comment
        [ObservableProperty]
        private string _Comment = string.Empty;
        [ObservableProperty]
        private object _Content;

        #endregion

        #region ScalingMenuVisibility 

        public bool ScalingMenuVisibility { get; }
        #endregion

        #region Scale
        public Scalex Scale { get; }
        #endregion

        #region Binary

        [ObservableProperty]
        private string _Binary;

        public t_S7TagViewModel(ICoreServices coreServices) : base(coreServices)
        {
        }

        #endregion

        #region Notes

        [ObservableProperty]

        string _Notes = string.Empty;

        #endregion

        #region Status

        [ObservableProperty]
        int _Status;

        #endregion

        #endregion

        #region Method

        public void Scaling()
        {
            Scale.Scale(Content);
        }

        [RelayCommand]
        public async Task ScalingPopout(t_S7TagViewModel s7TagView)
        {
            await NavigationService.NavigateToScaling(s7TagView);
        }

        #endregion

        #region ctr
        public t_S7TagViewModel(ICoreServices coreServices, S7Tag tag) : base(coreServices) 
        {
            Scale = new Scalex();
            Name = tag.Name;
            IO = tag.IO;
            DataType = tag.DataType;
            Byte = tag.Byte;
            Bit = tag.Bit;
            Comment = tag.Comment;
            Content = tag.Content;
            Address = tag.Address;
            Status= tag.Status;
            Notes = tag.Notes;
            ScalingMenuVisibility= !S7Helper.IsBooleanCheck(DataType);
        }

        #endregion
    }
}
