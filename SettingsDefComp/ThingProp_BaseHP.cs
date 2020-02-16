using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_BaseHP : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "baseHP");
        }

        public override void Preset(string defName) 
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = ThingDef.Named(defName).BaseMaxHitPoints;
                if (numIntDefault.Count == 3)
                {
                    numInt = numIntDefault[2];
                }
            }
            else
            {
                numInt = numIntDefault[0] = ThingDef.Named(defName).BaseMaxHitPoints;
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
                if (numInt == numIntDefault[0]) 
                {
                    config = '0';
                    numSavedInt = 0;
                }
                else
                {
                    config = '1';
                    numSavedInt = numInt;
                }
                ThingDef.Named(defName).SetStatBaseValue(StatDefOf.MaxHitPoints, numInt);
            }
        }
    }
}
