using System;
using RimWorld;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_WorkToBuild : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "WorkToBuild");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.WorkToBuild));
            }
            else
            {
                numInt = numIntDefault[0] =
                    Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.WorkToBuild));
            }

            base.Preset(defName);
        }
    }
}