using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Col_Roof : ColPropBase
{
    private readonly IList<RoofMode> modeListA = new List<RoofMode>
    {
        RoofMode.Auto,
        RoofMode.Manual,
        RoofMode.None
    };

    private readonly IList<RoofMode> modeListB = new List<RoofMode>
    {
        RoofMode.Manual,
        RoofMode.None
    };

    private Color color;

    private Rect overlay;

    public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
    {
        if (drawDefault)
        {
            header = "Roof";
            headerPos = 22.5f;
            this.width = 75f;
        }

        base.SetSize(thingCount, width, height, multiplier);
    }

    public void Widget(ThingProp thing, int line)
    {
        if (thing.roofProp.load && draw)
        {
            thing.roofProp.Preset(thing.defName);
        }

        if (thing.roofProp.load || !draw)
        {
            return;
        }

        var roofing = new Roofing(ThingDef.Named(thing.defName));
        IList<RoofMode> roofOptions;
        if (roofing.IsDoor || roofing.IsImpassable)
        {
            roofOptions = modeListA;
        }
        else
        {
            roofOptions = modeListB;
        }

        if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f),
                thing.roofProp.option.ToString()))
        {
            var list = new List<FloatMenuOption>();
            foreach (var options in roofOptions)
            {
                list.Add(new FloatMenuOption(options.ToString(),
                    delegate { thing.roofProp.option = options; }));
            }

            Find.WindowStack.Add(new FloatMenu(list));
        }

        switch (thing.roofProp.option)
        {
            case RoofMode.Auto:
                if (!roofing.IsDoor && !roofing.IsImpassable)
                {
                    thing.roofProp.option = RoofMode.Manual;
                }

                ThingDef.Named(thing.defName).holdsRoof = true;
                ThingDef.Named(thing.defName).building.allowAutoroof = true;
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0f, 0.55f, 0f, 0.35f);
                break;
            case RoofMode.Manual:
                ThingDef.Named(thing.defName).holdsRoof = true;
                ThingDef.Named(thing.defName).building.allowAutoroof = false;
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0.35f, 0.35f, 0.35f, 0.35f);
                break;
            case RoofMode.None:
                ThingDef.Named(thing.defName).holdsRoof = false;
                ThingDef.Named(thing.defName).building.allowAutoroof = false;
                overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                color = new Color(0.60f, 0f, 0f, 0.35f);
                break;
        }

        Widgets.DrawBoxSolid(overlay, color);
        thing.roofProp.CheckConfig();

        //Place a check if it is a door or impassable to live update label.
    }
}