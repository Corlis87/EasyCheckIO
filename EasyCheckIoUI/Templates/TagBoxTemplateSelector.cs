using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.ViewModel;

namespace EasyCheckIoUI.Templates
{
    public class TagBoxTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AnalogicTagBox { get; set; }
        public DataTemplate DigitalTagBox { get; set; }

        protected override DataTemplate OnSelectTemplate(object item,BindableObject container)
        {
            if(item is t_S7TagViewModel tag) 
            {
            switch(tag.IO) 
                {
                    case EasyCheckIoCore.Shared._06_Enum.eS7io.Input:
                    case EasyCheckIoCore.Shared._06_Enum.eS7io.Output:
                        return DigitalTagBox;
                    case EasyCheckIoCore.Shared._06_Enum.eS7io.AnalogicInput:
                    case EasyCheckIoCore.Shared._06_Enum.eS7io.AnalogicOutput:
                        return AnalogicTagBox;
                }
            }
            throw new NotImplementedException();
        }
    }
}
