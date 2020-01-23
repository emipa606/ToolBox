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

        public static void InputField(float x, float y, float width, int item, string buffer, int length = 9, int valLimit = 999999999)
        {
            buffer = item.ToString();
            item = ToolHandle.ValLimit(Widgets.TextField(new Rect(x, y, width, 22f), buffer, length, new Regex("^[0-9]+$")), valLimit);
        }

        public static void InputField(float x, float y, float width, IList<int> item, IList<string> buffer, int length = 9, int valLimit = 999999999, int index = 0)
        {
            buffer[index] = item[index].ToString();
            item[index] = ToolHandle.ValLimit(Widgets.TextField(new Rect(x, y, width, 22f), buffer[index], length, new Regex("^[0-9]+$")), valLimit);
        }

        //Have not tested so is currently disabled.
        /*
        public static void InputField(float x, float y, float width, string variable, string buffer, int length = 9)
        {
            buffer = variable;
            variable = Widgets.TextField(new Rect(x, y, width, 22f), buffer, length, new Regex("",RegexOptions.None));
        }
        */
    }
}
