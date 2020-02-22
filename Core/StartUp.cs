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
            //Groups similar DefNames in ThingList and reports it.
            IEnumerable<ThingProp> thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList));
            IEnumerable<string> sameDefName = thingList
                .GroupBy(t => t.defName)
                .Where(d => d.Count() > 1)
                .Select(d => d.Key);
            foreach (string defName in sameDefName)
            {
                Log.Error($"[ToolBox : OOF] ThingList defName \"{defName}\" has duplicate(s).");
            }

            //Checks if ThingDef still exists and loads the save if it does.
            IEnumerable<ThingProp> savedThingList = LoadedModManager
                .GetMod<Settings.ToolBox>()
                .GetSettings<ToolBoxSettings>().thingList;
            int dataCaptureCount = 0;
            foreach (ThingProp thing in savedThingList)
            {
                try
                {
                    foreach (ThingProp thingy in thingList.Where(t => t.defName.Equals(thing.defName)))
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
