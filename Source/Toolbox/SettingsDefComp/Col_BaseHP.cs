using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_BaseHP : ColPropBase
    {
        public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if (drawDefault)
            {
                header = "BaseHP";
                headerPos = 2.2f;
                this.width = 56f;
                min = 1f;
                max = 999999f;
            }

            base.SetSize(thingCount, width, height, multiplier);
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.baseHPProp.load && draw)
            {
                thing.baseHPProp.Preset(thing.defName);
            }

            if (thing.baseHPProp.load || !draw)
            {
                return;
            }

            Widgets.TextFieldNumeric(
                new Rect(x, (24f * line) + vertLine, width, 22f),
                ref thing.baseHPProp.numInt,
                ref thing.baseHPProp.numBuffer,
                min, max);
            thing.baseHPProp.CheckConfig();
            ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.MaxHitPoints, thing.baseHPProp.numInt);
        }
    }
}