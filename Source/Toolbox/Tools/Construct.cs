using UnityEngine;
using Verse;

namespace ToolBox.Tools;

public static class Construct
{
    /// <summary>
    ///     Creates a Label that has an underline. It acts as a label Widget in a way.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="labelPos"></param>
    /// <param name="label"></param>
    public static void UnderlinedLabel(float x, float y, float width, float labelPos, string label)
    {
        Widgets.DrawLine(new Vector2(x, y + 20f), new Vector2(x + width, y + 20f),
            new Color(105f, 105f, 105f, 0.5f), 1f);
        Widgets.Label(new Rect(x + labelPos, y, width - labelPos, 22f), label);
    }
}