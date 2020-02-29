using System.Collections.Generic;
using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class ColPropBase  : ContentBase
    {
        public bool draw = false;
        public bool drawDefault = false;
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0f;
        public float vertLine = 0f;
        public float min = 0f;
        public float max = 0f;

        //Loads a label that acts as a header--also sets the value for (bool)draw.
        public virtual void Header() 
        {
            draw = width > 0f;
            if (hasHeader)
            {
                if (draw)
                {
                    Construct.UnderlinedLabel(x, y, width, headerPos, header);
                    vertLine = y + 24f;
                }            
            }
            else
            {
                vertLine = y;
            }
        }

        //Gets and adds the size of the Widget to the DrawProperties/DrawMisc height and width.
        public virtual void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if ((this.width > 0f) || (this.height > 0f) || drawDefault)
            {
                float colHeight = 0;
                if (hasHeader) { colHeight += multiplier; }
                width.Add(x + this.width);
                height.Add(y + this.height + (thingCount * multiplier) + colHeight);
            }
        }
    }
}
