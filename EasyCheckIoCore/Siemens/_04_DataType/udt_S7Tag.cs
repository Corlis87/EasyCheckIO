using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Siemens._04_DataType
{
    public struct udt_S7Tag
    {
        public S7Area Area;
        public int DBNumber;
        public int Start;
        public int Elements;
        public S7WordLength WordLen;

        #region ctr
        public udt_S7Tag(S7Area area, int dbNumber, int start, int elements, S7WordLength wordLen)
        {
            Area = area;
            DBNumber = dbNumber;
            Start = start;
            Elements = elements;
            WordLen = wordLen;
        }

        #endregion
    }
}
