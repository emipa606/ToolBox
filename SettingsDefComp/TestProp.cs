using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class TestProp : ThingPropBase
    {
        public new int numInt = 1;
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numInt, "numInt");
        }
    }
}
