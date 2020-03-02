using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Label : TextboxCompBase
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
