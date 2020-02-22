using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Cost : ColPropBase
    {
        public override void Header()
        {
            if (drawDefault)
            {
                header = "Cost";
                headerPos = 5f;
                width = 40f;
                min = 1f;
                max = 9999f;
            }
            base.Header();
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.costProp.load && draw)
            {
                thing.costProp.Preset(thing.defName);
            }
            if (!thing.costProp.load && draw)
            {
                Widgets.TextFieldNumeric(
                    new Rect(x, (24f * line) + vertLine, width, 22f), 
                    ref thing.costProp.numInt, 
                    ref thing.costProp.numBuffer, 
                    min, max);
                thing.costProp.CheckConfig();
                ThingDef.Named(thing.defName).costStuffCount = thing.costProp.numInt;
            }
        }
    }
}
