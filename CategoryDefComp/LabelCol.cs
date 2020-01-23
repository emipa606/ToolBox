using System.Collections.Generic;
using ToolBox.Tools;

namespace ToolBox.CategoryDefComp
{
    public class LabelCol : BaseCol
    {

        public IList<string> label;

        public void Base(IList<string> defName)
        {
            label = defName;
        }

        public void Header(ref float vertLine)
        {
            if (linked && hasHeader)
            {
                Construct.UnderlinedLabel(x, vertLine, width, headerPos, header);
                vertLine += 24f;
            }
        }

        public void Body(ref float vertLine, int index)
        {
            if (linked)
            {
                Construct.Label(x, vertLine, width, label, index);
                vertLine += 24f;
            }
        }
    }
}
