using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ToolBox.ThingDefComp;
using ToolBox.Tools;
using UnityEngine;
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

        IEnumerable<ThingDef> thingDef;
        public static List<int> cost = new List<int>();
        static IList<string> costBuffer;

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
            thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);

            float line = labelCol.y;//change to it's specific var name. e.g. label
            if (labelCol.header)
            {
                Construct.UnderlinedLabel(labelCol.x, labelCol.y, labelCol.width, labelCol.headerPos, listID);
                line += 24f;
            }
            IList<string> thingLabel = thingDef.Select(l => l.label).ToList();
            IList<int> indexer = ToolHandle.SetCount(thingLabel.Count());
            foreach (int index in indexer)
            {
                if (labelCol != null)
                {
                    Construct.Label(labelCol.x, line, labelCol.width, thingLabel, index);
                    line += 24f + (index - index);
                }
            }
            //The tools are prepared. Work on the costCol.
            /*
            if (labelCol != null) 
            {
                IEnumerable<string> thingLabel = thingDef.Select(l => l.label);
                Construct.LabelCol(labelCol.x, labelCol.y, labelCol.width, thingLabel, labelCol.header, labelCol.headerPos, listID);
            }*/
            /*
            if (costCol != null)
            {
                if (cost.NullOrEmpty()){cost.AddRange(thingDef.Select(t => t.costStuffCount).ToList());}
                costBuffer = cost.Select(c => c.ToString()).ToList();
                
                Construct.InputField(costCol.x, costCol.y, costCol.width, cost, costBuffer, 4);
            }*/
        }
    }
}