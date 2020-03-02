using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace ToolBox.SettingsDefComp
{
    public class Textbox : DesignBase
    {
        public float topMargin = 5f;
        public float leftMargin = 6f;
        public List<Textbox_Text> text = new List<Textbox_Text>();
        public List<Textbox_Image> image = new List<Textbox_Image>();

        public void Widget() 
        {
            if (width > 0f && height > 0f)
            {
                Widgets.DrawMenuSection(new Rect(x, y, width, height));
                text.ForEach(x => x.Content(this));
                image.ForEach(x => x.Content(this));
            }
        }
    }
}
