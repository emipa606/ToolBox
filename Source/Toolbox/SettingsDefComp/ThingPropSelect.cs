using Verse;

namespace ToolBox.SettingsDefComp;

public class ThingPropSelect : ThingPropBase, IExposable
{
    public char config = '0';

    //A method for saving data
    public virtual void ExposeData()
    {
    }

    //Sets the beggining values that can't be placed in a constructor
    public virtual void Preset(string defName)
    {
        load = false;
    }

    //Checks whether the value of the ThingProp is changed
    public virtual void CheckConfig()
    {
    }
}