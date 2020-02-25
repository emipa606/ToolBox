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
        public CategoryLevel level = 0;
        public bool scrollbar = true;
        public float width = 0;
        public float height = 0;
        public List<DrawProperties> drawProperties = new List<DrawProperties>();
        public DrawMisc drawMisc = new DrawMisc();

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

        public void AdaptSize(ref Rect rect, ref Rect rectView, ref bool drawScrollbar) 
        {
            if (checkSize)
            {
                drawScrollbar = scrollbar;
                List<float> width = new List<float>() { 0 };
                List<float> height = new List<float>() { 0 };
                drawProperties.ForEach(c => c.CalcSize(width, height));
                drawMisc.CalcSize(width, height);

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

            if (this.width > rect.width)
            {
                rectView.width = this.width;
                rect.width = this.width;
                rectView.height -= 16f;
            }
            if (this.height > rect.height)
            {
                rectView.height = this.height;
                rect.height = this.height;
            }
        }

        public void Display() 
        {
            drawProperties.ForEach(c => c.CompileWidgets());
            drawMisc.CompileWidgets();
        }
    }
}