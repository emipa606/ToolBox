using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Textbox : DesignBase
{
    public readonly List<Textbox_Image> image = [];
    public readonly List<Textbox_Label> label = [];
    public readonly List<Textbox_Line> line = [];
    public float leftMargin = 6f;
    public float topMargin = 5f;

    public void Widget()
    {
        if (!(width > 0f) || !(height > 0f))
        {
            return;
        }

        Widgets.DrawMenuSection(new Rect(x, y, width, height));
        label.ForEach(textboxLabel => textboxLabel.Content(this));
        image.ForEach(textboxImage => textboxImage.Content(this));
        line.ForEach(textboxLine => textboxLine.Content(this));
    }
}