using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Widget_Image : DesignBase
    {
        public string path;
        public float scale = 1f;
        public Texture2D texture;

        public override void SetSize(List<float> width, List<float> height)
        {
            texture = ContentFinder<Texture2D>.Get(path);
            if (!texture.NullOrBad())
            {
                if (this.width <= 0f)
                {
                    this.width = texture.width;
                }
                if (this.height <= 0f)
                {
                    this.height = texture.height;
                }
            }
            base.SetSize(width, height);
        }

        public virtual void Widget() 
        {
            if (!texture.NullOrBad())
            {
                Widgets.DrawTextureFitted(new Rect(x, y, width, height), texture, scale);
            }
        }
    }
}
