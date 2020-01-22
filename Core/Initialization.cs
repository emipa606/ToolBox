using System.Collections.Generic;
using System.Linq;
using Verse;
using ToolBox.Settings;
using ToolBox.ThingDefComp;
using ToolBox.SettingsComp;
using ToolBox.Tools;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    public class Initialization
    {
        
        static List<int> indexer = new List<int>();
        static Initialization()
        {
            /*
            List<Container> conts = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers;
            IEnumerable<ThingDef> thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)));
            conts.AddRange(DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList());
            ThingDef.Named("TTest").costStuffCount.Equals(40);
            Log.Error(conts.Count().ToString());
            

            foreach (Container crow in conts)
            {
                indexer = ToolHandle.SetCount(crow.costCol.cost.Count()).ToList();
                foreach (int cc in indexer)
                {
                    ThingDef.Named(crow.costCol.defName[cc]).costStuffCount.Equals(crow.costCol.cost[cc]);
                    //Lots of problem. This is fake loading. Previous saving input does not work anymore.
                    //Back track most to find what went wrong.
                    //See if it did previously save. If not. Do a checking if the value is different from before and then change the value
                    //if not.
                }
            }*/
        }
    }
}
