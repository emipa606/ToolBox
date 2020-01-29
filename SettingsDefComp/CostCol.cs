using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class CostCol : BaseProp
    {
        public new string header = "Cost";
        public new float headerPos = 0;
        public float min = 0;
        public float max = 9999;
        public new float width = 0;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
