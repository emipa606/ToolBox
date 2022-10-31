using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

/// <summary>
///     Resets the Widgets of all the modified ThingProp values.
/// </summary>
public class ResetButton : ContentBase
{
    public bool drawDefault = false;
    public string label = "Reset";

    public virtual void Widget(List<ThingProp> thingList)
    {
        if (!(width > 0f) || !(height > 0f))
        {
            return;
        }

        if (!Widgets.ButtonText(new Rect(x, y, width, height), label))
        {
            return;
        }

        foreach (var thing in thingList.Where(t => t.live && t.config))
        {
            if (thing.costProp.config.Equals('1'))
            {
                thing.costProp.numBuffer = thing.costProp.numIntDefault[0].ToString();
            }

            if (thing.baseHPProp.config.Equals('1'))
            {
                thing.baseHPProp.numBuffer = thing.baseHPProp.numIntDefault[0].ToString();
            }

            if (thing.beautyProp.config.Equals('1'))
            {
                thing.beautyProp.numBuffer = thing.beautyProp.numIntDefault[0].ToString();
            }

            if (thing.fillProp.config.Equals('1'))
            {
                thing.fillProp.numBuffer = thing.fillProp.numIntDefault[0].ToString();
            }

            if (thing.pathProp.config.Equals('1'))
            {
                thing.pathProp.numBuffer = thing.pathProp.numIntDefault[0].ToString();
            }

            if (thing.workProp.config.Equals('1'))
            {
                thing.workProp.numBuffer = thing.workProp.numIntDefault[0].ToString();
            }

            if (thing.flammabilityProp.config.Equals('1'))
            {
                thing.flammabilityProp.numBuffer = thing.flammabilityProp.numIntDefault[0].ToString();
            }

            if (thing.passabilityProp.config.Equals('1'))
            {
                thing.passabilityProp.option = thing.passabilityProp.optionDefault[0];
            }

            if (thing.linkProp.config.Equals('1'))
            {
                thing.linkProp.option = thing.linkProp.optionDefault[0];
            }

            if (thing.roofProp.config.Equals('1'))
            {
                thing.roofProp.option = thing.roofProp.optionDefault[0];
            }

            if (thing.terrainProp.config.Equals('1'))
            {
                thing.terrainProp.option = thing.terrainProp.optionDefault[0];
            }
        }
    }

    public virtual void SetSize(List<float> width, List<float> height)
    {
        if (drawDefault)
        {
            this.height = 22f;
            this.width = 50f;
        }

        if (!(this.width > 0f) && !(this.height > 0f))
        {
            return;
        }

        width.Add(x + this.width + 1f);
        height.Add(y + this.height + 1f);
    }
}