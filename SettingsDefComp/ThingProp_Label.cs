using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Label : ThingPropBase
    {
        public void Widget(string defName, float x, float y, float width)
        {
            if (load && draw)
            {
                label = ThingDef.Named(defName).label;
                load = false;
            }
            if (!load && draw)
            {
                Widgets.Label(new Rect(x, y, width, 22f), label);
            }
        }
    }
}
