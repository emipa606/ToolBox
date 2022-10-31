using Verse;

namespace ToolBox.SettingsDefComp;

public class Widget_Line : DesignBase
{
    public float length = 0f;
    public LineType lineType = LineType.Horizontal;

    public virtual void Widget()
    {
        if (!(length > 0f))
        {
            return;
        }

        if (lineType == LineType.Horizontal)
        {
            Widgets.DrawLineHorizontal(x, y, length);
        }
        else
        {
            Widgets.DrawLineVertical(x, y, length);
        }
    }
}