using CommunityToolkit.Mvvm.ComponentModel;
using DocumentFormat.OpenXml.ExtendedProperties;
using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Siemens._13_Helper;
using static Sharp7.S7Consts;

namespace EasyCheckIoCore.Siemens._03_DataBlock
{
    public class S7Tag : S7Address
    {

        #region Property

        #region Name
        private string _Name = string.Empty;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
        #endregion

        #region IO
        private eS7io _IO = eS7io.Input;

        public eS7io IO
        {
            get { return _IO; }
            set { _IO = value; }
        }
        #endregion

        #region DataType
        private S7WordLength _DataType = S7WordLength.Byte;
        public S7WordLength DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        #endregion

        #region Byte
        private int _Byte;

        public int Byte
        {
            get { return _Byte; }
            set { _Byte = value; }
        }

        #endregion

        #region Bit
        private int _Bit;

        public int Bit
        {
            get { return _Bit; }
            set { _Bit = value; }
        }

        #endregion

        #region Address

        private string _Address = string.Empty;

        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
            }
        }

        #endregion

        #region Comment
        private string _Comment = string.Empty;

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        #endregion

        #region Notes

        private string _Notes = string.Empty;

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        #endregion

        #region Status

        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        #endregion

        #endregion

        #region ctr

        public S7Tag()
        {
        }

        public S7Tag(string name, eS7io io, int _byte, int bit, string comment, S7WordLength datatype, string notes, int status)
        {
            Name = name;
            IO = io;
            Byte = _byte;
            Bit = bit;
            DataType = datatype;
            Comment = comment;
            Address = "" + S7Helper.CreateAddressAcronymFromIO(IO) + Byte + "." + Bit;
            Notes = notes;
            Status = status;
            //    base.Tag = new S7Consts.S7Tag { Area = (int)S7Helper.CreateS7Area(IO),DBNumber=0,Elements=1,Start=Byte,WordLen=(int)DataType };
            // base.Buffer = S7Helper.CreateBufferSize(DataType);
        }

        #endregion

    }
}

