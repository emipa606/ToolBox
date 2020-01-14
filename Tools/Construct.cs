using System.Collections.Generic;
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

        public static void LabelCol(float x, float y, float width, IEnumerable<string> list, bool hasHeader = true, float headerPos = 0f, string headerLabel = "Null")
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
                //This is my best attempt in trying to increment the y axis inside the index.
                line += 24f + (label.Length - label.Length); 
            }
        }
    }
}
