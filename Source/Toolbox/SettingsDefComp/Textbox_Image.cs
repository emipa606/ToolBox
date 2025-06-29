using ToolBox.Tools;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Textbox_Image : TextboxCompBase
{
    private readonly float scale = 1f;
    public string path;

    public void Content(Textbox textBox)
    {
        var texture = ContentFinder<Texture2D>.Get(path);
        if (texture.NullOrBad())
        {
            return;
        }

        if (width <= 0f)
        {
            width = texture.width;
        }

        if (height <= 0f)
        {
            height = texture.height;
        }

        if (warn)
        {
            if (textBox.width - (textBox.leftMargin * 2f) - x < width)
            {
                Log.Error(
                    $"[ToolBox: WRN] Image \"{texture.name}\": hitting the left/right edge of the textBox.");
            }

            if (textBox.height - (textBox.topMargin * 2f) - x < height)
            {
                Log.Error(
                    $"[ToolBox: WRN] Image \"{texture.name}\": hitting the top/bottom edge of the textBox.");
            }

            warn = false;
        }

        var rect = ToolHandle.SetWrappedRect(x, y, width, height, textBox);
        Widgets.DrawTextureFitted(rect, texture, scale);
    }
}