using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Textbox : DesignBase
{
    public List<Textbox_Image> image = new List<Textbox_Image>();
    public List<Textbox_Label> label = new List<Textbox_Label>();
    public float leftMargin = 6f;
    public List<Textbox_Line> line = new List<Textbox_Line>();
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