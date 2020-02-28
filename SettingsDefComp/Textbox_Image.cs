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

        public void Content(Textbox textBox)
        {
            Texture2D texture = ContentFinder<Texture2D>.Get(path);
            if (!texture.NullOrBad())
            {
                Rect rect = ToolHandle.SetWrapedRect(x, y, width, height, textBox);
                float cordWidth = float.Parse("0" + width.ToString());
                Widgets.DrawTextureFitted(
                    rect, texture, scale,
                    new Vector2(rect.width, rect.height), 
                    new Rect(0f, 0f, width, height * 0f));
                Log.ErrorOnce($"width: {rect.width}, height: {rect.height}", 1);
            }
        }
    }
}
