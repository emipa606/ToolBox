using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_BaseHP : ThingPropBase
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "baseHP");
        }

        public void Preset(string defName) 
        {
            //The numIntdefault and numInt that gets the thingDef value, retrives a rounded off value.
            //See if you can find the needed calculations to fix it.
            if (numIntDefault.Count < 2)
            {
                numIntDefault[0] = ThingDef.Named(defName).BaseMaxHitPoints;
            }
            else
            {
                numIntDefault[0] = numIntDefault[1];
            }
            numInt = ThingDef.Named(defName).BaseMaxHitPoints;
            numBuffer = numInt.ToString();
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
            load = false;
        }

        public void Widget(string defName, float x, float y, float width, float min, float max)
        {
            if (load && draw)
            {
                this.defName = defName;
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
                
                ThingDef.Named(defName).SetStatBaseValue(StatDefOf.MaxHitPoints, numInt);
            }
        }
    }
}
