using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsDefComp;
using ToolBox.Settings;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUpLoad
    {
        static StartUpLoad()
        {
            IEnumerable<Container> containers; 
            bool hasContainers = !LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers.NullOrEmpty();
            int sameCount = DefDatabase<SettingsDef>.AllDefsListForReading.Count;
            bool sameContainers = false;
            if (hasContainers)
            {
                sameContainers = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers.Count == sameCount;
            }
            if (sameContainers)
            {
                containers = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers;
                Log.Error($"Container has {containers.Count().ToString()} items.");
            }
            else
            {
                Log.Error("Container data is empty!");
            }
            IEnumerable<SettingsDef> settings = DefDatabase<SettingsDef>.AllDefs;
            foreach (SettingsDef def in settings)
            {
                def.PreLoad();
            }
        }
    }
}
