﻿using RimWorld;
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
            foreach (ThingList thing in thingList)
            {
                try
                {
                    string test = ThingDef.Named(thing.defName).label;
                }
                catch (Exception)
                {
                    thing.live = false;
                    Log.Error($"[ToolBox : OOF] Missing ThingDef \"{thing.defName}\" has been skipped over!");
                    continue;
                }
                
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
            int captureCount = 0;
            foreach (ThingList thing in savedThingList)
            {
                try
                {
                    char[] configFlag = thing.configID.ToCharArray();
                    foreach (ThingList thingy in thingList.Where(t => t.defName.Equals(thing.defName)))
                    {
                        if (configFlag[0].Equals('1')) 
                        { thingy.costProp.numIntDefault.Add(ThingDef.Named(thing.defName).costStuffCount); }
                        if (configFlag[1].Equals('1')) 
                        { thingy.baseHPProp.numIntDefault.Add(ThingDef.Named(thing.defName).BaseMaxHitPoints); }
                    }
                    if (configFlag[0].Equals('1'))
                    { ThingDef.Named(thing.defName).costStuffCount = thing.costProp.numSavedInt; }
                    if (configFlag[1].Equals('1'))
                    { ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.MaxHitPoints, thing.baseHPProp.numSavedInt); }
                    //ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.Beauty, thing.beauty + 1);
                }
                catch (Exception)
                {
                    captureCount += 1; 
                    continue;
                }
            }
            if (captureCount > 0)
            {
                Log.Error("[ToolBox : OOF] The save data of the missing def(s) has been skipped over!" +
                    $"\r\nNOTE: Opening and closing the ToolBox settings will remove the missing Def(s) from save.");
            }
        }
    }
}
