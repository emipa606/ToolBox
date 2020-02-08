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
        public List<DrawContent> drawContent = new List<DrawContent>();

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
            drawScrollbar = scrollbar;
            if (checkSize)
            {
                drawContent.ForEach(c => c.CalcSize());
                checkSize = false;
            }
            float addHeight = 0f;
            bool widerContent = drawContent.Select(c => c.width).Max() > rect.width;
            bool higherContent = drawContent.Select(c => c.height).Max() > rect.height;
            bool widerSettings = width > rect.width;
            bool higherSettings = height > rect.height;
            if (widerSettings)
            {
                rectView.width = width;
                rect.width = width;
                rectView.height -= 16f;
                addHeight += 1f;
            }
            else if (widerContent)
            {
                rectView.width = drawContent.Select(d => d.width).Max();
                rect.width = drawContent.Select(d => d.width).Max();
                rectView.height -= 16f;
                addHeight += 1f;
            }
            if (higherSettings)
            {
                rectView.height = height;
                rect.height = height;
            }
            else if (higherContent)
            {
                rectView.height = drawContent.Select(d => d.height).Max() + addHeight;
                rect.height = drawContent.Select(d => d.height).Max() + addHeight;
            }
        }

        public void LoadBaseValue() 
        {
            drawContent.ForEach(c => c.SetDraw());
        }

        public void Display() 
        {
            drawContent.ForEach(c => c.CompileWidgets());
        }
    }
}