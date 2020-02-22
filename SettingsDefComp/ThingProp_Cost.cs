using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Cost : ThingPropInput
    {
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "cost");
        }

        public override void Preset(string defName) 
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = ThingDef.Named(defName).costStuffCount;
            }
            else
            {
                numInt = numIntDefault[0] = ThingDef.Named(defName).costStuffCount;
            }
            base.Preset(defName);
        }
    }
}
