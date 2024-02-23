
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using HslCommunication.Profinet.AllenBradley;
using HslCommunication;
using HslCommunication.Core;
using System.Windows.Input;
using DocumentFormat.OpenXml.Drawing;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TiaFrameworkCore.ViewModel
{
    public partial class _40_AllendBradleyViewModel : BaseViewModel
    {
        #region Fields

        private AllenBradleyNet Client;
        private bool _IsNotConnect => !IsConnected;

        #endregion

        #region Properties

        #region Name
        [ObservableProperty]
        private string _Name;
        #endregion

        #region Address
        [ObservableProperty]
        private string _Address;
        #endregion

        #region Port

        [ObservableProperty]
        int _Port;

        #endregion

        #region Rack

        [ObservableProperty]
        int _Rack;

        #endregion

        #region Slot

        [ObservableProperty]
        byte _Slot;

        #endregion

        #region ReadTag
        [ObservableProperty]
        private string _ReadTag;
        #endregion

        #region WriteTag
        [ObservableProperty]
        private string _WriteTag;
        #endregion

        #region ReadResult

        [ObservableProperty]
        private string _ReadResult = string.Empty;

        #endregion

        #region WriteResult

        [ObservableProperty]
        private string _WriteResult = string.Empty;

        #endregion

        #region WriteValue
        [ObservableProperty]
        private string _WriteValue;
        #endregion

        #region IsConnected
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DisconnectCommand))]
        private bool _IsConnected;

        #endregion

        #endregion

        #region ctr
        public _40_AllendBradleyViewModel(ICoreServices coreServices) : base(coreServices)
        {
            Port = 44818;

        }
        #endregion

        #region Method

        #region Connect

        [RelayCommand(CanExecute = nameof(_IsNotConnect))]
        public async Task Connect()
        {
            Client = new AllenBradleyNet();
            Client.Port = Port;
            Client.Slot = Slot;
            Client.IpAddress = Address;
            OperateResult connect = await Client.ConnectServerAsync();
            if (connect.IsSuccess)
            {
                IsConnected = true;
                AddReadResult(connect.Message);
            }
            else
                AddReadResult(connect.Message);

            ConnectCommand.NotifyCanExecuteChanged();
        }

        #endregion

        #region Disconnect

        [RelayCommand(CanExecute = nameof(IsConnected))]
        public async Task Disconnect()
        {
            OperateResult disconnect = await Client.ConnectCloseAsync();
            if (disconnect.IsSuccess)
            {
                IsConnected = false;
                AddReadResult(disconnect.Message);
            }
            else
                AddReadResult(disconnect.Message);

            ConnectCommand.NotifyCanExecuteChanged();
        }

        #endregion

        #region ReadBool

        [RelayCommand]
        public async Task ReadBool()
        {
            OperateResult<bool> read = await Client.ReadBoolAsync(ReadTag);
            AddReadResult<bool>(read);
        }

        #endregion

        #region ReadByte

        [RelayCommand]
        public async Task ReadByte()
        {
            OperateResult<byte> read = await Client.ReadByteAsync(ReadTag);
            AddReadResult<byte>(read);
        }

        #endregion

        #region ReadInt
        [RelayCommand]
        public async Task ReadInt()
        {
            OperateResult<Int16> read = await Client.ReadInt16Async(ReadTag);
            AddReadResult<Int16>(read);
        }

        #endregion

        #region ReadDint
        [RelayCommand]
        public async Task ReadDint()
        {
            OperateResult<int> read = await Client.ReadInt32Async(ReadTag); 
            AddReadResult<int>(read);
        }

        #endregion

        #region ReadFloat
        [RelayCommand]
        public async Task ReadFloat()
        {
            OperateResult<float> read = await Client.ReadFloatAsync(ReadTag);
            AddReadResult<float>(read);
        }

        #endregion

        #region WriteBool
        [RelayCommand]
        public async Task WriteBool()
        {
            try
            {
                bool[] value = WriteValue.ToStringArray<bool>();
                var result=  await Client.WriteAsync(WriteTag, value);
                AddWriteResult(result);
            }
            catch (Exception ex)
            {
                AddWriteResult("Bool Data is not corrent: " + ex.Message);
            }
        
        }

        #endregion

        #region WriteByte
        [RelayCommand]
        public async Task WriteByte()
        {
            try
            {
                byte[] value = WriteValue.ToStringArray<byte>();
                var result = await Client.WriteAsync(WriteTag, value);
                AddWriteResult(result);
            }
            catch (Exception ex)
            {
                AddWriteResult("Bool Data is not corrent: " + ex.Message);
            }

        }

        #endregion

        #region WriteInt
        [RelayCommand]
        public async Task WriteInt()
        {
            try
            {
                short[] value = WriteValue.ToStringArray<short>();  
                var result = await Client.WriteAsync(WriteTag,value);
                AddWriteResult(result);
            }
            catch (Exception ex)
            {
                AddWriteResult("Short Data is not corrent: " + ex.Message);
            }

        }

        #endregion

        #region WriteDint
        [RelayCommand]
        public async Task WriteDint()
        {
            try
            {
                int[] value = WriteValue.ToStringArray<int>();
                var result = await Client.WriteAsync(WriteTag, value);
                AddWriteResult(result);
            }
            catch (Exception ex)
            {
                AddWriteResult("Short Data is not corrent: " + ex.Message);
            }

        }

        #endregion

        #region WriteFloat
        [RelayCommand]
        public async Task WriteFloat()
        {
            try
            {
                float[] value = WriteValue.ToStringArray<float>();
                var result = await Client.WriteAsync(WriteTag, value);
                AddWriteResult(result);
            }
            catch (Exception ex)
            {
                AddWriteResult("Short Data is not corrent: " + ex.Message);
            }

        }

        #endregion

        #region AddReadResult
        private void AddReadResult(string result)
        {
            ReadResult = ReadResult + result + Environment.NewLine;
        }
        private void AddReadResult<T>(OperateResult<T> operateResult)
        {
            if (operateResult.IsSuccess)
                AddReadResult(DateTime.Now.ToString("[HH:mm:ss] ") + operateResult.Content.ToString() + $" Success");
            else
                AddReadResult(DateTime.Now.ToString("[HH:mm:ss] ") + operateResult.Content.ToString() + $" Failed");
        }
        #endregion

        #region AddWriteResult
        private void AddWriteResult(string result)
        {
            WriteResult = WriteResult + result + Environment.NewLine;
        }

        private void AddWriteResult(OperateResult operateResult)
        {
            if (operateResult.IsSuccess)
                AddWriteResult(DateTime.Now.ToString("[HH:mm:ss] ") + operateResult.Message);
            else
                AddWriteResult(DateTime.Now.ToString("[HH:mm:ss] ") + operateResult.Message + $" Failed");
        }

        #endregion

        #endregion
    }
}

