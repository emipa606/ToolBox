using System;
using System.Collections.Generic;
using ToolBox.SettingsDefComp;
using UnityEngine;
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

        public static Rect SetWrapedRect(ContentBase contentBase, Textbox textBox, bool warn = false) 
        {
            //Sets axis and textBox margin to 0f to avoid positive difference/answers
            if (contentBase.x < 0f) { contentBase.x = 0f; }
            if (contentBase.y < 0f) { contentBase.y = 0f; }
            if (textBox.leftMargin < 0f) { textBox.leftMargin = 0f; }
            if (textBox.topMargin < 0f) { textBox.topMargin = 0f; }

            if ((textBox.width - (textBox.leftMargin * 2f) - contentBase.x < contentBase.width) || (contentBase.width <= 0f))
            {
                if ((textBox.width - (textBox.leftMargin * 2f) - contentBase.x < contentBase.width) && warn)
                {
                    Log.Error("");
                }
                contentBase.width = textBox.width - (textBox.leftMargin * 2f) - contentBase.x;
            }
            if ((textBox.height - (textBox.topMargin * 2f) - contentBase.y < contentBase.height) || (contentBase.height <= 0f))
            {
                contentBase.height = textBox.height - (textBox.topMargin * 2f) - contentBase.y;
            }

            return new Rect(
                textBox.x + textBox.leftMargin + contentBase.x,
                textBox.y + textBox.topMargin + contentBase.y,
                contentBase.width, contentBase.height);
        }
    }
}
