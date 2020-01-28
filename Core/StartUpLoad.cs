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
            IEnumerable<ThingList> thingList = LoadedModManager
                .GetMod<Settings.ToolBox>()
                .GetSettings<ToolBoxSettings>().thingList;
            foreach (ThingList thing in thingList)
            {
                ThingDef.Named(thing.defName).costStuffCount = thing.cost;
            }
        }
    }
}
