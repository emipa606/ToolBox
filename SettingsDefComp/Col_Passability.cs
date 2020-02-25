using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Passability : ColPropBase
    {
        public IList<Traversability> passOptions = new List<Traversability>() 
        { 
            Traversability.Impassable,
            Traversability.PassThroughOnly,
            Traversability.Standable
        };

        public override void Header()
        {
            if (drawDefault)
            {
                header = "Passability";
                headerPos = 32.5f;
                width = 130f;
            }
            base.Header();
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.passabilityProp.load && draw)
            {
                thing.passabilityProp.Preset(thing.defName);
            }
            if (!thing.passabilityProp.load && draw)
            {
                if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f), thing.passabilityProp.option.ToString()))
                {
                    List<FloatMenuOption> list = new List<FloatMenuOption>();
                    foreach (Traversability options in passOptions)
                    {
                        list.Add(new FloatMenuOption(options.ToString(), delegate ()
                        {
                            ThingDef.Named(thing.defName).passability = thing.passabilityProp.option = options;
                        }));
                    }
                    Find.WindowStack.Add(new FloatMenu(list));
                }
                thing.passabilityProp.CheckConfig();
            }
        }
    }
}
