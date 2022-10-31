using Verse;

namespace ToolBox.SettingsDefComp;

public class ThingProp_BaseHP : ThingPropInput
{
    public override void ExposeData()
    {
        Scribe_Values.Look(ref numSavedInt, "baseHP");
    }

    public override void Preset(string defName)
    {
        if (numIntDefault.Count > 1)
        {
            numIntDefault[0] = numIntDefault[1];
            numInt = ThingDef.Named(defName).BaseMaxHitPoints;
            if (numIntDefault.Count == 3)
            {
                numInt = numIntDefault[2];
            }
        }
        else
        {
            numInt = numIntDefault[0] = ThingDef.Named(defName).BaseMaxHitPoints;
        }

        base.Preset(defName);
    }
}