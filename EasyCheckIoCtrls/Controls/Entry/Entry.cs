using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCtrls.Controls
{
    public class Entry:GraphicsView
    {


        public Entry()
        {
            HeightRequest = 48;
            WidthRequest = 120;

            Drawable = ButtonDrawable = new EntryDrawable();


        }

        public EntryDrawable ButtonDrawable { get; set; }


    }
}
