using System;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Fill : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "fill");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = Convert.ToInt32(ThingDef.Named(defName).fillPercent * 100f);
            }
            else
            {
                numInt = numIntDefault[0] = Convert.ToInt32(ThingDef.Named(defName).fillPercent * 100f);
            }
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
                if ((numInt / 100f ) == numIntDefault[0])
                {
                    config = '0';
                    numSavedInt = 0;
                }
                else
                {
                    config = '1';
                    numSavedInt = numInt;
                }
                ThingDef.Named(defName).fillPercent = numInt / 100f;
            }
        }
    }
}
