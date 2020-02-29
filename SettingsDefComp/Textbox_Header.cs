using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Textbox_Header : TextboxCompBase
    {
        public GameFont fontSize = GameFont.Medium;
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
