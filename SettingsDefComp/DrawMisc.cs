using System.Collections.Generic;
using System.Linq;

namespace ToolBox.SettingsDefComp
{
    public class DrawMisc
    {
        public List<Textbox> textBox = new List<Textbox>();
        public float width = 0;
        public float height = 0;

        public void CalcSize(List<float> widthList, List<float> heightList) 
        {
            List<float> width = new List<float>() { 0 };
            List<float> height = new List<float>() { 0 };
            foreach (Textbox box in textBox)
            {
                box.SetSize(width, height);
            }

            //Chooses if wider than the set width
            if (this.width > width.Max())
            {
                widthList.Add(this.width);
            }
            else
            {
                widthList.Add(width.Max());
            }

            //Chooses if higher than the set height
            if (this.height > height.Max())
            {
                heightList.Add(this.height);
            }
            else
            {
                heightList.Add(height.Max());
            }
        }

        public void CompileWidgets() 
        {
            foreach (Textbox box in textBox)
            {
                box.Widget();
            }
        }
    }
}
