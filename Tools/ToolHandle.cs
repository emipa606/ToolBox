using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolBox.Tools
{
    public static class ToolHandle
    {
        public static void SetIntBuffer(List<string> buffer, List<int> value, int index)
        {
            buffer.Add(value[index].ToString());
            buffer[index] = value[index].ToString();
        }

        private static char[] num = "0123456789".ToArray();
        private static char[] letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        private static char[] special = "`~!@#$%^&*()-_=+\\|]}[{'\";:/?.>,<".ToArray();
        public static int SortToInt(string input, int charCount = 9, int valLimit = 999999999)
        {
            int num = 0;
            if (input.Length > charCount)
            {
                input = input.Remove(charCount);
            }

            int newInput = 0;
            if (input.NullOrEmpty())
            {
                return Convert.ToInt32(newInput);
            }

            char[] checkerVal = letters.Concat(special).ToArray();
            num = Convert.ToInt32(input.Trim(checkerVal));
            if (num > valLimit)
            {
                num = valLimit;
            }
            return num;
        }

        public static void SetCount(int maxNum, List<int> list)
        {
            while (list.Count <= (maxNum - 1))
            {
                if (list.Count == 0)
                {
                    list.Add(0);
                }
                else
                {
                    list.Add(list.Count);
                }
            }
        }

    }
}
