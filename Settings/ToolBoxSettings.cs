using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsComp;
using ToolBox.ThingDefComp;
using ToolBox.Tools;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<Container> containers; //<--- loads in ExposeData if it is called
        public IEnumerable<IGrouping<string, ThingDef>> thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .OrderBy(o => o.GetCompProperties<ToolBoxCompProperties>().position)
                .GroupBy(g => g.GetCompProperties<ToolBoxCompProperties>().list);
        public override void ExposeData()
        {
            base.ExposeData();
            containers = DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList();
            Scribe_Collections.Look(ref containers, "containers", LookMode.Deep);

            Loader();
        }

        public void Loader()//Probs just put cost in a dictionary and have the defname as key
        {
            var NN = containers.Zip(thingDef, (a,d) => a.ID == d.Key);
            foreach (var AD in NN)
            {
                Log.Error(AD.ToString());
            }
            foreach (Container T in containers)
            {
                Log.Error(T.ID);
            }

        }
    }
}