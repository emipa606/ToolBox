using System.Collections.Generic;
using System.Linq;
using ToolBox.CategoryDefComp;
using ToolBox.Settings;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUpLoad
    {
        static StartUpLoad()
        {
            List<Container> containers = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().categoryDefs;
            List<CategoryDef> categoryDefs = new List<CategoryDef>();
            categoryDefs.AddRange(DefDatabase<CategoryDef>.AllDefs);
            foreach (CategoryDef def in categoryDefs)
            {
                def.PreLoad();
            }
            Log.Error(containers.Count().ToString());
        }
    }
}
