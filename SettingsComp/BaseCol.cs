using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.ThingDefComp;
using Verse;

namespace ToolBox.SettingsComp
{
    public class BaseCol : IExposable
    {
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float x = 0;
        public float y = 0;
        public float width = 0;

        public static List<ThingDef> rawThingDef;
        public IList<int> index;

        public virtual void Base(string listID)
        {
            rawThingDef = DefDatabase<ThingDef>.AllDefs.Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position).ToList();
            Log.ErrorOnce(rawThingDef.Count().ToString(), 1);
        }

        public virtual void ExposeData()
        {
        }
    }
}
