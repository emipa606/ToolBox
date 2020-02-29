using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    //Note: adaptability to content Rect is quite inaccurate.
    //This is due to unknown multiplier used for Medium fonts.
    public class Widget_Header : DesignBase
    {
        public GameFont fontSize = GameFont.Medium;
        public string text;

        public override void SetSize(List<float> width, List<float> height)
        {
            if (!text.NullOrEmpty())
            {
                if (this.width <= 0f)
                {
                    this.width = Text.CalcSize(text).x * 1.534f;
                }
                if (this.height <= 0f)
                {
                    this.height = Text.CalcSize(text).y * 1.534f;
                }
            }
            base.SetSize(width, height);
        }

        public virtual void Widget()
        {
            if (!text.NullOrEmpty())
            {
                Text.Font = fontSize;
                Widgets.Label(new Rect(x, y, width, height), text);
            }
        }
    }
}
