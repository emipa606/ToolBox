using System.Collections.Generic;
using System.Linq;
using ToolBox.Core;
using ToolBox.SettingsComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public override void ExposeData()
        {
            List<CategoryDef> categoryDef = DefDatabase<CategoryDef>.AllDefs.ToList();
            Scribe_Collections.Look(ref categoryDef, "categoryDef", LookMode.Deep);
            base.ExposeData();
        }
    }
}
