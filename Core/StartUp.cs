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
            IEnumerable<ThingList> thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList));

            IEnumerable<string> sameDefName = thingList.GroupBy(t => t.defName).Where(d => d.Count() > 1).Select(d => d.Key);
            foreach (string defName in sameDefName)
            {
                Log.Error($"[ToolBox : OOF] ThingList defName \"{defName}\" has duplicate(s).");
            }

            //Below saves default, though affects startup impact. The impact depends on the amount of ThingDefs in the settings.
            //This could be placed in the moment the settings open so that the ones not used wont load.
            //Why is is not there? Something about early checks... I think...
            //Feel free to move it if you find it inefficient.
            foreach (ThingList thing in thingList)
            {
                bool captured = false;
                try
                {
                    thing.defaultCost = ThingDef.Named(thing.defName).costStuffCount;
                    thing.defaultBaseHP = ThingDef.Named(thing.defName).BaseMaxHitPoints;
                    thing.defaultBeauty = Convert.ToInt32(ThingDef.Named(thing.defName).GetStatValueAbstract(StatDefOf.Beauty));
                }
                catch (System.Exception)
                {
                    thing.exists = false;
                    captured = true;
                }
                if (captured) { captured = false; continue; }
            }

            IEnumerable<ThingList> savedThingList = LoadedModManager
                .GetMod<Settings.ToolBox>()
                .GetSettings<ToolBoxSettings>().thingList;
            int captureCount = 0;
            foreach (ThingList thing in savedThingList)
            {
                bool captured = false;
                try
                {
                    ThingDef.Named(thing.defName).costStuffCount = thing.cost;
                    ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.MaxHitPoints, thing.baseHP);
                    ThingDef.Named(thing.defName).SetStatBaseValue(StatDefOf.Beauty, thing.beauty + 1);
                }
                catch (System.Exception)
                {
                    captured = true;
                }
                if (captured){ captured = false; captureCount += 1; continue; }
            }
            if (captureCount > 0)
            {
                Log.Error("[ToolBox : OOF] The save data of the missing def(s) has been skipped over!" +
                    $"\r\n[ToolBox : NOTE] Opening and closing the ToolBox settings will remove the missing Def(s) from save.");
            }
        }
    }
}
