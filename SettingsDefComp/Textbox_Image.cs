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
                if (x < 0f) { x = 0; }
                if (y < 0f) { y = 0; }
                if (width <= 0f)
                {
                    width = texture.width;
                }
                if ((Math.Abs(textBox.leftMargin - textBox.width - x) < width) || (width <= 0f))
                {
                    width = Math.Abs(textBox.leftMargin - textBox.width - x);
                }

                if (height <= 0f)
                {
                    height = texture.height;
                }
                if ((Math.Abs(textBox.topMargin - textBox.height - y) < height) || (height <= 0f))
                {
                    height = Math.Abs(textBox.topMargin - textBox.height - y);
                }
                Rect rect = new Rect(
                    x + textBox.x + textBox.leftMargin,
                    y + textBox.y + textBox.topMargin,
                    width,
                    height);
                Widgets.DrawTextureFitted(
                    rect,
                    texture,
                    scale,
                    new Vector2(rect.x, rect.y), 
                    new Rect(0f, 0f, 1f, 1f));
                Log.ErrorOnce($"width: {rect.width}, height: {rect.height}", 1);
            }
        }
    }
}
