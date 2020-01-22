using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsComp
{
    public class LabelCol
    {
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float x = 0;
        public float y = 0;
        public float width = 0;

        IList<string> label;

        public void Base(IEnumerable<ThingDef> thingDef)
        {
            label = thingDef.Select(l => l.label).ToList();
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
            Construct.Label(x, line, width, label, index);
            line += 24f;
        }
    }
}