using System.Collections.Generic;
using ToolBox.SettingsDefComp;
using UnityEngine;

namespace ToolBox.Tools
{
    public static class ToolHandle
    {
        /// <summary>
        ///     Returns a list of numbers starting from 0 to the highest, based on the (int)maxNum.
        /// </summary>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static IList<int> SetIndexCount(int maxNum)
        {
            IList<int> list = new List<int>();
            var num = 0;
            while (list.Count <= maxNum - 1)
            {
                list.Add(num);
                num++;
            }

            return list;
        }

        /// <summary>
        ///     Returns a Rect that adapts and stays within its container.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static Rect SetWrapedRect(float x, float y, float width, float height, Textbox textBox)
        {
            //Sets axis and textBox margin to 0f to avoid positive difference/answers
            if (x < 0f)
            {
                x = 0f;
            }

            if (y < 0f)
            {
                y = 0f;
            }

            if (textBox.leftMargin < 0f)
            {
                textBox.leftMargin = 0f;
            }

            if (textBox.topMargin < 0f)
            {
                textBox.topMargin = 0f;
            }

            if (textBox.width - (textBox.leftMargin * 2f) - x < width || width <= 0f)
            {
                width = textBox.width - (textBox.leftMargin * 2f) - x;
            }

            if (textBox.height - (textBox.topMargin * 2f) - y < height || height <= 0f)
            {
                height = textBox.height - (textBox.topMargin * 2f) - y;
            }

            return new Rect(
                textBox.x + textBox.leftMargin + x,
                textBox.y + textBox.topMargin + y,
                width, height);
        }
    }
}