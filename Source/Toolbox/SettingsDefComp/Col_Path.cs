using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Path : ColPropBase
{
    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Path";
            headerPos = 5f;
            this.width = 40f;
            min = 0f;
            max = 9999f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        if (thing.pathProp.load && draw)
        {
            thing.pathProp.Preset(thing.defName);
        }

        if (thing.pathProp.load || !draw)
        {
            return;
        }

        Widgets.TextFieldNumeric(
            new Rect(x, (24f * line) + vertLine, width, 22f),
            ref thing.pathProp.numInt,
            ref thing.pathProp.numBuffer,
            min, max);
        thing.pathProp.CheckConfig();
        ThingDef.Named(thing.defName).pathCost = thing.pathProp.numInt;
    }
}