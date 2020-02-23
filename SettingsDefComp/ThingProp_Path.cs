using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Path : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "path");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = ThingDef.Named(defName).pathCost;
            }
            else
            {
                numInt = numIntDefault[0] = ThingDef.Named(defName).pathCost;
            }
            base.Preset(defName);
        }
    }
}
