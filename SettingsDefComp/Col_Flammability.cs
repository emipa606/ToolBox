using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Flammability : ColPropBase
    {
        public new float min = 0f;
        public new float max = 100f;

        public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if (drawDefault)
            {
                //Replace burn with Flammability
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
            if (!thing.flammabilityProp.load && draw)
            {
                Widgets.TextFieldNumeric(
                    new Rect(x, (24f * line) + vertLine, width, 22f),
                    ref thing.flammabilityProp.numInt,
                    ref thing.flammabilityProp.numBuffer,
                    min, max);
                thing.flammabilityProp.CheckConfig();
                ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.Flammability, thing.flammabilityProp.numInt / 100f);
            }
        }
    }
}
