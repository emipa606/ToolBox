using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Cost : ThingPropBase
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numInt, "numInt");
        }

        public void Preset(string defName) 
        {
            //Just preload  the config tbh
            if (numIntDefault.Count < 2)
            {
                numIntDefault[0] = ThingDef.Named(defName).costStuffCount;
            }
            else
            {
                numIntDefault[0] = numIntDefault[1];
            }
            numInt = ThingDef.Named(defName).costStuffCount;
            numBuffer = numInt.ToString();
            if (numInt != numIntDefault[0])
            {
                config = true;
            }
            else
            {
                config = false;
            }
            load = false;
        }

        public void Widget(string defName, float x, float y, float width, float min, float max)
        {
            if (load && draw)
            {
                Log.Error("This was loaded on Widget!");
                this.defName = defName;
                Preset(defName);
            }
            if (!load && draw)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref numInt, ref numBuffer, min, max);
                if (numInt != numIntDefault[0]) 
                {
                    config = true;
                }
                else
                {
                    config = false;
                }
            }
        }

        public void PostLoad() 
        {
            if (config)
            {
                ThingDef.Named(defName).costStuffCount = numInt;
            }
        }
    }
}
