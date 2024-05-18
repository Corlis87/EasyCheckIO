using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic;
using Serilog;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._80_Util;
using TiaFrameworkCore.Siemens._03_DataBlock;
using TiaFrameworkCore.Siemens._13_Helper;

namespace TiaFrameworkCore.Siemens._30_Lgc
{
    public class S7Com:IS7Com
    {
        #region Fields

        private S7MultiVar MultiVrb;
        private S7Client Client;
        private ITaskInterrupt InterruptRefreshCom;
        private const int IdInput = 0;
        private const int IdOutput = 1;
        #endregion

        #region Properties     

        public event Action TagsChanged;

        #region IsOnline
        public bool IsOnline => Client.Connected;

        #endregion

        #endregion

        #region ctr
        public S7Com()
        {
            Client = new S7Client();
            MultiVrb = new S7MultiVar(Client);
            InterruptRefreshCom = TaskManager.Initialize(100, false, 0, RefreshTagsTask);
        }
        #endregion

        #region Method

        #region Connect

        public OperationResult Connect(S7NetConfig HwConfig)
        {
                Client.SetConnectionType(0x02);     
                Client.ConnectTo(HwConfig.Address, HwConfig.Rack, HwConfig.Slot);
                var result = Client.Connect();
                var message = Client.ErrorText(result);
                CyclicRefresh();
            return new OperationResult(IsOnline,result, message,eLogLevel.Information);
        }

        #endregion

        #region Disconnect 

        public OperationResult Disconnect()
        {
            InterruptRefreshCom.StopAsync();
            var result = Client.Disconnect();
            var message = Client.ErrorText(result);

            return new OperationResult(!IsOnline,result, message,eLogLevel.Information);
        }

        #endregion

        #region ModulesBytesBuffer

        private byte[][] ArrayVariableBuffer = new byte[2][];
        int InputByteMax;
        int InputByteMin;
        int OutputByteMax;
        int OutputByteMin;
        byte[] InputBuffer;
        byte[] OutputBuffer;
        bool IsInputOnList;
        bool IsOutputOnList;

        #region CalculateVariableBuffer
        public void CalculateBuffer(IEnumerable<S7Tag> s7ModulesList)
        {
            InputByteMax = 0;
            OutputByteMax = 0;
            IsInputOnList = false;
            IsOutputOnList = false;
            InputByteMin = int.MaxValue;
            OutputByteMin = int.MaxValue;
 
            foreach (var module in s7ModulesList)
            {
                switch (module.IO)
                {
                    case eS7io.Input:
                    case eS7io.AnalogicInput:
                        if (InputByteMax <= module.Byte)
                            InputByteMax = module.Byte + 4;
                        if (module.Byte < InputByteMin)
                            InputByteMin = module.Byte;
                        IsInputOnList = true;
                        break;                  
                    case eS7io.Output:
                    case eS7io.AnalogicOutput:
                        if (OutputByteMax <= module.Byte)
                            OutputByteMax = module.Byte;
                        if (module.Byte < OutputByteMin)
                            OutputByteMin = module.Byte;
                        IsOutputOnList = true;
                        break;
                }



                //switch (module.IO)
                //{
                //    case eS7io.Input:
                //    if (InputByteMax <= module.Byte)
                //        InputByteMax = module.Byte+4;
                //    if (module.Byte < InputByteMin)
                //        InputByteMin = module.Byte;
                //    IsInputOnList = true;
                //    break;
                //    case eS7io.AnalogicInput:
                //            if (InputByteMax <= module.Byte)
                //                InputByteMax = module.Byte+4;
                //            if (module.Byte < InputByteMin)
                //                InputByteMin = module.Byte;
                //    IsInputOnList = true;                      
                //    break;
                //    case eS7io.Output:
                //    if (OutputByteMax <= module.Byte)
                //        OutputByteMax = module.Byte;
                //    if (module.Byte < OutputByteMin)
                //        OutputByteMin = module.Byte;
                //    IsOutputOnList = true;
                //    break;
                //case eS7io.AnalogicOutput:
                //            if (OutputByteMax <= module.Byte)
                //                OutputByteMax = module.Byte + 4;
                //            if (module.Byte < OutputByteMin)
                //                OutputByteMin = module.Byte;   
                //            IsOutputOnList = true;
                //    break;
                //}  

            }

            if (!IsInputOnList)
                InputByteMin = 0;
            if(!IsOutputOnList)   
                OutputByteMin = 0;

             Array.Resize(ref ArrayVariableBuffer[IdInput], InputByteMax + 1);
             Array.Resize(ref ArrayVariableBuffer[IdOutput], OutputByteMax + 1);

             InputBuffer = new byte[InputByteMax - InputByteMin + 1];
             OutputBuffer = new byte[OutputByteMax - OutputByteMin + 1];

        }

        #endregion

        #region ReadVarFromPlc
        public void ReadVarFromPlc()
        {
         
            if (IsInputOnList)
            {
                Client.ReadArea(S7Area.PE, 0, InputByteMin, InputByteMax - InputByteMin + 1, S7WordLength.Byte, InputBuffer);
                Array.Copy(InputBuffer, 0, ArrayVariableBuffer[IdInput], InputByteMin, InputByteMax - InputByteMin + 1);
            }

            if (IsOutputOnList)
            {
                Client.ReadArea(S7Area.PA, 0, OutputByteMin, OutputByteMax - OutputByteMin + 1, S7WordLength.Byte, OutputBuffer);
                Array.Copy(OutputBuffer, 0, ArrayVariableBuffer[IdOutput], OutputByteMin, OutputByteMax - OutputByteMin + 1);
            }
        }

        #endregion

        #region Copy
        public void CreateContentFromVariableList(IEnumerable<S7Tag> s7ModulesList)
        {
            foreach (var item in s7ModulesList)
            {
                item.Content= S7Helper.ReCreateData(item,ArrayVariableBuffer);
            }
        }
        #endregion

        #endregion

        #region AdjMultiVrb
        //public void AdjMultiVrb(IEnumerable<S7Tag> s7ModulesList)
        //{
        //    MultiVrb.Clear();
        //    foreach (var item in s7ModulesList)
        //    {
        //        MultiVrb.Add(item.Tag, ref item.Buffer);
        //    }
        //}
        #endregion

        #region CyclicRefresh

        public void CyclicRefresh()
        {
            InterruptRefreshCom.Restart();
        }
        #endregion

        #region RefreshRateTask
        public void RefreshTagsTask()
        {
            try
            {
                ReadVarFromPlc();
                TagsChangedEvent();

            }
            catch(Exception ex) 
            {
                InterruptRefreshCom.StopAsync();
                Disconnect();
                Log.Error(ex.Source+"| "+ ex.Message);
            }
        }

        #endregion

        #endregion

        #region Event
        public void TagsChangedEvent()
        {
            TagsChanged?.Invoke();
        }
        #endregion
    }
}
