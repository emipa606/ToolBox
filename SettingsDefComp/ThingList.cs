using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public bool exists = true;

        public Widget_Label labelWidget = new Widget_Label();

        public bool drawLabel;
        public bool drawCost;
        public bool drawBaseHP;
        public bool drawBeauty;

        public string label;
        public int cost;
        public int baseHP;
        public int beauty;

        public string costBuffer;
        public string baseHPBuffer;
        public string beautyBuffer;

        public int defaultCost;
        public int defaultBaseHP;
        public int defaultBeauty;

        public bool config = false;
        public bool costConfig = false;
        public bool baseHPConfig = false;
        public bool beautyConfig = false;

        public void BaseValue()//On settings open.
        {
            if (exists)
            {
                Log.Error("This should occur mutiple times!");
                //ToDo:
                //bool draw[prop] If-statement defaults the value to the Col's default, usually 1.
                //It requires too much process to do finish all checks, so I'm leaving this
                //open for future fix.
                label = ThingDef.Named(defName).label;
                cost = ThingDef.Named(defName).costStuffCount;
                baseHP = ThingDef.Named(defName).BaseMaxHitPoints;
                if (defaultBeauty == Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty)))
                {
                    beauty = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
                }
                else
                {
                    beauty = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty) - 1);
                }
            }
            else 
            {
                Log.Error($"[ToolBox : OOF] Missing ThingDef \"{defName}\" has been skipped over!");
            }
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref cost, "cost");
            Scribe_Values.Look(ref baseHP, "baseHP");
            Scribe_Values.Look(ref beauty, "beauty");
        }

        public void DataCheck()//On settings close. 
        {
            if (exists)
            {
                costConfig = (cost != defaultCost) && drawCost;
                baseHPConfig = (baseHP != defaultBaseHP) && drawBaseHP;
                beautyConfig = (beauty != defaultBeauty) && drawBeauty;
                if (costConfig || baseHPConfig || beautyConfig)
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

        public void LabelWidget(float x, float y, float width)
        {
            if (label != null && drawLabel && exists)
            {
                Widgets.Label(new Rect(x, y, width, 22f), label);
            }
        }

        public void CostWidget(float x, float y, float width, float min, float max) 
        {
            if (drawCost && exists)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref cost, ref costBuffer, min, max);
            }
        }

        public void BaseHPWidget(float x, float y, float width, float min, float max) 
        {
            if (drawBaseHP && exists)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref baseHP, ref baseHPBuffer, min, max);
            }
        }

        public void BeautyWidget(float x, float y, float width, float min, float max) 
        {
            if (drawBeauty && exists)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref beauty, ref beautyBuffer, min, max);
            }
        }
    }
}
