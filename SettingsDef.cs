using System.Collections.Generic;
using Verse;
using UnityEngine;
using ToolBox.SettingsDefComp;
using System.Linq;

namespace ToolBox
{
    public class SettingsDef : Def
    {
        //Adjustable height and width
        public float position = 0;
        public CategoryLevel level = 0;
        public bool horiScrollbar = false;
        public bool vertiScrollbar = false;
        public List<DrawContent> drawContent = new List<DrawContent>();

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

        public void Display() 
        {
            foreach (DrawContent content in drawContent)
            {
                content.Compile();
            }
        }
    }
}