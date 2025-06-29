using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Fill : ColPropBase
{
    private new readonly float max = 100f;
    private new readonly float min = 0f;

    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Fill";
            headerPos = 6.6f;
            this.width = 31f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        if (thing.fillProp.load && draw)
        {
            thing.fillProp.Preset(thing.defName);
        }

        if (thing.fillProp.load || !draw)
        {
            return;
        }

        Widgets.TextFieldNumeric(
            new Rect(x, (24f * line) + vertLine, width, 22f),
            ref thing.fillProp.numInt,
            ref thing.fillProp.numBuffer,
            min, max);
        thing.fillProp.CheckConfig();
        ThingDef.Named(thing.defName).fillPercent = thing.fillProp.numInt / 100f;
    }
}