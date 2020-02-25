using UnityEngine;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace ToolBox.SettingsDefComp
{
    public class Col_WorkToBuild : ColPropBase
    {
        public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if (drawDefault)
            {
                header = "Work";
                headerPos = 3.5f;
                this.width = 40f;
                min = 0f;
                max = 9999f;
            }
            base.SetSize(thingCount, width, height, multiplier);
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.workProp.load && draw)
            {
                thing.workProp.Preset(thing.defName);
            }
            if (!thing.workProp.load && draw)
            {
                Widgets.TextFieldNumeric(
                    new Rect(x, (24f * line) + vertLine, width, 22f), 
                    ref thing.workProp.numInt, 
                    ref thing.workProp.numBuffer, 
                    min, max);
                thing.workProp.CheckConfig();
                ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.WorkToBuild, thing.workProp.numInt);
            }
        }
    }
}
