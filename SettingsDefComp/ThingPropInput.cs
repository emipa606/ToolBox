using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingPropInput : ThingPropBase, IExposable
    {
        public IList<int> numIntDefault = new List<int>() { 0 };
        public int numSavedInt;
        public int numInt;
        public string numBuffer;
        public char config = '0';

        public virtual void ExposeData()
        {
        }

        public virtual void Preset(string defName) 
        {
            numBuffer = numInt.ToString();
            CheckConfig();
            load = false;
        }

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
}
