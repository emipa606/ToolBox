using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Roof : ThingPropSelect
    {
        public IList<RoofMode> optionDefault = new List<RoofMode>() { RoofMode.None };
        public RoofMode savedOption;
        public RoofMode option;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref savedOption, "roof");
        }

        public override void Preset(string defName)
        {
            if (optionDefault.Count > 1)
            {
                optionDefault[0] = optionDefault[1];
                option = new Roofing(ThingDef.Named(defName)).Mode;
            }
            else
            {
                option = optionDefault[0] = new Roofing(ThingDef.Named(defName)).Mode;
            }
            CheckConfig();
            base.Preset(defName);
        }

        public override void CheckConfig()
        {
            if (option == optionDefault[0])
            {
                config = '0';
                savedOption = new RoofMode();
            }
            else
            {
                config = '1';
                savedOption = option;
            }
        }
    }
}
