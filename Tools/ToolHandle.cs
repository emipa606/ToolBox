using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolBox.Tools
{
    public static class ToolHandle
    {
        public static void SetBuffer(IList<string> buffer, IList<int> variable, int index)
        {
            buffer.Add(variable[index].ToString());
            buffer[index] = variable[index].ToString();
        }

        public static void SetBuffer(IList<string> buffer, IList<string> variable, int index)
        {
            buffer.Add(variable[index].ToString());
            buffer[index] = variable[index].ToString();
        }

        public static int ValLimit(string input, int valLimit = 999999999)
        {
            int num = Convert.ToInt32(input);
            if (num > valLimit)
            {
                num = valLimit;
            }
            return num;
        }

        public static int ValLimit(int input, int valLimit = 999999999)
        {
            int num = input;
            if (num > valLimit)
            {
                num = valLimit;
            }
            return num;
        }

        private static char[] num = "0123456789".ToArray();
        private static char[] letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        private static char[] special = "`~!@#$%^&*()-_=+\\|]}[{'\";:/?.>,<".ToArray();
        public static int Sort(string input, int length, int valLimit)
        {
            int num = 0;
            if (input.Length > length)
            {
                input = input.Remove(length);
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

        public static string Sort(string input, int length)
        {
            if (input.Length > length)
            {
                return input.Remove(length);
            }
            return input;
        }

        public static IList<int> SetCount(int maxNum)
        {
            IList<int> list = new List<int>();
            int num = 0;
            while (list.Count <= (maxNum - 1))
            {
                list.Add(num);
                num++;
            }
            return list;
        }
    }
}
