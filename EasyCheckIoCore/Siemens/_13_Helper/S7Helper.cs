using DocumentFormat.OpenXml.Drawing.Charts;
using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.ViewModel;
using static Sharp7.S7Consts;
using S7Tag = EasyCheckIoCore.Siemens._03_DataBlock.S7Tag;

namespace EasyCheckIoCore.Siemens._13_Helper
{
    public class S7Helper : IS7Helper
    {
        public static byte[] CreateBufferSize(S7WordLength VarType)
        {
            switch (VarType)
            {
                case S7WordLength.Bit:
                case S7WordLength.Byte:
                    return new byte[1];
                case S7WordLength.Int:
                    return new byte[2];
                case S7WordLength.DInt:
                    return new byte[4];
                case S7WordLength.Real:
                    return new byte[4];
                default:
                    return null;
            }
        }

        public static S7Area CreateS7Area(eS7io io)
        {
            switch (io)
            {
                case eS7io.Input:
                    return S7Area.PE;
                case eS7io.AnalogicInput:
                    return S7Area.PE;
                case eS7io.Output:
                    return S7Area.PA;
                case eS7io.AnalogicOutput:
                    return S7Area.PA;
                default:
                    return 0;
            }
        }
        public static List<S7Tag> ConvertIenumerableS7TagsViewToS7Tag(IEnumerable<t_S7TagViewModel> t_S7TagViewModel)
        {
            List<S7Tag> tags = new();
            foreach (var item in t_S7TagViewModel)
            {
                tags.Add(new S7Tag(item.Name, item.IO, item.Byte, item.Bit, item.Comment, item.DataType, item.Notes, item.Status));
            }
            return tags;
        }

        public static bool IsBooleanCheck(S7WordLength s7WordLength)
        {
            switch(s7WordLength)
            { 
            case S7WordLength.Bit: 
                    return true;
            default: 
                    return false;
            }

        }
        public static object ReCreateData(S7Tag item, byte[][] buffer)
        {
            int ModuleType = 0;

            switch (item.IO)
            {
                case eS7io.Input:
                case eS7io.AnalogicInput:
                    ModuleType = 0;
                    break;
                case eS7io.Output:
                case eS7io.AnalogicOutput:
                    ModuleType = 1;
                    break;
            }

                    if (item.DataType == S7WordLength.Bit)
                        return S7.GetBitAt(buffer[ModuleType], item.Byte, item.Bit);
                    if (item.DataType == S7WordLength.Byte)
                        return S7.GetByteAt(buffer[ModuleType], item.Byte);
                    if (item.DataType == S7WordLength.Int)
                        return S7.GetIntAt(buffer[ModuleType], item.Byte);
                    if (item.DataType == S7WordLength.DInt)
                        return S7.GetDIntAt(buffer[ModuleType], item.Byte);
                    if (item.DataType == S7WordLength.Real)
                        return S7.GetRealAt(buffer[ModuleType], item.Byte);

            return null;
        }

        public static void CreateTag(S7Tag s7Tag)
        {
            var _byte = (s7Tag.DataType == S7WordLength.Bit) ? s7Tag.Byte * 8 + s7Tag.Bit : (int)s7Tag.Byte;    // Adjust For Reading Bit |   I10.2 => Byte*8+bit = 82
            s7Tag.Address = "" + S7Helper.CreateAddressAcronymFromIO(s7Tag.IO) + s7Tag.Byte + "." + s7Tag.Bit;
         //   s7Tag.Tag = new S7Consts.S7Tag { Area = (int)S7Helper.CreateS7Area(s7Tag.IO), DBNumber = 0, Start = _byte, Elements = 1, WordLen = (int)s7Tag.DataType };
            //  s7Tag.Buffer = S7Helper.CreateBufferSize(s7Tag.DataType);
        }

        public static string CreateAddressAcronymFromIO(eS7io eS7Io)
        {
            var AddressAcronym = string.Empty;
            switch (eS7Io)
            {
                case eS7io.Input:
                    AddressAcronym = "I";
                    break;
                case eS7io.AnalogicInput:
                    AddressAcronym = "IW";
                    break;
                case eS7io.Output:
                    AddressAcronym = "Q";
                    break;
                case eS7io.AnalogicOutput:
                    AddressAcronym = "QW";
                    break;
            }

            return AddressAcronym;
        }

    }
}