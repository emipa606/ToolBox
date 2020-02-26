using System.Collections.Generic;
using Verse;
using UnityEngine;

namespace ToolBox.SettingsDefComp
{
    public class Textbox : ContentBase
    {
        public float topMargin = 3.5f;
        public float leftMargin = 6f;
        public List<Textbox_Header> textHeader = new List<Textbox_Header>();
        public List<Textbox_Body> textBody = new List<Textbox_Body>();
        public List<Textbox_Image> image = new List<Textbox_Image>();

        public void Widget() 
        {
            if (width > 0f && height > 0f)
            {
                Widgets.DrawMenuSection(new Rect(x, y, width, height));
                textBody.ForEach(x => x.Content(this));
                textHeader.ForEach(x => x.Content(this));
                image.ForEach(x => x.Content(this));
            }
        }

        public virtual void SetSize(List<float> width, List<float> height)
        {
            if ((this.width > 0f) || (this.height > 0f))
            {
                width.Add(x + this.width + 1f);
                height.Add(y + this.height + 1f);
            }
        }
    }
}
