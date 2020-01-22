using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsComp
{
    public class CostCol : IExposable
    {
        public bool hasHeader = true;
        public string header = "Cost";
        public float headerPos = 0;
        public float x = 0;
        public float y = 0;
        public float width = 0;

        public List<string> defName = new List<string>();
        public List<int> cost;
        IList<string> buffer;

        void IExposable.ExposeData()
        {
            Scribe_Collections.Look(ref cost, "cost", LookMode.Value);
            Scribe_Collections.Look(ref defName, "defname", LookMode.Value);
        }

        public void Base(IEnumerable<ThingDef> thingDef)
        {
            defName = thingDef.Select(t => t.defName).ToList();
            if (cost.NullOrEmpty()) 
            { 
                cost = thingDef.Select(t => t.costStuffCount).ToList(); //Removed to-list here
                buffer = cost.Select(c => c.ToString()).ToList();
            }
            
        }

        public void Header(ref float line)
        {
            if (hasHeader)
            {
                Construct.UnderlinedLabel(x, y, width, headerPos, header);
                line += 24f;
            }
        }

        public void Body(int index, ref float line)
        {
            if (!cost.NullOrEmpty())
            {
                Construct.InputField(x, line, width, cost, buffer, 4, 10000, index);
                line += 24f;
            }
        }
    }
    //Solution to the problem.
    //List out the defName and cost.
    //Since both will position based on their calls, you can index them one by one.
}