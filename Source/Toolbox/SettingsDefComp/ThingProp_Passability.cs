using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp;

public class ThingProp_Passability : ThingPropSelect
{
    public Traversability option;
    public IList<Traversability> optionDefault = new List<Traversability> { Traversability.Standable };
    public Traversability savedOption;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref savedOption, "passability");
    }

    public override void Preset(string defName)
    {
        if (optionDefault.Count > 1)
        {
            optionDefault[0] = optionDefault[1];
            option = ThingDef.Named(defName).passability;
        }
        else
        {
            option = optionDefault[0] = ThingDef.Named(defName).passability;
        }

        CheckConfig();
        base.Preset(defName);
    }

    public override void CheckConfig()
    {
        if (option == optionDefault[0])
        {
            config = '0';
            savedOption = new Traversability();
        }
        else
        {
            config = '1';
            savedOption = option;
        }
    }
}