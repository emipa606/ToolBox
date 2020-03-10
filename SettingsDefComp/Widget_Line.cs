using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Widget_Line : DesignBase
    {
        public LineType lineType = LineType.Horizontal;
        public float length = 0f;

        public virtual void Widget()
        {
            if (length > 0f)
            {
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
    }
}
