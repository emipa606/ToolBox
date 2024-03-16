using System.Collections.Generic;
using ToolBox.SettingsDefComp;
using Verse;

namespace ToolBox.Settings;

public class ToolBoxSettings : ModSettings
{
    //Saving occurs here. thingList gets value on the ToolBox.WriteSettings()
    public List<ThingProp> thingList = [];

    public override void ExposeData()
    {
        Scribe_Collections.Look(ref thingList, "thingList", LookMode.Deep);
        base.ExposeData();
    }
}