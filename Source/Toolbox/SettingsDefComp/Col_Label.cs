using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Label : ColPropBase
{
    public void Widget(ThingProp thing, int line)
    {
        if (thing.labelProp.load && draw)
        {
            thing.labelProp.label = !thing.label.NullOrEmpty() ? thing.label : ThingDef.Named(thing.defName).label;

            thing.labelProp.load = false;
        }

        if (!thing.labelProp.load && draw)
        {
            Widgets.Label(new Rect(x, (24f * line) + vertLine, width, 22f), thing.labelProp.label);
        }
    }
}