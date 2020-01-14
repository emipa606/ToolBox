using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.ThingDefComp;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsComp
{
    public class Container
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol;
        public CostCol costCol;

        public bool HasListID
        {
            get
            {
                if (listID != null)
                {
                    return listID.Length != 0;
                }
                return listID != null;
            }
        }

        public void Compile() 
        {
            IEnumerable<ThingDef> thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            if (labelCol != null) 
            {
                IEnumerable<string> thingLabel = thingDef
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .Select(l => l.label);

                Construct.LabelCol(labelCol.x, labelCol.y, labelCol.width, thingLabel, labelCol.header, labelCol.headerPos, listID);

            }
        }
    }
}
