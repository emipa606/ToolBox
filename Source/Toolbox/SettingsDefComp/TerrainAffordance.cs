using RimWorld;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class TerrainAffordance
    {
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

        public TerrainMode Mode { get; set; }
    }
}