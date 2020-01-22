using System.Collections.Generic;
using System.Linq;
using ToolBox.CategoryDefComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        //public List<Container> containers = new List<Container>(); 
        //Container outside: Init has output of 2 but will produce an error.
        //Inside: Init has 0
        

        public override void ExposeData()
        {
            //containers = DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList();
            //containers.AddRange(DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList());
            //Scribe_Collections.Look(ref containers, "containers", LookMode.Deep);
            base.ExposeData();
        }

    }
}