using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Beauty : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "beauty");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count < 2)
            {
                numIntDefault[0] = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
            }
            else
            {
                numIntDefault[0] = numIntDefault[1];
            }
            numInt = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
            base.Preset(defName);
        }

        public void Widget(string defName, float x, float y, float width, float min, float max)
        {
            if (load && draw)
            {
                Preset(defName);
            }
            if (!load && draw)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref numInt, ref numBuffer, min, max);
                if (numInt != numIntDefault[0])
                {
                    config = '1';
                    numSavedInt = numInt;
                }
                else
                {
                    config = '0';
                    numSavedInt = 0;
                }

                //This requires a fix with the value. 3 and above value stays the same unless added more than 1.
                ThingDef.Named(defName).SetStatBaseValue(StatDefOf.Beauty, numInt + 1);
            }
        }
    }
}
