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
        //Reset button!

        IEnumerable<ThingDef> thingDef;
        IList<string> thingLabel;
        IList<int> indexer;
        public string ID = "null";
        public List<int> cost = new List<int>(); //Always initialize a list! Static makes it load as one 
        IList<string> costBuffer;

        void IExposable.ExposeData()
        {
            Scribe_Values.Look(ref ID, "ID");
            Scribe_Collections.Look(ref cost, "Cost", LookMode.Value);
        }
        
        //Create an exception for listID
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

        public void Initialize()
        {
            ID = listID;
            thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            if (labelCol != null)
            {
                thingLabel = thingDef.Select(l => l.label).ToList();
            }
            if (costCol != null)
            {
                if (cost.NullOrEmpty()) { cost.AddRange(thingDef.Select(t => t.costStuffCount).ToList()); }
                costBuffer = cost.Select(c => c.ToString()).ToList();
            }
        }
        //Make a method called Data() and insert cost and listID initializer.
        //Use the method on CategoryDef

        public void Compile() 
        {
            indexer = ToolHandle.SetCount(thingDef.Count());
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
                    Construct.Label(labelCol.x, labelLine, labelCol.width, thingLabel, index);
                    labelLine += 24f;
                }
                if (costCol != null)
                {
                    Construct.InputField(costCol.x, costLine, costCol.width, cost, costBuffer, 4, 10000, index);
                    costLine += 24f;
                }
            }
        }
    }
}