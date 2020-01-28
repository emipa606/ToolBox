using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Tools;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class LabelCol
    {
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float width = 0;
        public float x = 0;
        public float y = 0;
        public float vertLine = 0;

        public void Header() 
        {
            if (hasHeader)
            {
                Construct.UnderlinedLabel(x, y, width, headerPos, header);
                if (vertLine != (y + 24))
                {
                    vertLine = y + 24;
                }
            }
            else
            {
                vertLine = y;
            }
        }
    }
}
