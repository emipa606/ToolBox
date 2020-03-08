using System.Collections.Generic;
using Verse;
using System.Linq;
using ToolBox.SettingsDefComp;
using UnityEngine;

namespace ToolBox
{
    public class SettingsDef : Def
    {
        public float position = 0;
        public CategoryLevel level = CategoryLevel.Middle;
        public bool scrollbar = true;
        public float width = 0;
        public float height = 0;
        public List<UI_Configurator> configurator = new List<UI_Configurator>();
        public UI_Design design = new UI_Design();

        public bool checkSize = true;

        public static SettingsDef Named(string defName)
        {
            return DefDatabase<SettingsDef>.GetNamed(defName, true);
        }

        public override IEnumerable<string> ConfigErrors()
        {
            if (level == 0)
            {
                yield return "CategoryDef is missing a level.";
            }
            yield break;
        }

        //Adapts the size of Rect container based on the size and position of all the drawn widgets.
        public void AdaptSize(ref Rect rect, ref Rect rectView, ref bool drawScrollbar) 
        {
            if (checkSize)
            {
                drawScrollbar = scrollbar;
                List<float> width = new List<float>() { 0 };
                List<float> height = new List<float>() { 0 };
                configurator.ForEach(c => c.CalcSize(width, height));
                design.CalcSize(width, height);

                //Compares and takes the highest width and height of all the 
                if (width.Max() > this.width)
                {
                    this.width = width.Max();
                }
                if (height.Max() > this.width)
                {
                    this.height = height.Max();
                }
                checkSize = false;
            }

            //If the initialized size is higher than the calculated size, it will use the given size instead.
            if (this.width > rect.width)
            {
                rectView.width = width;
                rect.width = width;
                rectView.height -= 16f;
            }
            if (this.height > rect.height)
            {
                rectView.height = height;
                rect.height = height;
            }
        }

        //Gets all the compilation of widgets and is compiled again in Display for later calling in ToolBox
        public void Display() 
        {
            configurator.ForEach(c => c.CompileWidgets());
            design.CompileWidgets();
        }
    }
}