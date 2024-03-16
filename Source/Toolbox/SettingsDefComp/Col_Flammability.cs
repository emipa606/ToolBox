using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Flammability : ColPropBase
{
    public new readonly float max = 100f;
    public new readonly float min = 0f;

    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Flammability";
            headerPos = 2.2f;
            this.width = 85f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        if (thing.flammabilityProp.load && draw)
        {
            thing.flammabilityProp.Preset(thing.defName);
        }

        if (thing.flammabilityProp.load || !draw)
        {
            return;
        }

        Widgets.TextFieldNumeric(
            new Rect(x, (24f * line) + vertLine, width, 22f),
            ref thing.flammabilityProp.numInt,
            ref thing.flammabilityProp.numBuffer,
            min, max);
        thing.flammabilityProp.CheckConfig();
        ThingDef.Named(thing.defName)
            .SetStatBaseValue(StatDefOf.Flammability, thing.flammabilityProp.numInt / 100f);
    }
}