using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Tools;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class CostCol : BaseCol
    {
        public new string header = "Cost";
        public new float headerPos = 20f;
        public new float width = 80f;

        public List<int> cost = new List<int>();
        public List<string> buffer = new List<string>();

        public void Base(List<string> defName)
        {
            foreach (string name in defName)
            {
                cost.Add(ThingDef.Named(name).costStuffCount);
                buffer.Add(ThingDef.Named(name).costStuffCount.ToString());
            }
        }

        public void Header(ref float vertLine)
        {
            if (linked && hasHeader)
            {
                Construct.UnderlinedLabel(x, vertLine, width, headerPos, header);
                vertLine += 24f;
            }
        }

        public void Body(ref float vertLine, int index)
        {
            if (linked)
            {
                Construct.InputField(x, vertLine, width, cost, buffer, 4, 10000, index);
                vertLine += 24f;
            }
        }
    }
}
