using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsComp;
using Verse;
using UnityEngine;
using ToolBox.ExceptionHandle;

namespace ToolBox
{
    public class CategoryDef : Def
    {
        //Adjustable height and width
        public float position = 0;
        public CategoryLevel level = 0;
        public bool horiScrollbar = false;
        public bool vertiScrollbar = false;
        public List<Container> drawContent = new List<Container>();

        public static CategoryDef Named(string defName)
        {
            return DefDatabase<CategoryDef>.GetNamed(defName, true);
        }

        public virtual void CheckMissing()
        {
            string prop = "";
            int count = 0;
            bool hasLevel = level != 0;
            if (!hasLevel)
            {
                prop += "level";
            }
            if (!drawContent.NullOrEmpty())
            {
                foreach (bool flag in drawContent.Select(c => !c.HasListID))
                {
                    if (flag)
                    {
                        count++;
                    }
                }
            }
            if (count > 0 || !hasLevel)
            {
                throw new HasMissingException(prop, count);
            }
        }

        public virtual void Constant()
        {
            if (!drawContent.NullOrEmpty())
            {
                foreach (Container container in drawContent)
                {
                    container.Initialize();
                }
            }
        }

        public virtual void Content(Rect rect, Rect rectView) 
        {
            if (!drawContent.NullOrEmpty())
            {
                foreach (Container container in drawContent)
                {
                    container.Compile();
                }
            }
        }
    }
}