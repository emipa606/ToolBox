using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Beauty : ColPropBase
    {
        public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if (drawDefault)
            {
                header = "Beauty";
                headerPos = 2.2f;
                this.width = 48.5f;
                min = -9999f;
                max = 99999f;
            }
            base.SetSize(thingCount, width, height, multiplier);
        }

        /// <summary>
        /// Default beauty is incremented to 1 to fit with the input numbers.
        /// Original values from startup and live changes will follow the value rule of ToolBox
        /// instead of the Rimworld default (XMLval - 1 = beauty).
        /// </summary>
        public void Widget(ThingProp thing, int line)
        {
            if (thing.beautyProp.load && draw)
            {
                thing.beautyProp.Preset(thing.defName);
            }
            if (!thing.beautyProp.load && draw)
            {
                Widgets.TextFieldNumeric(
                    new Rect(x, (24f * line) + vertLine, width, 22f), 
                    ref thing.beautyProp.numInt, 
                    ref thing.beautyProp.numBuffer, 
                    min, max);
                thing.beautyProp.CheckConfig();
                ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.Beauty, thing.beautyProp.numInt + 1);
            }
        }
    }
}
