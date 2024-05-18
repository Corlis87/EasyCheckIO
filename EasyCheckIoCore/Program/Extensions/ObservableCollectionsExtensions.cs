using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._03_DataBlock;

namespace EasyCheckIoCore.Program.Extensions
{
    public class ObservableCollectionCarousel<T> : ObservableCollection<T>
    {
        public void ClearForCarousel()
        {
            if (this.Count >0)
                {
                for (int i = (this.Count-1); i > 0; i--)
                {
                    this.RemoveAt(i);
                }            
            }
        }
    }
}
