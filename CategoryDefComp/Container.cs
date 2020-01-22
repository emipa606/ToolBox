using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class Container : IExposable
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol;

        public void ExposeData()
        {

        }
    }
}
