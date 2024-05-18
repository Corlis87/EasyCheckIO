using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoUI.TextGraphList
{
    public class TextGraphManager
    {
        public List<TextGraphEntries> Entries { get; }

        public bool IsEnum { get; }
        public TextGraphManager(bool isEnum)
        {
            IsEnum = isEnum;
            Entries = new List<TextGraphEntries>();
        }

        public int GetIndexFromString(string value)
        {
            foreach (var item in Entries)
            {
                if (item.Message == value)
                    return item.Start;
            }
            throw new ArgumentNullException(nameof(TextGraph));
        }
        public object GetIndexFromEnum(string value, Type t = null)
        {
            foreach (var item in Entries)
            {
                if (item.Message == value)
                    return Enum.ToObject(t, item.Start);
            }
            throw new ArgumentException(nameof(TextGraph));
        }
        public string GetMessage(int value)
        {
            foreach (var item in Entries)
            {
                if (item.End == null && value == item.Start)
                    return item.Message;
                else if (value >= item.Start && value <= item.End && item.End != null)
                    return item.Message;
            }
            throw new ArgumentNullException(nameof(TextGraph));
        }
        public string[] GetStrings()
        {
            var list = new string[Entries.Count];
            for (int i = 0; i < Entries.Count; i++)
            {
                list[i] = Entries[i].Message;
            }
            return list;
        }
    }

}
