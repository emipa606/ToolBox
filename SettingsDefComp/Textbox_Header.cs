using System;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Header : ContentBase
    {
        public GameFont fontSize = GameFont.Medium;
        public string text;

        public void Content(Textbox textBox)
        {
            if (!text.NullOrEmpty())
            {
                if (x < 0f) { x = 0f; }
                if (y < 0f) { y = 0f; }
                if ((Math.Abs(textBox.width - x - textBox.leftMargin) < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.width - x - textBox.leftMargin);
                    Log.Error(width.ToString());
                }
                if ((Math.Abs(textBox.topMargin - textBox.height - y) < height) || (height <= 0f))
                {
                    Log.Error("Y");
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
