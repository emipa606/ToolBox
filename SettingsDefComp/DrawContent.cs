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
        public Col_Label labelCol = new Col_Label();
        public Col_Cost costCol = new Col_Cost();
        public Col_BaseHP baseHPCol = new Col_BaseHP();
        public Col_Beauty beautyCol = new Col_Beauty();
        public Col_Fill fillCol = new Col_Fill();
        public ResetButton resetButton = new ResetButton();
        public bool runSetDraw = true;
        public float width = 0;
        public float height = 0;

        public IList<int> index = new List<int>();

        public void CalcSize() 
        {
            if (!thingList.NullOrEmpty())
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
                if (beautyCol.draw)
                {
                    float colHeight = 0;
                    if (beautyCol.hasHeader) { colHeight += 23.8f; }
                    width.Add(beautyCol.x + beautyCol.width);
                    height.Add(beautyCol.y + beautyCol.height + (thingList.Count() * 23.8f) + colHeight);
                }
                if (fillCol.draw)
                {
                    float colHeight = 0;
                    if (fillCol.hasHeader) { colHeight += 23.8f; }
                    width.Add(fillCol.x + fillCol.width);
                    height.Add(fillCol.y + fillCol.height + (thingList.Count() * 23.8f) + colHeight);
                }
                if (resetButton.draw)
                {
                    width.Add(resetButton.x + resetButton.width);
                    height.Add(resetButton.y + resetButton.height);
                }
                this.width = width.Max();
                this.height = height.Max();
            }
        }

        //Runs on open
        public void SetDraw() 
        {
            if (!thingList.NullOrEmpty() && runSetDraw)
            {
                foreach (ThingList thing in thingList)
                {
                    thing.labelProp.draw = labelCol.draw;
                    thing.costProp.draw = costCol.draw;
                    thing.baseHPProp.draw = baseHPCol.draw;
                    thing.beautyProp.draw = beautyCol.draw;
                    thing.fillProp.draw = fillCol.draw;
                }
                runSetDraw = false;
            }
        }

        public void CompileWidgets() 
        {
            if (!thingList.NullOrEmpty())
            {
                labelCol.Header();
                costCol.Header();
                baseHPCol.Header();
                beautyCol.Header();
                fillCol.Header();
                index = ToolHandle.SetIndexCount(thingList.Count);
                foreach (int i in index)
                {
                    if (thingList[i].live)
                    {
                        thingList[i].labelProp.Widget(thingList[i].defName, labelCol.x, ToolHandle.SetLine(ref labelCol.vertLine, i), labelCol.width);
                        thingList[i].costProp.Widget(thingList[i].defName, costCol.x, ToolHandle.SetLine(ref costCol.vertLine, i), costCol.width, costCol.min, costCol.max);
                        thingList[i].baseHPProp.Widget(thingList[i].defName, baseHPCol.x, ToolHandle.SetLine(ref baseHPCol.vertLine, i), baseHPCol.width, baseHPCol.min, baseHPCol.max);
                        thingList[i].beautyProp.Widget(thingList[i].defName, beautyCol.x, ToolHandle.SetLine(ref beautyCol.vertLine, i), beautyCol.width, beautyCol.min, beautyCol.max);
                        thingList[i].fillProp.Widget(thingList[i].defName, fillCol.x, ToolHandle.SetLine(ref fillCol.vertLine, i), fillCol.width, fillCol.min, fillCol.max);
                        thingList[i].CheckConfig();
                    }
                }
                if (resetButton.draw)
                {
                    if (Widgets.ButtonText(new Rect(resetButton.x, resetButton.y, resetButton.width, resetButton.height), resetButton.label))
                    {
                        foreach (ThingList thing in thingList.Where(t => t.live))
                        {
                            if (costCol.draw) { thing.costProp.numBuffer = thing.costProp.numIntDefault[0].ToString(); }
                            if (baseHPCol.draw) { thing.baseHPProp.numBuffer = thing.baseHPProp.numIntDefault[0].ToString(); }
                            if (beautyCol.draw) { thing.beautyProp.numBuffer = thing.beautyProp.numIntDefault[0].ToString(); }
                            if (fillCol.draw) { thing.fillProp.numBuffer = thing.fillProp.numIntDefault[0].ToString(); }
                        }
                    }
                }
            }
        }
    }
}
