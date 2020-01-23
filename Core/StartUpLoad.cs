using System.Collections.Generic;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUpLoad
    {
        static StartUpLoad()
        {
            List<CategoryDef> categoryDefs = new List<CategoryDef>();
            categoryDefs.AddRange(DefDatabase<CategoryDef>.AllDefs);
            foreach (CategoryDef def in categoryDefs)
            {
                def.PreLoad();
            }
        }
    }
}
