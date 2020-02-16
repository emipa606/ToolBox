namespace ToolBox.SettingsDefComp
{
    public class Col_Beauty : ColPropBase
    {
        public new string header = "Beauty";
        public new float headerPos = 2.2f;
        public new float width = 48.5f;
        public float min = -9999f;
        public float max = 99999f;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
