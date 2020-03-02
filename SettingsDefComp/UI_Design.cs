using System.Collections.Generic;
using System.Linq;

namespace ToolBox.SettingsDefComp
{
    public class UI_Design
    {
        public List<Textbox> textBox = new List<Textbox>();
        public List<Widget_Text> text = new List<Widget_Text>();
        public List<Widget_Image> image = new List<Widget_Image>();
        public float width = 0;
        public float height = 0;

        //Gets the highest width and height of the loaded widgets and sets it to the DrawMisc's width and height.
        public void CalcSize(List<float> widthList, List<float> heightList) 
        {
            List<float> width = new List<float>() { 0 };
            List<float> height = new List<float>() { 0 };
            textBox.ForEach(x => x.SetSize(width, height));
            text.ForEach(x => x.SetSize(width, height));
            image.ForEach(x => x.SetSize(width, height));

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

        //Loads all the drawn Widgets of DrawMisc
        public void CompileWidgets() 
        {
            textBox.ForEach(x => x.Widget());
            text.ForEach(x => x.Widget());
            image.ForEach(x => x.Widget());
        }
    }
}
