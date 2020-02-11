﻿using System.Collections.Generic;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingPropBase : IExposable
    {
        public string defName;
        public bool draw = false;
        public bool load = true;
        public char config = '0';
        public string label;
        public IList<int> numIntDefault = new List<int>() { 0 };
        public int numSavedInt;
        public int numInt;
        public string numBuffer;
        public virtual void ExposeData()
        {
        }
    }
}
