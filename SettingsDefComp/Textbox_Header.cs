using System;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Header : ContentBase
    {
        public GameFont fontSize = GameFont.Medium;
        public string text;

        //fix width & height
        public void Content(Textbox textBox)
        {
            Text.Font = fontSize;
            Widgets.Label(new Rect(
                    textBox.x + x + textBox.leftMargin,
                    textBox.y + y + textBox.topMargin,
                    Math.Abs(textBox.width - x - textBox.leftMargin),
                    Math.Abs(textBox.height - y - textBox.topMargin)),
                    text);
        }
    }
}
