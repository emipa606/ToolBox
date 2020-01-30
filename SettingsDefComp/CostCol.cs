using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class CostCol : BaseProp
    {
        public new string header = "Cost";
        public new float headerPos = 0;
        public float min = 1;
        public float max = 9999;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.Header();
        }
    }
}
