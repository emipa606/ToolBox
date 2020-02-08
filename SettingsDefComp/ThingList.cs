using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingList : IExposable
    {
        public string defName;
        public bool live = true;
        public bool config = false;

        public ThingProp_Label labelProp = new ThingProp_Label();
        public ThingProp_Cost costProp = new ThingProp_Cost();

        public void CheckConfig() 
        {
            //Log.Error("Status1: " + live.ToString());
            if (costProp.config)
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
            Log.Error("Status2: " + live.ToString());
            if (costProp.draw && costProp.load)
            {
                Log.Error("Non-opened settings were saved!");
                costProp.Preset(defName);
            }
            CheckConfig();
        }

        public void PostLoadCompile() 
        {
            Log.Error("Status3: " + live.ToString());
            if (config)
            {
                costProp.PostLoad();
            }
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Deep.Look(ref costProp, "costCol");
        }
    }
}
