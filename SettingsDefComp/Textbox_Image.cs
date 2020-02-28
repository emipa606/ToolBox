using Verse;
using UnityEngine;
using System;
using ToolBox.Tools;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Image : ContentBase
    {
        public string path;
        public float scale = 1f;
        public bool warn = false;

        public void Content(Textbox textBox)
        {
            Texture2D texture = ContentFinder<Texture2D>.Get(path);
            if (!texture.NullOrBad())
            {
                if (width <= 0f)
                {
                    width = texture.width;
                }
                if (height <= 0f)
                {
                    height = texture.height;
                }
                Rect rect = ToolHandle.SetWrapedRect(this, textBox);
                Widgets.DrawTextureFitted(
                    rect, texture, scale);
            }
        }
    }
}
