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
    }
}
