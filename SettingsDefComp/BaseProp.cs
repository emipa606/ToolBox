using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class BaseProp
    {
        public bool draw = false;
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float width = 0;
        public float x = 0;
        public float y = 0;
        public float vertLine = 0;

        public virtual void Header() 
        {
            if (draw)
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
}
