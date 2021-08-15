using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Col_Terrain : ColPropBase
    {
        private Color color;

        private Rect overlay;

        public IList<TerrainMode> terrainOptions = new List<TerrainMode>
        {
            TerrainMode.Light,
            TerrainMode.Medium,
            TerrainMode.Heavy
        };

        public override void SetSize(int thingCount, List<float> width, List<float> height, float multiplier)
        {
            if (drawDefault)
            {
                header = "Terrain";
                headerPos = 20.2f;
                this.width = 83f;
            }

            base.SetSize(thingCount, width, height, multiplier);
        }

        public void Widget(ThingProp thing, int line)
        {
            if (thing.terrainProp.load && draw)
            {
                thing.terrainProp.Preset(thing.defName);
            }

            if (thing.terrainProp.load || !draw)
            {
                return;
            }

            if (Widgets.ButtonText(new Rect(x, (24f * line) + vertLine, width, 22f),
                thing.terrainProp.option.ToString()))
            {
                var list = new List<FloatMenuOption>();
                foreach (var options in terrainOptions)
                {
                    list.Add(new FloatMenuOption(options.ToString(),
                        delegate { thing.terrainProp.option = options; }));
                }

                Find.WindowStack.Add(new FloatMenu(list));
            }

            switch (thing.terrainProp.option)
            {
                case TerrainMode.Light:
                    ThingDef.Named(thing.defName).terrainAffordanceNeeded = TerrainAffordanceDefOf.Light;
                    overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                    color = new Color(0f, 0.55f, 0f, 0.35f);
                    break;
                case TerrainMode.Medium:
                    ThingDef.Named(thing.defName).terrainAffordanceNeeded = TerrainAffordanceDefOf.Medium;
                    overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                    color = new Color(0.35f, 0.35f, 0.35f, 0.35f);
                    break;
                case TerrainMode.Heavy:
                    ThingDef.Named(thing.defName).terrainAffordanceNeeded = TerrainAffordanceDefOf.Heavy;
                    overlay = new Rect(x, (24f * line) + vertLine, width, 22f);
                    color = new Color(0.60f, 0f, 0f, 0.35f);
                    break;
            }

            Widgets.DrawBoxSolid(overlay, color);
            thing.terrainProp.CheckConfig();
        }
    }
}