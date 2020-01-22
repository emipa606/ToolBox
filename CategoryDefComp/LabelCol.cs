using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Tools;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class LabelCol : BaseCol
    {
        public override void Base()
        {
            vertLine = y;
        }

        public virtual void Header(ref float vertLine)
        {
            Construct.UnderlinedLabel(x, vertLine, width, headerPos, header);
            vertLine += 24f;
        }

        public virtual void Body(string label)
        {
            Construct.Label(x, vertLine, width, label);
            //vertLine += 24f;
        }

    }
}
