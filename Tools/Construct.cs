using UnityEngine;
using Verse;

namespace ToolBox.Tools
{
    public static class Construct
    {
        public static void UnderlinedLabel(float x, float y, float width, float labelPos, string label)
        {
            Widgets.DrawLine(new Vector2(x, y + 20f), new Vector2(x + width, y + 20f), new Color(105f, 105f, 105f, 0.5f), 1f);
            Widgets.Label(new Rect(x + labelPos, y, width - labelPos, 22f), label);
        }
    }
}
