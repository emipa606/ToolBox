using System.Collections.Generic;
using System.Linq;
using ToolBox.CategoryDefComp;
using Verse;
using UnityEngine;
using ToolBox.Tools;

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

        public override IEnumerable<string> ConfigErrors()
        {
            if (level == 0)
            {
                yield return $"[ToolBox : ERROR] CategoryDef {defName} is missing a position level.";
            }
            if (!drawContent.NullOrEmpty())
            {
                int count = 0;
                foreach (bool flag in drawContent.Select(c => !c.HasListID))
                {
                    if (flag)
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    yield return $"[ToolBox : ERROR] CategoryDef {defName} is missing a listID in {count} of its containers.";
                }
            }
            yield break;
        }

        public virtual void PreLoad()//Get an initializer and list all categorydef and get their preload
        {
            foreach (Container container in drawContent)
            {
                container.LoadBase();
            }
        }

        public virtual void Load()
        {
            foreach (Container container in drawContent)
            {
                container.LoadSubWidgets();
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