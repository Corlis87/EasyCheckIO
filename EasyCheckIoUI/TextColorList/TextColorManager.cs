using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoUI.TextGraphList
{
    public class TextColorManager
    {
        public List<TextColorEntries> Entries { get; }

        public bool IsEnum { get; }
        public TextColorManager(bool isEnum)
        {
            IsEnum = isEnum;
            Entries = new List<TextColorEntries>();
        }

        public int GetIndexFromString(Color value)
        {
            foreach (var item in Entries)
            {
                if (item.Color == value)
                    return item.Start;
            }
            throw new ArgumentNullException(nameof(TextColor));
        }
        public object GetIndexFromEnum(Color value, Type t = null)
        {
            foreach (var item in Entries)
            {
                if (item.Color == value)
                    return Enum.ToObject(t, item.Start);
            }
            throw new ArgumentException(nameof(TextColor));
        }
        public Color GetMessage(int value)
        {
            foreach (var item in Entries)
            {
                if (item.End == null && value == item.Start)
                    return item.Color;
                else if (value >= item.Start && value <= item.End && item.End != null)
                    return item.Color;
            }
            throw new ArgumentNullException(nameof(TextColor));
        }
        public Color[] GetStrings()
        {
            var list = new Color[Entries.Count];
            for (int i = 0; i < Entries.Count; i++)
            {
                list[i] = Entries[i].Color;
            }
            return list;
        }
    }

}
