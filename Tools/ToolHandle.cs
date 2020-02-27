using System;
using System.Collections.Generic;
using ToolBox.SettingsDefComp;
using UnityEngine;

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

        //Try and figure out a way to make it adapt!
        //Ref. 6 - 120 = -114
        //     x -  y  = -114
        //Given: 24f
        /// <summary>
        /// num = (x * -1) % 24
        /// final = 24 - num
        /// </summary>
        /// <param name="num"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static float SetLine(ref float num, int index)
        {
            if (num <= 0 && index > 0)
            {
                return num = 24f;
            }
            if (num > 0 && index >= 1)
            {
                return num += 24f;
            }
            return num;
        }

        /// <summary>
        /// width is always higher than margin x2
        /// width - leftMargin * 2 = Y
        /// Y > x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static Rect SetWrapedRect(float x, float y, float width, float height, Textbox textBox) 
        {
            if (x < 0f) { x = 0f; }
            if (y < 0f) { y = 0f; }
            if (textBox.width > textBox.leftMargin * 2f)
            {
                if ((Math.Abs(textBox.width - x) - textBox.leftMargin < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.width - x - textBox.leftMargin);
                }
            }

            return new Rect();
        }
    }
}
