using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class ResetButton
    {
        public bool drawDefault = false;
        public string label = "Reset";
        public float height;
        public float width;
        public float x;
        public float y;

        public virtual void Widget(List<ThingProp> thingList) 
        {
            if (drawDefault)
            {
                label = "Reset";
                height = 22f;
                width = 50f;
            }
            if ((width > 0f) && (height > 0f))
            {
                if (Widgets.ButtonText(new Rect(x, y, width, height), label))
                {
                    foreach (ThingProp thing in thingList.Where(t => t.live && t.config))
                    {
                        if (thing.costProp.config.Equals('1')) 
                        { thing.costProp.numBuffer = thing.costProp.numIntDefault[0].ToString(); }

                        if (thing.baseHPProp.config.Equals('1')) 
                        { thing.baseHPProp.numBuffer = thing.baseHPProp.numIntDefault[0].ToString(); }

                        if (thing.beautyProp.config.Equals('1')) 
                        { thing.beautyProp.numBuffer = thing.beautyProp.numIntDefault[0].ToString(); }

                        if (thing.fillProp.config.Equals('1')) 
                        { thing.fillProp.numBuffer = thing.fillProp.numIntDefault[0].ToString(); }

                        if (thing.pathProp.config.Equals('1'))
                        { thing.pathProp.numBuffer = thing.pathProp.numIntDefault[0].ToString(); }

                        if (thing.workProp.config.Equals('1'))
                        { thing.workProp.numBuffer = thing.workProp.numIntDefault[0].ToString(); }

                        if (thing.flammabilityProp.config.Equals('1'))
                        { thing.flammabilityProp.numBuffer = thing.flammabilityProp.numIntDefault[0].ToString(); }

                        if (thing.passabilityProp.config.Equals('1'))
                        { thing.passabilityProp.option = thing.passabilityProp.optionDefault[0]; }
                    }
                }
            }
        }
    }
}
