using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Container()
        {
            IEnumerable<ThingDef> thingDef = new List<ThingDef>(DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position));
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

        //public int vary = 0;
        //Make a variable specifically for data saving.
        //Example: 
        //outside Compile* varCost;
        //inside Compile* varCost = widgetInput;
        static bool runFlag = true;
        static IEnumerable<ThingDef> thingDef = DefDatabase<ThingDef>.AllDefs;
        static List<int> cost = new List<int>();
        IList<string> costBuffer = new List<string>();
        public void Compile() 
        {
            thingDef = thingDef
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            if (labelCol != null) 
            {
                IEnumerable<string> thingLabel = thingDef.Select(l => l.label);
                Construct.LabelCol(labelCol.x, labelCol.y, labelCol.width, thingLabel, labelCol.header, labelCol.headerPos, listID);
            }

            //Current problem:
            //>Crashes when inserting input too fast.
            //>Slow on performance.
            //>Can't change input value.
            //
            //Do a single foreach outside instead of having to use InputCol which uses too much foreach and takes up performance!
            //Reference StructurePlus.
            if (costCol != null)
            {
                //while (runFlag)
                //{
                    //cost.AddRange(thingDef.Select(c => c.costStuffCount).ToList());
                //}
                Construct.InputCol(costCol.x, costCol.y, costCol.width, cost, costBuffer, 4, 10000, costCol.header, costCol.headerPos, "Cost");
            }
            runFlag = false;
            //Construct.InputField(0f, 100f, 50f, vary, buffy, 4, 99999);
            
            //string buffy = vary.ToString();
            //vary = ToolHandle.Sort(Widgets.TextField(new Rect(0f, 100f, 50f, 22f), buffy), 4, 99999);
            
        }
    }
}
