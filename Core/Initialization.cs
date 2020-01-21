using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using ToolBox.Settings;
using RimWorld;
using ToolBox.ThingDefComp;
using ToolBox.SettingsComp;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class Initialization
    {
        static Initialization()
        {
            IEnumerable<Container> container = LoadedModManager
                .GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers;

            IEnumerable<IGrouping<string, ThingDef>> thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .OrderBy(o => o.GetCompProperties<ToolBoxCompProperties>().position)
                .GroupBy(g => g.GetCompProperties<ToolBoxCompProperties>().list);

            //Log.Error(container.Count().ToString());
        }
    }
}
