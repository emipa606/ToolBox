using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class TerrainAffordance
    {
        public TerrainMode Mode { get; set; }

        public TerrainAffordance(ThingDef thingDef) 
        {
            if (thingDef.terrainAffordanceNeeded == TerrainAffordanceDefOf.Light)
            {
                Mode = TerrainMode.Light;
            }
            if (thingDef.terrainAffordanceNeeded == TerrainAffordanceDefOf.Medium)
            {
                Mode = TerrainMode.Medium;
            }
            if (thingDef.terrainAffordanceNeeded == TerrainAffordanceDefOf.Heavy)
            {
                Mode = TerrainMode.Heavy;
            }
        }
    }
}
