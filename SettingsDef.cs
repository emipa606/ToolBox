using System.Collections.Generic;
using Verse;
using ToolBox.SettingsDefComp;

namespace ToolBox
{
    public class SettingsDef : Def
    {
        //Adjustable height and width
        public float position = 0;
        public CategoryLevel level = 0;
        public bool scrollbar = true;
        public float width = 0;
        public float height = 0;
        public List<DrawContent> drawContent = new List<DrawContent>();

        public static SettingsDef Named(string defName)
        {
            return DefDatabase<SettingsDef>.GetNamed(defName, true);
        }

        public override IEnumerable<string> ConfigErrors()
        {
            if (level == 0)
            {
                yield return "CategoryDef is missing a level.";
            }
            yield break;
        }

        public void DrawSize() 
        {
            foreach (DrawContent content in drawContent)
            {
                content.AdaptSize();
            }
        }

        public void LoadBaseValue() 
        {
            foreach (DrawContent content in drawContent)
            {
                content.CompileBaseValue();
            }
        }

        public void Display() 
        {
            foreach (DrawContent content in drawContent)
            {
                content.CompileWidgets();
            }
        }
    }
}