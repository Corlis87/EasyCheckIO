using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TiaFrameworkCore.Siemens._03_DataBlock
{
    public class S7DB
    {
        public List<S7Tag> Tags { get; set; }

        public S7NetConfig NetConfig { get; set; }

        public S7DB()
        {
            Tags = new List<S7Tag>();
            NetConfig = new S7NetConfig();
        }
    }
}
