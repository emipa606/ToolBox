using System;
using Verse;

namespace ToolBox.ThingDefComp
{
    public class ToolBoxCompProperties : CompProperties
    {
        public string list;
        public float position = 0;

        public bool HasList
        {
            get
            {
                if (list != null)
                {
                    return list.Length != 0;
                }
                return list != null;
            }
        }

        public ToolBoxCompProperties()
        {
            compClass = typeof(ToolBoxComp);
        }

        public ToolBoxCompProperties(Type compClass) : base(compClass)
        {
            this.compClass = compClass;
        }
    }
}
