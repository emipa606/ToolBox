using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class DrawContent
    {
        public List<ThingList> thingList = new List<ThingList>();
        public LabelCol labelCol = new LabelCol();
        public CostCol costCol = new CostCol();
        public ResetButton resetButton = new ResetButton();
        public IList<int> index = new List<int>();
        public bool loadData = true;

        public void Compile() 
        {
            if (!thingList.NullOrEmpty())
            {
                labelCol.Header();
                costCol.Header();
                if (!index.Count.Equals(thingList.Count()))
                {
                    index = ToolHandle.SetIndexCount(thingList.Count());
                    //Log.Error(index.Count().ToString());
                }
                if (loadData)
                {
                    //Log.Error("Data loaded!");
                    foreach (ThingList thing in thingList)
                    {
                        thing.InitData();
                    }
                    loadData = false;
                }
                foreach (int i in index)
                {
                    thingList[i].LabelWidget(labelCol.x, ToolHandle.SetLine(ref labelCol.vertLine, i), labelCol.width);
                    thingList[i].CostWidget(costCol.x, ToolHandle.SetLine(ref costCol.vertLine, i), costCol.width, costCol.min, costCol.max);
                }
                if (resetButton.width > 0)
                {
                    if (Widgets.ButtonText(new Rect(resetButton.x, resetButton.y, resetButton.width, resetButton.height), resetButton.label))
                    {
                        foreach (ThingList thing in thingList)
                        {
                            thing.costBuffer = thing.defaultCost.ToString();
                        }
                    }
                }
            }
        }
    }
}
