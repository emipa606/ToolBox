using System;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp;

public class Textbox_Label : ContentBase
{
    private readonly bool center = false;
    private readonly GameFont fontSize = GameFont.Small;
    public string text;

    public void Content(Textbox textBox)
    {
        if (text.NullOrEmpty())
        {
            return;
        }

        //Center only works for small text as it is the only one that gives an accurate width using CalcSize.
        //Note: still under work. 
        if (center && fontSize == GameFont.Small && width <= 0f)
        {
            x = Math.Abs(textBox.width - Text.CalcSize(text).x) / 2f;
        }

        Text.Font = fontSize;
        Widgets.Label(ToolHandle.SetWrappedRect(x, y, width, height, textBox), text);
    }
}