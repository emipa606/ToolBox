using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsDefComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<ThingList> thingList = new List<ThingList>();
        public override void ExposeData()
        {
            Scribe_Collections.Look(ref thingList, "thingList", LookMode.Deep);
            //Log.Error($"Saved {thingList.Count().ToString()} thingList(s)!");
            base.ExposeData();
        }
    }
}