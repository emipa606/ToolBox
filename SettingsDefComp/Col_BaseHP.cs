namespace ToolBox.SettingsDefComp
{
    public class Col_BaseHP : ColPropBase
    {
        public new string header = "BaseHP";
        public new float headerPos = 2.2f;
        public new float width = 56f;
        public float min = 1f;
        public float max = 999999f;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
