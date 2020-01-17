using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Verse;

namespace ToolBox.Tools
{
    public static class Construct
    {
        public static void Label(float x, float y, float width, string label)
        {
            Widgets.Label(new Rect(x, y, width, 22f), label);
        }

        public static void Label(float x, float y, float width, IList<string> label, int index)
        {
            Widgets.Label(new Rect(x, y, width, 22f), label[index]);
        }

        public static void UnderlinedLabel(float x, float y, float width, float labelPos, string label)
        {
            Widgets.DrawLine(new Vector2(x, y + 20f), new Vector2(x + width, y + 20f), new Color(105f, 105f, 105f, 0.5f), 1f);
            Widgets.Label(new Rect(x + labelPos, y, width - labelPos, 22f), label);
        }

        public static void InputField(float x, float y, float width, int variable, string buffer, int length = 9, int valLimit = 999999999)
        {
            buffer = variable.ToString();
            variable = ToolHandle.ValLimit(Widgets.TextField(new Rect(x, y, width, 22f), buffer, length, new Regex("^[0-9]+$")), valLimit);
        }

        public static void InputField(float x, float y, float width, IList<int> variable, IList<string> buffer, int length = 9, int valLimit = 999999999, int index = 0)
        {
            buffer[index] = variable[index].ToString();
            variable[index] = ToolHandle.ValLimit(Widgets.TextField(new Rect(x, y, width, 22f), buffer[index], length, new Regex("^[0-9]+$")), valLimit);
        }

        //Have not tested so is currently disabled.
        /*
        public static void InputField(float x, float y, float width, string variable, string buffer, int length = 9)
        {
            buffer = variable;
            variable = Widgets.TextField(new Rect(x, y, width, 22f), buffer, length, new Regex("",RegexOptions.None));
        }
        */

        //Below is disabled due to it being bad for performance. No record of how bad tho.
        //I'll re-enable if there are requests or modifications that can make it better.
        /*
        public static void LabelCol(float x, float y, float width, IEnumerable<string> list, bool hasHeader = true, float headerPos = 0f, string headerLabel = "null")
        {
            float line = y;
            if (hasHeader) 
            {
                UnderlinedLabel(x, y, width, headerPos, headerLabel);
                line += 24f;
            }
            foreach (string label in list)
            {
                Label(x,line,width, label);
                float con = label.Length;
                line += 24f + (con - con);
            }
        }
        
        public static void InputCol(float x, float y, float width, IList<int> variable, IList<string> buffer, int length = 9, int valLimit = 999999999, bool hasHeader = true, float headerPos = 0f, string headerLabel = "null") 
        {
            float line = y;
            if (hasHeader)
            {
                UnderlinedLabel(x, line, width, headerPos, headerLabel);
                line += 24f;
            }
            IEnumerable<int> indexList = ToolHandle.SetCount(variable.Count);
            foreach (int index in indexList)   
            {
                variable[index] = ToolHandle.Sort(Widgets.TextField(new Rect(x, line, width, 22f), buffer[index]), length, valLimit);
                line += 24 + (index - index);
            }
        }
        */
    }
}
