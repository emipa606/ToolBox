using System;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Label : ContentBase
    {
        public GameFont fontSize = GameFont.Small;
        public string text;
        public bool center = false;

        public void Content(Textbox textBox) 
        {
            if (!text.NullOrEmpty())
            {
                //Center only works for small text as it is the only one that gives an accurate width using CalcSize.
                //Note: still under work. 
                if (center && fontSize == GameFont.Small && width <= 0f)
                {
                    x = (Math.Abs(textBox.width - Text.CalcSize(text).x)) / 2f;
                }

                Text.Font = fontSize;
                Widgets.Label(ToolHandle.SetWrapedRect(x, y, width, height, textBox), text);
            }
        }
    }
}
