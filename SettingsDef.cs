using System.Collections.Generic;
using ToolBox.SettingsDefComp;
using Verse;
using UnityEngine;

namespace ToolBox
{
    public class SettingsDef : Def
    {
        //Adjustable height and width
        public float position = 0;
        public CategoryLevel level = 0;
        public bool horiScrollbar = false;
        public bool vertiScrollbar = false;
        public List<Container> drawContent = new List<Container>();

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

        public virtual void PreLoad()
        {
            foreach (Container container in drawContent)
            {
                container.LoadBase();
            }
        }

        public virtual void Reload()
        {
            foreach (Container container in drawContent)
            {
                container.LoadData();
            }
        }

        public virtual void Display(Rect rect, Rect rectView) 
        {
            foreach (Container container in drawContent)
            {
                container.LoadWidgets();
            }
        }
    }
}