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
                if ((Math.Abs(textBox.leftMargin - textBox.width - x) < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.leftMargin - textBox.width - x);
                }
                if ((Math.Abs(textBox.topMargin - textBox.height - y) < height) || (height <= 0f))
                {
                    height = Math.Abs(textBox.topMargin - textBox.height - y);
                }
                Text.Font = fontSize;
                Widgets.Label(new Rect(
                    x + textBox.x + textBox.leftMargin,
                    y + textBox.y + textBox.topMargin,
                    width,
                    height),
                    text);
            }
        }
    }
}
