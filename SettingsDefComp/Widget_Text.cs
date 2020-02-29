using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Widget_Text : DesignBase
    {
        public GameFont fontSize = GameFont.Small;
        public string text;

        public override void SetSize(List<float> width, List<float> height)
        {
            if (!text.NullOrEmpty())
            {
                if (this.width <= 0f)
                {
                    this.width = Text.CalcSize(text).x;
                }
                if (this.height <= 0f)
                {
                    this.height = Text.CalcSize(text).y;
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
