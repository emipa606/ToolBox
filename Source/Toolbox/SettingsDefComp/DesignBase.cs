using System.Collections.Generic;

namespace ToolBox.SettingsDefComp
{
    public class DesignBase : ContentBase
    {
        //Gets and adds the size of the Widget to the DrawProperties/DrawMisc height and width.
        public virtual void SetSize(List<float> width, List<float> height)
        {
            if (!(this.width > 0f) && !(this.height > 0f))
            {
                return;
            }

            width.Add(x + this.width + 1f);
            height.Add(y + this.height + 1f);
        }
    }
}