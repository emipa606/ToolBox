﻿using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsDefComp;
using UnityEngine;
using Verse;

namespace ToolBox;

public class SettingsDef : Def
{
    public readonly List<UI_Configurator> configurator = [];
    public readonly UI_Design design = new UI_Design();
    public readonly CategoryLevel level = CategoryLevel.Middle;
    public readonly float position = 0;
    public readonly bool scrollbar = true;
    public bool checkSize = true;
    public float height;
    public float width;

    public static SettingsDef Named(string defName)
    {
        return DefDatabase<SettingsDef>.GetNamed(defName);
    }

    public override IEnumerable<string> ConfigErrors()
    {
        if (level == 0)
        {
            yield return "CategoryDef is missing a level.";
        }
    }

    //Adapts the size of Rect container based on the size and position of all the drawn widgets.
    public void AdaptSize(ref Rect rect, ref Rect rectView, ref bool drawScrollbar)
    {
        if (checkSize)
        {
            drawScrollbar = scrollbar;
            var widths = new List<float> { 0 };
            var heights = new List<float> { 0 };
            configurator.ForEach(c => c.CalcSize(widths, heights));
            design.CalcSize(widths, heights);

            //Compares and takes the highest width and height of all the 
            if (widths.Max() > width)
            {
                width = widths.Max();
            }

            if (heights.Max() > width)
            {
                height = heights.Max();
            }

            checkSize = false;
        }

        //If the initialized size is higher than the calculated size, it will use the given size instead.
        if (width > rect.width)
        {
            rectView.width = width;
            rect.width = width;
            rectView.height -= 16f;
        }

        if (!(height > rect.height))
        {
            return;
        }

        rectView.height = height;
        rect.height = height;
    }

    //Gets all the compilation of widgets and is compiled again in Display for later calling in ToolBox
    public void Display()
    {
        configurator.ForEach(c => c.CompileWidgets());
        design.CompileWidgets();
    }
}