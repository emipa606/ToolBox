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
            //Checks if the thingDef exsists or not.
            IEnumerable<ThingList> thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList));
            int refCaptureCount = 0;
            foreach (ThingList thing in thingList)
            {
                try
                {
                    string test = ThingDef.Named(thing.defName).label;
                }
                catch (NullReferenceException)
                {
                    thing.live = false;
                    refCaptureCount++;
                    continue;
                }
            }
            if (refCaptureCount > 0)
            {
                Log.Error($"[ToolBox : OOF] The missing ThingDefs will be skipped over." 
                    + "\nNote: opening the ToolBox settings will erase the data of the missing ThingDefs.");
            }

            //Groups similar DefNames in ThingList and reports it.
            IEnumerable<string> sameDefName = thingList.GroupBy(t => t.defName).Where(d => d.Count() > 1).Select(d => d.Key);
            foreach (string defName in sameDefName)
            {
                Log.Error($"[ToolBox : OOF] ThingList defName \"{defName}\" has duplicate(s).");
            }

            //Checks if ThingDef still exists and loads the save if it does.
            IEnumerable<ThingList> savedThingList = LoadedModManager
                .GetMod<Settings.ToolBox>()
                .GetSettings<ToolBoxSettings>().thingList;
            int dataCaptureCount = 0;
            foreach (ThingList thing in savedThingList)
            {
                try
                {
                    foreach (ThingList thingy in thingList.Where(t => t.defName.Equals(thing.defName)))
                    {
                        if (thing.configID[0].Equals('1'))
                        { thingy.costProp.numIntDefault.Add(ThingDef.Named(thing.defName).costStuffCount); }
                        if (thing.configID[1].Equals('1'))
                        {
                            thingy.baseHPProp.numIntDefault.Add(ThingDef.Named(thing.defName).BaseMaxHitPoints);
                            thingy.baseHPProp.numIntDefault.Add(thing.baseHPProp.numSavedInt);
                        }
                        if (thing.configID[2].Equals('1'))
                        {
                            thingy.beautyProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thing.defName).GetStatValueAbstract(StatDefOf.Beauty)));
                            thingy.beautyProp.numIntDefault.Add(thing.beautyProp.numSavedInt);
                        }
                        if (thing.configID[3].Equals('1'))
                        { thingy.fillProp.numIntDefault.Add(Convert.ToInt32(ThingDef.Named(thing.defName).fillPercent)); }
                    }
                    if (thing.configID[0].Equals('1'))
                    { ThingDef.Named(thing.defName).costStuffCount = thing.costProp.numSavedInt; }
                    if (thing.configID[1].Equals('1'))
                    { ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.MaxHitPoints, thing.baseHPProp.numSavedInt); }
                    if (thing.configID[2].Equals('1'))
                    { ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.Beauty, thing.beautyProp.numSavedInt + 1); }
                    if (thing.configID[3].Equals('1'))
                    { ThingDef.Named(thing.defName).fillPercent = thing.fillProp.numSavedInt / 100f; }
                }
                catch (IndexOutOfRangeException) 
                {
                    dataCaptureCount++;
                    continue;
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            if (dataCaptureCount > 0)
            {
                Log.Error("[ToolBox : OOF] Outdated ConfigID spotted." 
                    +"\nNote: opening the settings will reset the previous save data."); 
            }
        }
    }
}
