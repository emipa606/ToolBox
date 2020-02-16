namespace ToolBox.SettingsDefComp
{
    public class Col_Fill : ColPropBase
    {
        public new string header = "Fill";
        public new float headerPos = 5.5f;
        public new float width = 31f;
        public float min = 0;
        public float max = 100;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
