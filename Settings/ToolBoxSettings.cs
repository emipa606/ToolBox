using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsDefComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<Container> containers;
        public override void ExposeData()
        {
            Scribe_Collections.Look(ref containers, "containers", LookMode.Deep);
            base.ExposeData();
        }

    }
}