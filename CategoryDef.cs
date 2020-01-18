using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Tools;
using ToolBox.SettingsComp;
using Verse;
using UnityEngine;
using RimWorld;
using ToolBox.Core;

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

        public void Check()
        {
            string missingProp = "";
            bool hasLabel = label != null && label.Length != 0;
            bool hasLevel = level != 0;
            bool hasMissing = !hasLabel || !hasLevel;
            if (!hasLabel)
            {
                missingProp.Concat("<label>, ");
            }
            if (!hasLevel)
            {
                missingProp.Concat("<level>, ");
            }
            if (hasMissing)
            {
                //missingProp.Remove(missingProp.Count() - 2, 2);
                throw new HasMissingException("");
            }
        }

        public bool HasLabel
        {
            get
            {
                if (label != null)
                {
                    return label.Length != 0;
                }
                return label != null;
            }
        }

        public bool HasLevel 
        { 
            get 
            {
               return level != 0;
            } 
        }

        public bool HasMissing
        {
            get
            {
                if (!HasLabel || !HasLevel)
                {
                    return true;
                }
                return false; 
            }
        }

        public string GetMissing
        {
            get 
            {
                string textList = "";
                if (!HasLabel)
                {
                    textList += "<label>, ";
                }
                if (!HasLevel) 
                {
                    textList += "<level>, ";
                }
                return textList.Remove(textList.Count() - 2, 2);
            }
        }

        public int GetMissingCount 
        {
            get 
            {
                int count = 0;
                bool[] flagList = new bool[] {HasLabel, HasLevel};
                foreach (bool flag in flagList) 
                {
                    if (!flag) { count++; }
                }
                return count;
            }
        }

        public bool HasListID 
        {
            get 
            {
                int count = 0;
                if (!drawContent.NullOrEmpty())
                {
                    foreach (bool HasListID in drawContent.Select(c => !c.HasListID))
                    {
                        if (HasListID)
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        
        public int MissingListID 
        {
            get 
            {
                int count = 0;
                if (!drawContent.NullOrEmpty())
                {
                    foreach (bool HasListID in drawContent.Select(c => !c.HasListID))
                    {
                        if (HasListID)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        //Do a select many on the ToolBox instead of having to foreach drawContent.
        public void Constant()
        {
            if (!drawContent.NullOrEmpty())
            {
                foreach (Container container in drawContent)
                {
                    container.Initialize();
                }
            }
        }

        public void Content(Rect rect, Rect rectView) 
        {
            if (!drawContent.NullOrEmpty())
            {
                foreach (Container container in drawContent)
                {
                    container.Compile();
                }
            }
        }

        public static CategoryDef Named(string defName)
        {
            return DefDatabase<CategoryDef>.GetNamed(defName, true);
        }
    }
}
