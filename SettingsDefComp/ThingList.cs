using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public bool exists = true;
        public string label;

        public bool drawCost;
        public bool drawBaseHP;

        public int cost;
        public int baseHP;

        public string costBuffer;
        public string baseHPBuffer;

        public int defaultCost;
        public int defaultBaseHP;

        public bool config = false;
        public bool costConfig = false;
        public bool baseHPConfig = false;

        public void InitData()//On settings open.
        {
            if (exists)
            {
                //Variable is still given value even if not drawn. It gives default of 1,
                //which is not the default of the ThingDef.
                label = ThingDef.Named(defName).label;
                cost = ThingDef.Named(defName).costStuffCount;
                baseHP = ThingDef.Named(defName).BaseMaxHitPoints;
                //Log.Error($"{label} - cost: {cost} - Default: {defaultCost}");
            }
            else 
            {
                Log.Error($"[ToolBox : OOF] Missing ThingDef \"{defName}\" has been skipped over!");
            }
        }

        public void ExposeData()
        {
            //Possibly save default cost to compare if it requires config to be true.
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref cost, "cost");
            Scribe_Values.Look(ref baseHP, "baseHP");
        }

        public void DataCheck()//On settings close. 
        {
            if (exists)
            {
                //Config becomes true because the non-drawn inputs default into value of 1,
                //which is not equal to the default value of it.
                costConfig = cost != defaultCost;
                baseHPConfig = baseHP != defaultBaseHP;
                if (costConfig || baseHPConfig)
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

        public void BaseHPWidget(bool draw, float x, float y, float width, float min, float max) 
        {
            if (draw && exists)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref baseHP, ref baseHPBuffer, min, max);
            }
        }
    }
}
