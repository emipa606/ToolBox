using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingPropInput : ThingPropBase, IExposable
    {
        public IList<int> numIntDefault = new List<int>() { 0 };
        public int numSavedInt;
        public int numInt;
        public string numBuffer;

        public virtual void ExposeData()
        {
        }

        public virtual void Preset(string defName) 
        {
            if (numIntDefault.Count == 3)
            {
                numInt = numIntDefault[2];
            }
            numBuffer = numInt.ToString();
            if (numInt != numIntDefault[0])
            {
                config = '1';
                numSavedInt = numInt;
            }
            else
            {
                config = '0';
                numSavedInt = 0;
            }
            load = false;
        }
    }
}
