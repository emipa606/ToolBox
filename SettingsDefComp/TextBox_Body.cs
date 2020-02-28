﻿using System;
using ToolBox.Tools;
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
                Text.Font = fontSize;
                Widgets.Label(ToolHandle.SetWrapedRect(x, y, width, height, textBox), text);
            }
        }
    }
}
