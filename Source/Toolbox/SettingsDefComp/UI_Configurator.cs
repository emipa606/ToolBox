using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class UI_Configurator
    {
        public Col_BaseHP baseHPCol = new Col_BaseHP();
        public Col_Beauty beautyCol = new Col_Beauty();
        public Col_Cost costCol = new Col_Cost();
        public Col_Fill fillCol = new Col_Fill();
        public Col_Flammability flammabilityCol = new Col_Flammability();
        public float height = 0;

        public IList<int> index = new List<int>();
        public Col_Label labelCol = new Col_Label();
        public Col_Link linkCol = new Col_Link();
        public Col_Passability passabilityCol = new Col_Passability();
        public Col_Path pathCol = new Col_Path();
        public ResetButton resetButton = new ResetButton();
        public Col_Roof roofCol = new Col_Roof();
        public Col_Terrain terrainCol = new Col_Terrain();
        public List<ThingProp> thingList = new List<ThingProp>();
        public float width = 0;
        public Col_WorkToBuild workCol = new Col_WorkToBuild();

        //Gets the highest width and height of the loaded widgets and sets it to the DrawProperties' width and height.
        public void CalcSize(List<float> widthList, List<float> heightList)
        {
            if (thingList.NullOrEmpty())
            {
                return;
            }

            var widths = new List<float> {0};
            var heights = new List<float> {0};
            labelCol.SetSize(thingList.Count, widths, heights, 22f);
            costCol.SetSize(thingList.Count, widths, heights, 23.8f);
            baseHPCol.SetSize(thingList.Count, widths, heights, 23.8f);
            beautyCol.SetSize(thingList.Count, widths, heights, 23.8f);
            fillCol.SetSize(thingList.Count, widths, heights, 23.8f);
            pathCol.SetSize(thingList.Count, widths, heights, 23.8f);
            workCol.SetSize(thingList.Count, widths, heights, 23.8f);
            flammabilityCol.SetSize(thingList.Count, widths, heights, 23.8f);
            passabilityCol.SetSize(thingList.Count, widths, heights, 23.8f);
            linkCol.SetSize(thingList.Count, widths, heights, 23.8f);
            roofCol.SetSize(thingList.Count, widths, heights, 23.8f);
            terrainCol.SetSize(thingList.Count, widths, heights, 23.8f);
            resetButton.SetSize(widths, heights);

            //Chooses if wider than the set width
            widthList.Add(width > widths.Max() ? width : widths.Max());

            //Chooses if higher than the set height
            heightList.Add(height > heights.Max() ? height : heights.Max());
        }

        //Loads all the drawn Widgets of DrawProperties
        public void CompileWidgets()
        {
            if (thingList.NullOrEmpty())
            {
                return;
            }

            //Headers... a lot of em.
            labelCol.Header();
            costCol.Header();
            baseHPCol.Header();
            beautyCol.Header();
            fillCol.Header();
            pathCol.Header();
            workCol.Header();
            flammabilityCol.Header();
            passabilityCol.Header();
            linkCol.Header();
            roofCol.Header();
            terrainCol.Header();

            //Does a check of all things in thingList if they are existing or not.
            thingList.ForEach(x => x.LiveCheck());

            //Gets and sets a count from 0 to the number of thingList.
            index = ToolHandle.SetIndexCount(thingList.Count(t => t.live));
            foreach (var thing in thingList
                .Where(t => t.live)
                .OrderBy(t => t.pos)
                .Zip(index, Tuple.Create))
            {
                //ThingProp based widgets
                labelCol.Widget(thing.Item1, thing.Item2);
                costCol.Widget(thing.Item1, thing.Item2);
                baseHPCol.Widget(thing.Item1, thing.Item2);
                beautyCol.Widget(thing.Item1, thing.Item2);
                fillCol.Widget(thing.Item1, thing.Item2);
                pathCol.Widget(thing.Item1, thing.Item2);
                workCol.Widget(thing.Item1, thing.Item2);
                flammabilityCol.Widget(thing.Item1, thing.Item2);
                passabilityCol.Widget(thing.Item1, thing.Item2);
                linkCol.Widget(thing.Item1, thing.Item2);
                roofCol.Widget(thing.Item1, thing.Item2);
                terrainCol.Widget(thing.Item1, thing.Item2);
                thing.Item1.CheckConfig();
            }

            resetButton.Widget(thingList);
        }
    }
}