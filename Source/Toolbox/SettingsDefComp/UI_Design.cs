﻿using System.Collections.Generic;
using System.Linq;

namespace ToolBox.SettingsDefComp;

public class UI_Design
{
    private readonly float height = 0;
    private readonly List<Widget_Image> image = [];
    private readonly List<Widget_Label> label = [];
    private readonly List<Widget_Line> line = [];
    private readonly List<Textbox> textBox = [];
    private readonly float width = 0;

    //Gets the highest width and height of the loaded widgets and sets it to the DrawMisc's width and height.
    public void CalcSize(List<float> widthList, List<float> heightList)
    {
        var widths = new List<float> { 0 };
        var heights = new List<float> { 0 };
        textBox.ForEach(x => x.SetSize(widths, heights));
        label.ForEach(x => x.SetSize(widths, heights));
        image.ForEach(x => x.SetSize(widths, heights));
        line.ForEach(x => x.SetSize(widths, heights));

        //Chooses if wider than the set width
        widthList.Add(width > widths.Max() ? width : widths.Max());

        //Chooses if higher than the set height
        heightList.Add(height > heights.Max() ? height : heights.Max());
    }

    //Loads all the drawn Widgets of DrawMisc
    public void CompileWidgets()
    {
        textBox.ForEach(x => x.Widget());
        label.ForEach(x => x.Widget());
        image.ForEach(x => x.Widget());
        line.ForEach(x => x.Widget());
    }
}