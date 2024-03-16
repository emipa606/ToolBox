using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Textbox_Line : ContentBase
{
    public readonly float length = 0f;
    public readonly LineType lineType = LineType.Horizontal;

    public void Content(Textbox textBox)
    {
        if (lineType == LineType.Horizontal)
        {
            Widgets.DrawLineHorizontal(
                textBox.x + textBox.leftMargin + x,
                textBox.y + textBox.topMargin + y,
                ToolHandle.SetWrapedRect(x, y, width, length, textBox).width);
        }
        else
        {
            Widgets.DrawLineVertical(
                textBox.x + textBox.leftMargin + x,
                textBox.y + textBox.topMargin + y,
                ToolHandle.SetWrapedRect(x, y, width, length, textBox).height);
        }
    }
}