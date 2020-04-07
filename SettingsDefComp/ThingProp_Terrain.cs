using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Terrain : ThingPropSelect
    {

        public IList<TerrainMode> optionDefault = new List<TerrainMode>() { TerrainMode.Light };
        public TerrainMode savedOption;
        public TerrainMode option;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref savedOption, "terrain");
        }

        public override void Preset(string defName)
        {
            if (optionDefault.Count > 1)
            {
                optionDefault[0] = optionDefault[1];
                option = new TerrainAffordance(ThingDef.Named(defName)).Mode;
            }
            else
            {
                option = optionDefault[0] = new TerrainAffordance(ThingDef.Named(defName)).Mode;
            }
            CheckConfig();
            base.Preset(defName);
        }

        public override void CheckConfig()
        {
            if (option == optionDefault[0])
            {
                config = '0';
                savedOption = new TerrainMode();
            }
            else
            {
                config = '1';
                savedOption = option;
            }
        }
    }
}
