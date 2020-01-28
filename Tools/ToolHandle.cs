using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolBox.Tools
{
    public static class ToolHandle
    {
        public static IList<int> SetIndexCount(int maxNum)
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

        public static float SetLine(ref float num, int index)
        {
            if (num == 0 && index == 1)
            {
                return num = 24;
            }
            else if (num > 0 && index >= 1)
            {
                return num += 24;
            }
            return num;
        }
    }
}
