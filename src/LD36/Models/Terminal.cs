using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD36.Models
{
    static class Terminal
    {
        public static int MaxCharsPerLine = 72;

        public static IEnumerable<string> Lines => _lines;

        private static List<string> _lines = new List<string>();

        public static void Clear()
        {
            _lines.Clear();
        }

        public static void Write(string line)
        {
            if (line.Length > 72)
            {
                var idx = 72;
                while (line[idx] != ' ')
                    idx--;

                _lines.Add(line.Substring(0, idx));
                Write(line.Substring(idx + 1));
            }
            else
            {
                _lines.Add(line);
            }
        }
    }
}
