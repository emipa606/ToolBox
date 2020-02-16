using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class ColPropBase  : ColBase
    {
        public bool draw = false;
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0f;
        public float vertLine = 0f;

        public virtual void Header() 
        {
            if (draw)
            {
                if (hasHeader)
                {
                    Construct.UnderlinedLabel(x, y, width, headerPos, header);
                    if (vertLine != (y + 24f))
                    {
                        vertLine = y + 24f;
                    }
                }
                else
                {
                    vertLine = y;
                }
            }
        }
    }
}
