using Verse;

namespace ToolBox.CategoryDefComp
{
    public class BaseCol : IExposable
    {
        public bool linked = false;
        public bool hasHeader = true;
        public string header = "null";
        public float headerPos = 0;
        public float x = 0;
        public float y = 0;
        public float width = 0;

        public virtual void ExposeData()
        {
        }
    }
}
