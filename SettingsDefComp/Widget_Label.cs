using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Widget_Label
    {
        public bool exists;
        public bool drawLabel;
        public string label;

        /*Has a problem with getting exists bool
        public Widget_Label(bool exists)
        {
            this.exists = exists;
        }
        */

            /*
        public void LabelWidget(float x, float y, float width)
        {
            if (label != null && drawLabel && exists)
            {
                Widgets.Label(new Rect(x, y, width, 22f), label);
            }
        }*/
    }
}
