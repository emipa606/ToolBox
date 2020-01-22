using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class BaseCol : IExposable
    {
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float x = 0;
        public float y = 0;
        public float width = 0;

        public float vertLine = 0f;

        public virtual void ExposeData()
        {
        }

        public virtual void Base()
        {
        }
    }
}
