using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp;

public class ThingProp_Link : ThingPropSelect
{
    public readonly IList<LinkFlags> optionDefault = new List<LinkFlags> { LinkFlags.None };
    public LinkFlags option;
    public LinkFlags savedOption;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref savedOption, "link");
    }

    public override void Preset(string defName)
    {
        var linkable = ThingDef.Named(defName).graphicData.Linked;
        if (linkable)
        {
            if (optionDefault.Count > 1)
            {
                optionDefault[0] = optionDefault[1];
                option = ThingDef.Named(defName).graphicData.linkFlags;
            }
            else
            {
                option = optionDefault[0] = ThingDef.Named(defName).graphicData.linkFlags;
            }

            CheckConfig();
        }

        base.Preset(defName);
    }

    public override void CheckConfig()
    {
        if (option == optionDefault[0])
        {
            config = '0';
            savedOption = new LinkFlags();
        }
        else
        {
            config = '1';
            savedOption = option;
        }
    }
}