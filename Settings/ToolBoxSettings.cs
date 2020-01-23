using System.Collections.Generic;
using System.Linq;
using ToolBox.CategoryDefComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<Container> categoryDefs = DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList();
        public override void ExposeData()
        {
            Scribe_Collections.Look(ref categoryDefs, "containers", LookMode.Deep);
            base.ExposeData();
        }

    }
}