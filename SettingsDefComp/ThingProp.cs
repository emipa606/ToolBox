using System;
using System.Text;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp : IExposable
    {
        public string defName;
        public int pos = 0;
        public StringBuilder configBuilder = new StringBuilder("00000000"); //Increase the 0s for every new Prop.
        public string configID;
        public bool config = false;
        public bool live = true;
        
        //Input type ThingProps
        public ThingProp_Label labelProp = new ThingProp_Label();
        public ThingProp_Cost costProp = new ThingProp_Cost();
        public ThingProp_BaseHP baseHPProp = new ThingProp_BaseHP();
        public ThingProp_Beauty beautyProp = new ThingProp_Beauty();
        public ThingProp_Fill fillProp = new ThingProp_Fill();
        public ThingProp_Path pathProp = new ThingProp_Path();
        public ThingProp_WorkToBuild workProp = new ThingProp_WorkToBuild();
        public ThingProp_Flammability flammabilityProp = new ThingProp_Flammability();

        //Select type ThingProps
        public ThingProp_Passability passabilityProp = new ThingProp_Passability();

        public void LiveCheck() 
        {
            try
            {
                if (live)
                {
                    string test = ThingDef.Named(defName).defName;
                }
            }
            catch (NullReferenceException)
            {
                live = false;
            }
        }

        public void CheckConfig() 
        {
            configBuilder[0] = costProp.config;
            configBuilder[1] = baseHPProp.config;
            configBuilder[2] = beautyProp.config;
            configBuilder[3] = fillProp.config;
            configBuilder[4] = pathProp.config;
            configBuilder[5] = workProp.config;
            configBuilder[6] = flammabilityProp.config;
            configBuilder[7] = passabilityProp.config;
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
            if ((costProp.numIntDefault.Count > 1) && costProp.load)
            {
                costProp.Preset(defName);
            }
            if ((baseHPProp.numIntDefault.Count > 1) && baseHPProp.load)
            {
                baseHPProp.Preset(defName);
            }
            if ((beautyProp.numIntDefault.Count > 1) && beautyProp.load)
            {
                beautyProp.Preset(defName);
            }
            if ((fillProp.numIntDefault.Count > 1) && fillProp.load)
            {
                fillProp.Preset(defName);
            }
            if ((pathProp.numIntDefault.Count > 1) && pathProp.load)
            {
                pathProp.Preset(defName);
            }
            if ((workProp.numIntDefault.Count > 1) && workProp.load)
            {
                workProp.Preset(defName);
            }
            if ((flammabilityProp.numIntDefault.Count > 1) && flammabilityProp.load)
            {
                flammabilityProp.Preset(defName);
            }
            if ((passabilityProp.optionDefault.Count > 1) && passabilityProp.load)
            {
                passabilityProp.Preset(defName);
            }
            CheckConfig();
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref defName, "defName");
            Scribe_Values.Look(ref configID, "configID");
            costProp.ExposeData();
            baseHPProp.ExposeData();
            beautyProp.ExposeData();
            fillProp.ExposeData();
            pathProp.ExposeData();
            workProp.ExposeData();
            flammabilityProp.ExposeData();
            passabilityProp.ExposeData();
        }
    }
}
