using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public bool exists = true;
        public string label;
        public int cost;
        public int defaultCost;
        public string costBuffer;
        public bool config = false;
        public bool costConfig = false;

        public void InitData()//On settings open.
        {
            if (exists)
            {
                label = ThingDef.Named(defName).label;
                cost = ThingDef.Named(defName).costStuffCount;
                //Log.Error($"{label} - cost: {cost} - Default: {defaultCost}");
            }
            else 
            {
                Log.Error($"[ToolBox : OOF] Missing ThingDef \"{defName}\" has been skipped over!");
            };
        }

        public void ExposeData()
        {
            //Possibly save default cost to compare if it requires config to be true.
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref cost, "cost");
        }

        public void DataCheck()//On settings close. 
        {
            if (exists)
            {
                costConfig = cost != defaultCost;
                if (costConfig)
                {
                    config = true;
                }
                else
                {
                    config = false;
                }
                //Log.Error(config.ToString());
            }
        }

        public void LabelWidget(bool draw, float x, float y, float width) 
        {
            if (label != null && draw && exists)
            {
                Widgets.Label(new Rect(x, y, width, 22f), label);
            }
        }

        public void CostWidget(bool draw, float x, float y, float width, float min, float max) 
        {
            if (draw && exists)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref cost, ref costBuffer, min, max);
            }
        }
    }
}
