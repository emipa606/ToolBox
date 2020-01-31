namespace ToolBox.SettingsDefComp
{
    public class BaseHPCol : BaseProp
    {
        public new string header = "HP";
        public new float headerPos = 8.5f;
        public new float width = 40f;
        public float min = 1f;
        public float max = 9999f;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
