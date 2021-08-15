using System;
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
    }
}