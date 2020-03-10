using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Label : ColPropBase
    {
        public void Widget(ThingProp thing, int line)
        {
            if (thing.labelProp.load && draw)
            {
                if (!thing.label.NullOrEmpty())
                {
                    thing.labelProp.label = thing.label;
                }
                else
                {
                    thing.labelProp.label = ThingDef.Named(thing.defName).label;
                }
                thing.labelProp.load = false;
            }
            if (!thing.labelProp.load && draw)
            {
                Widgets.Label(new Rect(x, (24f * line) + vertLine, width, 22f), thing.labelProp.label);
            }
        }
    }
}
