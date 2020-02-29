using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Settings;
using ToolBox.SettingsDefComp;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUp
    {
        static StartUp()
        {
            //ThingProp list
            IEnumerable<ThingProp> thingProps = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.configurator
                .SelectMany(d => d.thingList));

            //Groups similar DefNames in ThingList and reports it.
            IEnumerable<string> sameDefName = thingProps
                .GroupBy(t => t.defName)
                .Where(d => d.Count() > 1)
                .Select(d => d.Key);
            foreach (string defName in sameDefName)
            {
                Log.Error($"[ToolBox : OOF] ThingList defName \"{defName}\" has duplicate(s).");
            }

            //Checks if ThingDef from savedThingProps_Raw still exists and places it in savedThingProps if it does.
            IEnumerable<ThingProp> savedThingProps_Raw = LoadedModManager
                .GetMod<Settings.ToolBox>()
                .GetSettings<ToolBoxSettings>().thingList;
            IList<ThingProp> savedThingProps = new List<ThingProp>();
            int IDLength = 10; //Change this for every new Prop addition.
            foreach (ThingProp thingProp_Raw in savedThingProps_Raw)
            {
                try
                {
                    string test = ThingDef.Named(thingProp_Raw.defName).defName;

                    //Updates any outdated configID from previous saves.
                    if (thingProp_Raw.configID.Length < IDLength)
                    {
                        for (int i = thingProp_Raw.configID.Length; i < IDLength; i++)
                        {
                            thingProp_Raw.configID += "0";
                        }
                    }
                    savedThingProps.Add(thingProp_Raw);
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }

            //Loads the saved data and sets the ThingDefs new value.
            foreach (ThingProp savedThingProp in savedThingProps)
            {
                ThingProp thingProp = thingProps.Single(t => t.defName.Equals(savedThingProp.defName));
                if (savedThingProp.configID[0].Equals('1'))
                {
                    thingProp.costProp.numIntDefault.Add(ThingDef.Named(thingProp.defName).costStuffCount);
                    ThingDef.Named(thingProp.defName).costStuffCount = savedThingProp.costProp.numSavedInt;
                }
                if (savedThingProp.configID[1].Equals('1'))
                {
                    thingProp.baseHPProp.numIntDefault.Add(ThingDef.Named(thingProp.defName).BaseMaxHitPoints);
                    thingProp.baseHPProp.numIntDefault.Add(savedThingProp.baseHPProp.numSavedInt);
                    ThingDef.Named(thingProp.defName).SetStatBaseValue(StatDefOf.MaxHitPoints, savedThingProp.baseHPProp.numSavedInt);
                }
                if (savedThingProp.configID[2].Equals('1'))
                {
                    thingProp.beautyProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thingProp.defName).GetStatValueAbstract(StatDefOf.Beauty)));
                    thingProp.beautyProp.numIntDefault.Add(savedThingProp.beautyProp.numSavedInt);
                    ThingDef.Named(thingProp.defName).SetStatBaseValue(StatDefOf.Beauty, savedThingProp.beautyProp.numSavedInt + 1);
                }
                if (savedThingProp.configID[3].Equals('1'))
                {
                    thingProp.fillProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thingProp.defName).fillPercent * 100f));
                    ThingDef.Named(thingProp.defName).fillPercent = savedThingProp.fillProp.numSavedInt / 100f;
                }
                if (savedThingProp.configID[4].Equals('1'))
                {
                    thingProp.workProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thingProp.defName).GetStatValueAbstract(StatDefOf.WorkToBuild)));
                    ThingDef.Named(thingProp.defName).SetStatBaseValue(StatDefOf.WorkToBuild, savedThingProp.workProp.numSavedInt);
                }
                if (savedThingProp.configID[5].Equals('1'))
                {
                    thingProp.pathProp.numIntDefault.Add(ThingDef.Named(thingProp.defName).pathCost);
                    ThingDef.Named(thingProp.defName).pathCost = savedThingProp.pathProp.numSavedInt;
                }
                if (savedThingProp.configID[6].Equals('1'))
                {
                    thingProp.flammabilityProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thingProp.defName).BaseFlammability * 100f));
                    ThingDef.Named(thingProp.defName).SetStatBaseValue(StatDefOf.Flammability, savedThingProp.flammabilityProp.numSavedInt / 100f);
                }
                if (savedThingProp.configID[7].Equals('1'))
                {
                    thingProp.passabilityProp.optionDefault.Add(ThingDef.Named(thingProp.defName).passability);
                    ThingDef.Named(thingProp.defName).passability = savedThingProp.passabilityProp.savedOption;
                }
                if (savedThingProp.configID[8].Equals('1'))
                {
                    thingProp.linkProp.optionDefault.Add(ThingDef.Named(thingProp.defName).graphicData.linkFlags);
                    ThingDef.Named(thingProp.defName).graphicData.linkFlags = savedThingProp.linkProp.savedOption;
                }
                if (savedThingProp.configID[9].Equals('1'))
                {
                    thingProp.roofProp.optionDefault.Add(new Roofing(ThingDef.Named(thingProp.defName)).Mode);
                    switch (savedThingProp.roofProp.savedOption)
                    {
                        case RoofMode.Auto:
                            ThingDef.Named(thingProp.defName).holdsRoof = true;
                            ThingDef.Named(thingProp.defName).building.allowAutoroof = true;
                            break;
                        case RoofMode.Manual:
                            ThingDef.Named(thingProp.defName).holdsRoof = true;
                            ThingDef.Named(thingProp.defName).building.allowAutoroof = false;
                            break;
                        case RoofMode.None:
                            ThingDef.Named(thingProp.defName).holdsRoof = false;
                            ThingDef.Named(thingProp.defName).building.allowAutoroof = false;
                            break;
                    }
                }
            }
        }
    }
}
