using Verse;
using UnityEngine;
using System;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Image : ContentBase
    {
        public string path;
        public float scale = 1f;

        public void Content(Textbox textBox)
        {
            Texture2D texture = ContentFinder<Texture2D>.Get(path);
            if (!texture.NullOrBad())
            {
                if (width <= 0f)
                {
                    width = texture.width;
                }
                if ((Math.Abs(textBox.width - x - textBox.leftMargin) < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.width - x - textBox.leftMargin);
                }


                if (height <= 0f)
                {
                    height = texture.height;
                }
                if ((Math.Abs(textBox.height - y - textBox.topMargin) < height) || (height <= 0f))
                {
                    height = Math.Abs(textBox.height - y - textBox.topMargin);
                }
                Rect rect = new Rect(
                    textBox.x + x + textBox.leftMargin,
                    textBox.y + y + textBox.topMargin,
                    width,
                    height);
                Widgets.DrawTextureFitted(
                    rect,
                    texture,
                    scale,
                    new Vector2(rect.x, 100f), 
                    new Rect(0f , 0f, 1f, 1f));
            }
        }
    }
}
