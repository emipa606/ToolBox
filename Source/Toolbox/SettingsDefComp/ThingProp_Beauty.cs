using System;
using RimWorld;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Beauty : ThingPropInput
    {
        /// <summary>
        ///     Default beauty is incremented to 1 to fit with the input numbers.
        ///     Original values from startup and live changes will follow the value rule of ToolBox
        ///     instead of the Rimworld default (XMLval - 1 = beauty).
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "beauty");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
                if (numIntDefault.Count == 3)
                {
                    numInt = numIntDefault[2];
                }
            }
            else
            {
                numInt = numIntDefault[0] =
                    Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
            }

            base.Preset(defName);
        }
    }
}