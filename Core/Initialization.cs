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
        //static IEnumerable<CategoryDef> categoryDef = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().categoryDef;
        static IEnumerable<ThingDef> thingDef = DefDatabase<ThingDef>.AllDefs.Where(t => t.HasComp(typeof(ToolBoxComp)));
         
        static Initialization()
        {
            //IEnumerable<Container> container = categoryDef.Select(c => c.drawContent);
            foreach (ThingDef thing in thingDef)
            {
                //bool sameID = thing.GetCompProperties<ToolBoxCompProperties>().list.
                    //.Equals(categoryDef.Select(c => c.drawContent.Select(l => l.listID)));
                    /*thingDef
                    .Select(t => t.GetCompProperties<ToolBoxCompProperties>().list
                    .Equals(categoryDef.Select(c => c.drawContent.Select(l => l.listID))));*/
                //
                //if (sameID)
                //{
                //    Log.Error(categoryDef.Select(c => c.drawContent.Select(d => d.listID)).ToString());
                //}
            }
            //List<bool> woof = categoryDef.Where(c => c.)
        }
    }
}
