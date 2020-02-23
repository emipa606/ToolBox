using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ThingPropSelect : ThingPropBase, IExposable
    {
        public char config = '0';

        public virtual void ExposeData()
        {
        }

        public virtual void Preset(string defName)
        {
            load = false;
        }

        public virtual void CheckConfig()
        {
        }

    }
}
