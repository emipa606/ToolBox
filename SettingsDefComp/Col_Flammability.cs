﻿using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Flammability : ColPropBase
    {
        public new float min = 0f;
        public new float max = 100f;

        public override void Header()
        {
            if (drawDefault)
            {
                header = "Burn";
                headerPos = 0.5f;
                width = 31f;
            }
            base.Header();
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
