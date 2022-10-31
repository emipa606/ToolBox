using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Passability : ColPropBase
{
    private Color color;

    private Rect overlay;

    public IList<Traversability> passOptions = new List<Traversability>
    {
        Traversability.Impassable,
        Traversability.PassThroughOnly,
        Traversability.Standable
    };

    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Passability";
            headerPos = 32.5f;
            this.width = 130f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        if (thing.passabilityProp.load && draw)
        {
            thing.passabilityProp.Preset(thing.defName);
        }

        if (thing.passabilityProp.load || !draw)
        {
            return;
        }

        if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f),
                thing.passabilityProp.option.ToString()))
        {
            var list = new List<FloatMenuOption>();
            foreach (var options in passOptions)
            {
                list.Add(new FloatMenuOption(options.ToString(),
                    delegate { ThingDef.Named(thing.defName).passability = thing.passabilityProp.option = options; }));
            }

            Find.WindowStack.Add(new FloatMenu(list));
        }

        switch (thing.passabilityProp.option)
        {
            case Traversability.Standable:
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0f, 0.55f, 0f, 0.35f);
                break;
            case Traversability.PassThroughOnly:
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0.35f, 0.35f, 0.35f, 0.35f);
                break;
            case Traversability.Impassable:
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0.60f, 0f, 0f, 0.35f);
                break;
        }

        Widgets.DrawBoxSolid(overlay, color);
        thing.passabilityProp.CheckConfig();
    }
}