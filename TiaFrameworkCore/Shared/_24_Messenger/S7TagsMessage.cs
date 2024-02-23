using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkCore.Shared._24_Messenger
{
    public class S7TagsMessage : ValueChangedMessage<IEnumerable<t_S7TagViewModel>>
    {
        public S7TagsMessage(IEnumerable<t_S7TagViewModel> value) : base(value)
        {

        }
    }
}
