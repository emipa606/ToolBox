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
            Rect box = new Rect(x, y, width, 22f);
            Widgets.Label(box, label);
        }

        public static void UnderlinedLabel(float x, float y, float width, float labelPos, string label)
        {
            Color color = new Color(105f, 105f, 105f, 0.5f);
            Vector2 vectTop = new Vector2(x, y + 20f);
            Vector2 vectBottom = new Vector2(x + width, y + 20f);
            Rect rect = new Rect(x + labelPos, y, width - labelPos, 22f);
            Widgets.DrawLine(vectTop, vectBottom, color, 1f);
            Widgets.Label(rect, label);
        }

        public static void InputField(float x, float y, float width, int variable, string buffer, int length = 9, int valLimit = 999999999)
        {
            buffer = variable.ToString();
            variable = ToolHandle.Sort(Widgets.TextField(new Rect(x, y, width, 22f), buffer), length, valLimit);
        }

        public static void InputField(float x, float y, float width, string variable, string buffer, int length = 9)
        {
            buffer = variable;
            variable = ToolHandle.Sort(Widgets.TextField(new Rect(x, y, width, 22f), buffer), 9);
        }

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
            IList<string> buffers = new List<string>();
            foreach (int index in indexList)   
            {
                ToolHandle.SetBuffer(buffers, variable, index);
                variable[index] = ToolHandle.Sort(Widgets.TextField(new Rect(x, line, width, 22f), buffers[index]), length, valLimit);
                line += 24 + (index - index);
            }
        }
    }
}
