using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkUI.Templates
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
                    case TiaFrameworkCore.Shared._06_Enum.eS7io.Input:
                    case TiaFrameworkCore.Shared._06_Enum.eS7io.Output:
                        return DigitalTagBox;
                    case TiaFrameworkCore.Shared._06_Enum.eS7io.AnalogicInput:
                    case TiaFrameworkCore.Shared._06_Enum.eS7io.AnalogicOutput:
                        return AnalogicTagBox;
                }
            }
            throw new NotImplementedException();
        }
    }
}
