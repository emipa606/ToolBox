using Verse;
using UnityEngine;
using System;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Image : ContentBase
    {
        public string path;
        public float scale;

        public void Content(Textbox textBox)
        {
            Texture2D texture = ContentFinder<Texture2D>.Get(path);

            if ((Math.Abs(textBox.width - x - textBox.leftMargin) < width) || (width <= 0f))
            {
                width = Math.Abs(textBox.width - x - textBox.leftMargin);
            }
            if ((Math.Abs(textBox.height - y - textBox.topMargin) < height) || (height <= 0f))
            {
                height = Math.Abs(textBox.height - y - textBox.topMargin);
            }
            Widgets.DrawTextureFitted(new Rect(
                textBox.x + x + textBox.leftMargin,
                    textBox.y + y + textBox.topMargin,
                    width,
                    height),
                    texture,
                    scale);
        }
    }
}
