using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

//Note: adaptability to content Rect is quite inaccurate.
//This is due to unknown multiplier used for Medium fonts.
public class Widget_Label : DesignBase
{
    private readonly GameFont fontSize = GameFont.Small;
    public string text;

    public override void SetSize(List<float> width, List<float> height)
    {
        if (!text.NullOrEmpty())
        {
            if (this.width <= 0f)
            {
                this.width = Text.CalcSize(text).x;
                if (fontSize == GameFont.Medium)
                {
                    this.width *= 1.534f;
                }
            }

            if (this.height <= 0f)
            {
                this.height = Text.CalcSize(text).y;
                if (fontSize == GameFont.Medium)
                {
                    this.width *= 1.534f;
                }
            }
        }

        base.SetSize(width, height);
    }

    public virtual void Widget()
    {
        if (text.NullOrEmpty())
        {
            return;
        }

        Text.Font = fontSize;
        Widgets.Label(new Rect(x, y, width, height), text);
    }
}