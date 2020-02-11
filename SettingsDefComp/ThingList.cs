using System;
using System.Text;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public StringBuilder configBuilder = new StringBuilder("00");
        public string configID;
        public bool config = false;
        public bool live = true;
        

        public ThingProp_Label labelProp = new ThingProp_Label();
        public ThingProp_Cost costProp = new ThingProp_Cost();
        public ThingProp_BaseHP baseHPProp = new ThingProp_BaseHP();

        public void CheckConfig() 
        {
            configBuilder[0] = costProp.config;
            configBuilder[1] = baseHPProp.config;
            configID = configBuilder.ToString();
            if (configID.Contains("1"))
            {
                config = true;
            }
            else
            {
                config = false;
            }
        }

        public void CheckSaved() 
        {
            if (costProp.draw && costProp.load)
            {
                costProp.Preset(defName);
            }
            if (baseHPProp.draw && baseHPProp.load)
            {
                baseHPProp.Preset(defName);
            }
            CheckConfig();
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref configID, "configID");
            costProp.ExposeData();
            baseHPProp.ExposeData();
        }
    }
}
