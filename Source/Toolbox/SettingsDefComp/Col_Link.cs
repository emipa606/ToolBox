using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Link : ColPropBase
{
    public IList<LinkFlags> linkOptions = new List<LinkFlags>
    {
        LinkFlags.None,
        LinkFlags.MapEdge,
        LinkFlags.Wall,
        LinkFlags.Rock,
        LinkFlags.Sandbags,
        LinkFlags.Barricades,
        LinkFlags.PowerConduit,
        LinkFlags.Custom1,
        LinkFlags.Custom2,
        LinkFlags.Custom3,
        LinkFlags.Custom4,
        LinkFlags.Custom5,
        LinkFlags.Custom6,
        LinkFlags.Custom7,
        LinkFlags.Custom8,
        LinkFlags.Custom9,
        LinkFlags.Custom10
    };

    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Link";
            headerPos = 24.5f;
            this.width = 75f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        var linkable = ThingDef.Named(thing.defName).graphicData.Linked;
        if (thing.linkProp.load && draw && linkable)
        {
            thing.linkProp.Preset(thing.defName);
            var F = thing.linkProp.optionDefault[0];
            if (F is > LinkFlags.Barricades and < LinkFlags.Custom1 or > LinkFlags.Custom10)
            {
                linkOptions.Add(thing.linkProp.optionDefault[0]);
            }
        }

        if (thing.linkProp.load || !draw || !linkable)
        {
            return;
        }

        if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f),
                thing.linkProp.option.ToString()))
        {
            var list = new List<FloatMenuOption>();
            foreach (var options in linkOptions)
            {
                list.Add(new FloatMenuOption(options.ToString(),
                    delegate
                    {
                        ThingDef.Named(thing.defName).graphicData.linkFlags = thing.linkProp.option = options;
                    }));
            }

            Find.WindowStack.Add(new FloatMenu(list));
        }

        thing.linkProp.CheckConfig();
    }
}