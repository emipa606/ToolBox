using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Roof : ColPropBase
    {
        public override void Header()
        {
            if (drawDefault)
            {
                header = "Roof";
                headerPos = 24.5f;
                width = 75f;
            }
            base.Header();
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.roofProp.load && draw)
            {
                thing.roofProp.Preset(thing.defName);
            }
            if (!thing.roofProp.load && draw)
            {
                Roofing roofing = new Roofing(ThingDef.Named(thing.defName));
                if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f), thing.roofProp.option.ToString()))
                {
                    bool a;
                    bool b;
                    switch (thing.roofProp.option)
                    {
                        case RoofMode.Auto:
                            thing.roofProp.option = RoofMode.Manual;
                            a = ThingDef.Named(thing.defName).holdsRoof = true;
                            b =ThingDef.Named(thing.defName).building.allowAutoroof = false;
                            Log.Error($"holdsRoof is {a}");
                            Log.Error($"allowsAutoRoof is {b}");
                            break;
                        case RoofMode.Manual:
                            thing.roofProp.option = RoofMode.None;
                            a = ThingDef.Named(thing.defName).holdsRoof = false;
                            b = ThingDef.Named(thing.defName).building.allowAutoroof = false;
                            Log.Error($"holdsRoof is {a}");
                            Log.Error($"allowsAutoRoof is {b}");
                            break;
                        case RoofMode.None:
                            if (roofing.IsDoor || roofing.IsImpassable)
                            {
                                thing.roofProp.option = RoofMode.Auto;
                                a = ThingDef.Named(thing.defName).holdsRoof = true;
                                b = ThingDef.Named(thing.defName).building.allowAutoroof = true;
                            }
                            else
                            {
                                thing.roofProp.option = RoofMode.Manual;
                                a = ThingDef.Named(thing.defName).holdsRoof = true;
                                b = ThingDef.Named(thing.defName).building.allowAutoroof = false;
                            }
                            Log.Error($"holdsRoof is {a}");
                            Log.Error($"allowsAutoRoof is {b}");
                            break;
                    }
                }
                if (thing.roofProp.option == RoofMode.Auto && !roofing.IsDoor && !roofing.IsImpassable)
                {
                    thing.roofProp.option = RoofMode.Manual;
                }
                thing.roofProp.CheckConfig();
            }
            //Place a check if it is a door or impassable to live update label.
        }
    }
}
