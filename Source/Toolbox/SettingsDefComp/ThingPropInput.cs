using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp;

public class ThingPropInput : ThingPropBase, IExposable
{
    public char config = '0';
    public string numBuffer;
    public int numInt;
    public IList<int> numIntDefault = new List<int> { 0 };
    public int numSavedInt;

    //A method for saving data
    public virtual void ExposeData()
    {
    }

    //Sets the beggining values that can't be placed in a constructor
    public virtual void Preset(string defName)
    {
        numBuffer = numInt.ToString();
        CheckConfig();
        load = false;
    }

    //Checks whether the value of the ThingProp is changed
    public virtual void CheckConfig()
    {
        if (numInt == numIntDefault[0])
        {
            config = '0';
            numSavedInt = 0;
        }
        else
        {
            config = '1';
            numSavedInt = numInt;
        }
    }
}