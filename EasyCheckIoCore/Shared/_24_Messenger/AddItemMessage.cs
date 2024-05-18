using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.Shared._24_Messenger
{
    public class AddItemMessage : ValueChangedMessage<S7Tag>


    {
        public AddItemMessage(S7Tag value) : base(value)
        {

        }
    }
}
