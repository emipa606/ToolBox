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
    [StaticConstructorOnStartup]
    public class Container
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol = new LabelCol();
        public CostCol costCol;

        static IEnumerable<ThingDef> thingDef;
        public static List<int> cost;
        public static List<string> costBuffer;
        
        static Container()
        {
            //cost.AddRange(thingDef.Select(t => t.costStuffCount).ToList());
            //costBuffer.AddRange(thingDef.Select(c => c.costStuffCount.ToString()).ToList());
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
            thingDef = DefDatabase<ThingDef>.AllDefs
                .Where(t => t.HasComp(typeof(ToolBoxComp)))
                .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(listID))
                .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);
            cost = thingDef.Select(t => t.costStuffCount).ToList();
            costBuffer = thingDef.Select(c => c.costStuffCount.ToString()).ToList();
            if (labelCol != null) 
            {
                IEnumerable<string> thingLabel = thingDef.Select(l => l.label);
                Construct.LabelCol(labelCol.x, labelCol.y, labelCol.width, thingLabel, labelCol.header, labelCol.headerPos, listID);
            }

            if (costCol != null)
            {
                //Try and see if its possible to directly go and change the thingDef value instead.
                //Example:
                //thingDef.cost.Select.Replace(Input)
                costBuffer[0] = cost[0].ToString();
                cost[0] = ToolHandle.Sort(Widgets.TextField(new Rect(costCol.x, costCol.y, costCol.width, 22f), costBuffer[0]), 4, 99999);
            }
        }
    }
}

//Current problem:
//>Crashes when inserting input too fast.
//>Slow on performance.
//>Can't change input value.
//
//Do a single foreach outside instead of having to use InputCol which uses too much foreach and takes up performance!
//Reference StructurePlus.

//AddRange doesn't work but .Add works. Range, for some reason, takes IEnumerables.
//See if it's possible to send ranges just like .Add
//Also look into Array, it may have a better solution.

//LabelCol labelCol = new LabelCol();
/*
thingDef = DefDatabase<ThingDef>.AllDefs
    .Where(t => t.HasComp(typeof(ToolBoxComp)))
    .Where(l => l.GetCompProperties<ToolBoxCompProperties>().list.Equals(labelCol))
    .OrderBy(t => t.GetCompProperties<ToolBoxCompProperties>().position);*/

//Construct.InputCol(costCol.x, costCol.y, costCol.width, cost, costBuffer, 4, 10000, costCol.header, costCol.headerPos, "Cost");