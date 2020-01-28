using System.Collections.Generic;
using System.Linq;
using ToolBox.Settings;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public string label;
        public int cost;
        public string costBuffer;
        public bool config = false;
        public bool costConfig = false;

        public void InitData()
        {
            label = ThingDef.Named(defName).label;
            cost = ThingDef.Named(defName).costStuffCount;
            Log.Error($"{label} - cost: {cost}");
        }

        public void ExposeData()
        {
            //Possibly save the config bool to find if it is already configured. 
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref cost, "cost");
        }

        public void DataCheck() 
        {
            costConfig = cost != ThingDef.Named(defName).costStuffCount;
            config = costConfig;
        }

        public void LabelWidget(float x, float y, float width) 
        {
            if (label != null && width != 0)
            {
                Widgets.Label(new Rect(x, y, width, 22f), label);
            }
        }

        public void CostWidget(float x, float y, float width, float min, float max) 
        {
            if (width != 0)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref cost, ref costBuffer, min, max);
            }
        }
    }
}
