using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.Excel._03_DataBlock
{
    public class ExcelDB


    {
        private List<S7Tag> _Tags;

        public List<S7Tag> Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }
        public ExcelDB()
        {
            Tags = new List<S7Tag>();
        }
    }
}
