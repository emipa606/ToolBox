using System.Collections.Generic;
using System.Linq;
using ToolBox.Core;
using ToolBox.SettingsComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<CategoryDef> categoryDef = new List<CategoryDef>();
        public override void ExposeData()
        {
            categoryDef = DefDatabase<CategoryDef>.AllDefs.ToList(); //Must always be in here!
            Scribe_Collections.Look(ref categoryDef, "categoryDef", LookMode.Deep);
            base.ExposeData();
        }
        //Objective: Collect all the containers and put them on a singular list.
        //Concat the container lists
        //Merge the same named list
    }
}
