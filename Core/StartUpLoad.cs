using System.Collections.Generic;
using System.Linq;
using ToolBox.Settings;
using ToolBox.SettingsDefComp;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUpLoad
    {
        static StartUpLoad()
        {
            //Below saves default, though affects startup impact. The impact depends on the amount of ThingDefs in the settings.
            //This could be placed in the moment the settings open so that the ones not used wont load.
            //Why is is not there? Something about early checks... I think...
            //Feel free to move it if you find it inefficient.
            IEnumerable<ThingList> thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList));
            foreach (ThingList thing in thingList)
            {
                bool captured = false;
                try
                {
                    thing.defaultCost = ThingDef.Named(thing.defName).costStuffCount;
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
