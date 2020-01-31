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
        public BaseHPCol baseHPCol = new BaseHPCol();
        public ResetButton resetButton = new ResetButton();
        public IList<int> index = new List<int>();
        public float width = 0;
        public float height = 0;
        public bool loadData = true;
        public bool checkSize = true;

        public void AdaptSize() 
        {
            if (checkSize)
            {
                List<float> width = new List<float>() { 0 };
                List<float> height = new List<float>() { 0 };
                if (labelCol.draw)
                {
                    float colHeight = 0;
                    if (labelCol.hasHeader) { colHeight += 22f; }
                    width.Add(labelCol.x + labelCol.width);
                    height.Add(labelCol.y + labelCol.height + (thingList.Count() * 22f) + colHeight);
                }
                if (costCol.draw)
                {
                    float colHeight = 0;
                    if (costCol.hasHeader) { colHeight += 23.8f; }
                    width.Add(costCol.x + costCol.width);
                    height.Add(costCol.y + costCol.height + (thingList.Count() * 23.8f) + colHeight);
                }
                if (baseHPCol.draw)
                {
                    float colHeight = 0;
                    if (baseHPCol.hasHeader) { colHeight += 23.8f; }
                    width.Add(baseHPCol.x + baseHPCol.width);
                    height.Add(baseHPCol.y + baseHPCol.height + (thingList.Count() * 23.8f) + colHeight);
                }
                if (resetButton.draw)
                {
                    width.Add(resetButton.x + resetButton.width);
                    height.Add(resetButton.y + resetButton.height);
                }
                this.width = width.Max();
                this.height = height.Max();
                checkSize = false;
            }
        }

        public void Compile() 
        {
            if (!thingList.NullOrEmpty())
            {
                labelCol.Header();
                costCol.Header();
                baseHPCol.Header();
                if (!index.Count.Equals(thingList.Count()))
                {
                    index = ToolHandle.SetIndexCount(thingList.Count());
                    //Log.Error(index.Count().ToString());
                }
                if (loadData)
                {
                    foreach (ThingList thing in thingList)
                    {
                        thing.drawCost = costCol.draw;
                        thing.drawBaseHP = baseHPCol.draw;
                        thing.InitData();
                    }
                    loadData = false;
                }
                foreach (int i in index)
                {
                    thingList[i].LabelWidget(labelCol.draw, labelCol.x, ToolHandle.SetLine(ref labelCol.vertLine, i), labelCol.width);
                    thingList[i].CostWidget(costCol.draw, costCol.x, ToolHandle.SetLine(ref costCol.vertLine, i), costCol.width, costCol.min, costCol.max);
                    thingList[i].BaseHPWidget(baseHPCol.draw, baseHPCol.x, ToolHandle.SetLine(ref baseHPCol.vertLine, i), baseHPCol.width, baseHPCol.min, baseHPCol.max);
                }
                if (resetButton.draw)
                {
                    if (Widgets.ButtonText(new Rect(resetButton.x, resetButton.y, resetButton.width, resetButton.height), resetButton.label))
                    {
                        foreach (ThingList thing in thingList)
                        {
                            if (costCol.draw)
                            {
                                thing.costBuffer = thing.defaultCost.ToString();
                            }
                            if (baseHPCol.draw)
                            {
                                thing.baseHPBuffer = thing.defaultBaseHP.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
