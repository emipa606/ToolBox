using System.Collections.Generic;
using System.Linq;
using ToolBox.ThingDefComp;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsComp
{
    public class Container : IExposable
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol;
        public CostCol costCol;
        //Reset button!

        IEnumerable<ThingDef> thingDef;
        IList<int> indexer;

        void IExposable.ExposeData()
        {
            Scribe_Deep.Look(ref costCol, "costCol");
        }
        
        public bool HasListID
        {
            get
            {
                if (labelCol != null || costCol != null)
                {
                    if (listID != null)
                    {
                        return listID.Length != 0;
                    }
                    return false;
                }
                else
                {
                    if (listID != null)
                    {
                        return listID.Length != 0;
                    }
                    return true;
                }
            }
        }

        public virtual void Initialize()
        {
            thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            if (labelCol != null)
            {
                labelCol.Base(thingDef);
            }
            if (costCol != null)
            {
                costCol.Base(thingDef);
            }
        }
        
        public virtual void Compile() 
        {
            indexer = ToolHandle.SetCount(thingDef.Count());
            float labelLine = 0;
            float costLine = 0;

            if (labelCol != null)
            {
                labelLine = labelCol.y;
                labelCol.Header(ref labelLine);
            }

            if (costCol != null)
            {
                costLine = costCol.y;
                costCol.Header(ref costLine);
            }

            foreach (int index in indexer)
            {
                if (labelCol != null) { labelCol.Body(index, ref labelLine); }
                if (costCol != null) { costCol.Body(index, ref costLine); }
            }
        }
    }
}