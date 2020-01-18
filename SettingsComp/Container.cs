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
    public class Container : IExposable
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol;
        public CostCol costCol;

        static IEnumerable<ThingDef> thingDef;
        static string ID = "null";
        static List<int> cost = new List<int>();
        static IList<string> costBuffer;

        void IExposable.ExposeData()
        {
            Scribe_Values.Look(ref ID, "ID");
            Scribe_Collections.Look(ref cost, "Cost", LookMode.Value);
        }

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
            ID = listID;
            thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            
            IList<int> indexer = ToolHandle.SetCount(thingDef.Count());
            float labelLine = labelCol.y;
            float costLine = costCol.y;

            if (labelCol.header)
            {
                Construct.UnderlinedLabel(labelCol.x, labelCol.y, labelCol.width, labelCol.headerPos, listID);
                labelLine += 24f;
            }
            if (costCol.header)
            {
                Construct.UnderlinedLabel(costCol.x, costCol.y, costCol.width, costCol.headerPos, "Cost");
                costLine += 24f;
            }

            foreach (int index in indexer)
            {
                if (labelCol != null)
                {
                    IList<string> thingLabel = thingDef.Select(l => l.label).ToList();
                    Construct.Label(labelCol.x, labelLine, labelCol.width, thingLabel, index);
                    labelLine += 24f;
                }
                if (costCol != null)
                {
                    if (cost.NullOrEmpty()) { cost.AddRange(thingDef.Select(t => t.costStuffCount).ToList()); }
                    costBuffer = cost.Select(c => c.ToString()).ToList();
                    Construct.InputField(costCol.x, costLine, costCol.width, cost, costBuffer, 4, 10000, index);
                    costLine += 24f;
                }
            }
        }
    }
}