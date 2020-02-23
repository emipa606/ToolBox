using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class DrawContent
    {
        public List<ThingProp> thingList = new List<ThingProp>();
        public Col_Label labelCol = new Col_Label();
        public Col_Cost costCol = new Col_Cost();
        public Col_BaseHP baseHPCol = new Col_BaseHP();
        public Col_Beauty beautyCol = new Col_Beauty();
        public Col_Fill fillCol = new Col_Fill();
        public Col_Path pathCol = new Col_Path();
        public Col_WorkToBuild workCol = new Col_WorkToBuild();
        public Col_Flammability flammabilityCol = new Col_Flammability();
        public Col_Passability passabilityCol = new Col_Passability();
        public ResetButton resetButton = new ResetButton();
        public float width = 0;
        public float height = 0;

        public IList<int> index = new List<int>();

        public void CalcSize() 
        {
            if (!thingList.NullOrEmpty())
            {
                List<float> width = new List<float>() { 0 };
                List<float> height = new List<float>() { 0 };
                labelCol.SetSize(thingList.Count(), width, height, 22f);
                costCol.SetSize(thingList.Count(), width, height, 23.8f);
                baseHPCol.SetSize(thingList.Count(), width, height, 23.8f);
                beautyCol.SetSize(thingList.Count(), width, height, 23.8f);
                fillCol.SetSize(thingList.Count(), width, height, 23.8f);
                pathCol.SetSize(thingList.Count(), width, height, 23.8f);
                workCol.SetSize(thingList.Count(), width, height, 23.8f);
                flammabilityCol.SetSize(thingList.Count(), width, height, 23.8f);
                passabilityCol.SetSize(thingList.Count(), width, height, 23.8f);
                if ((resetButton.width > 0f) && (resetButton.height > 0f))
                {
                    width.Add(resetButton.x + resetButton.width);
                    height.Add(resetButton.y + resetButton.height);
                }
                this.width = width.Max();
                this.height = height.Max();
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
                pathCol.Header();
                workCol.Header();
                flammabilityCol.Header();
                passabilityCol.Header();
                thingList.ForEach(x => x.LiveCheck());
                index = ToolHandle.SetIndexCount(thingList.Where(t => t.live).Count());
                foreach (Tuple<ThingProp, int> thing in thingList
                    .Where(t => t.live)
                    .OrderBy(t => t.pos)
                    .Zip(index, Tuple.Create))
                {
                    labelCol.Widget(thing.Item1, thing.Item2);
                    costCol.Widget(thing.Item1, thing.Item2);
                    baseHPCol.Widget(thing.Item1, thing.Item2);
                    beautyCol.Widget(thing.Item1, thing.Item2);
                    fillCol.Widget(thing.Item1, thing.Item2);
                    pathCol.Widget(thing.Item1, thing.Item2);
                    workCol.Widget(thing.Item1, thing.Item2);
                    flammabilityCol.Widget(thing.Item1, thing.Item2);
                    passabilityCol.Widget(thing.Item1, thing.Item2);
                    thing.Item1.CheckConfig();
                }
                resetButton.Widget(thingList);
            }
        }
    }
}
