using System;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Body : ContentBase
    {
        public GameFont fontSize = GameFont.Small;
        public string text;

        public void Content(Textbox textBox) 
        {
            if (!text.NullOrEmpty())
            {
                if ((Math.Abs(textBox.width - x - textBox.leftMargin) < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.width - x - textBox.leftMargin);
                }
                if ((Math.Abs(textBox.height - y - textBox.topMargin) < height) || (height <= 0f))
                {
                    height = Math.Abs(textBox.height - y - textBox.topMargin);
                }
                Text.Font = fontSize;
                Widgets.Label(new Rect(
                        textBox.x + x + textBox.leftMargin,
                        textBox.y + y + textBox.topMargin,
                        width,
                        height),
                        text);
            }
        }
    }
}
