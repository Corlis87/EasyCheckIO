using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._03_Models
{
    public class EventLogData


    {
        [SugarColumn(IsPrimaryKey = true)]
        public int id { get; set; }
        public string Timestamp { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string RenderedMessage { get; set; }
        public string Properties { get; set; }
    }
}
