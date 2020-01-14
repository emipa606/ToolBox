using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ToolBox.Tools
{
    public static class DrawInline
    {
        //Inline is 24 * Y
        public static void Label(float x, float y, float width, string label, float textWidth)
        {
            Color color = new Color(105f, 105f, 105f, 0.5f);
            Vector2 vectTop = new Vector2(x, y + 20f);
            Vector2 vectBottom = new Vector2(x + width, y + 20f);
            Rect box = new Rect(((width - textWidth) / 2f) + x, y, textWidth, 22f);
            Widgets.Label(box, label);
            Widgets.DrawLine(vectTop, vectBottom, color, 1f);
        }

        public static void UnderlinedLabel(float x, float y, float width, string label, float textWidth)
        {
            Color color = new Color(105f, 105f, 105f, 0.5f);
            Vector2 vectTop = new Vector2(x, y + 20f);
            Vector2 vectBottom = new Vector2(x + width, y + 20f);
            Rect box = new Rect(((width - textWidth) / 2f) + x, y, textWidth, 22f);
            Widgets.Label(box, label);
            Widgets.DrawLine(vectTop, vectBottom, color, 1f);
        }

        public static Rect Rect(float line, float x, float width, float height = 22f)
        {
            Rect box = new Rect(x, 24f * line, width, height);
            return box;
        }

        public static void DropDownButton(float line, float x, float width, float height, Dictionary<string, int> options, string optionDefault, List<int> itemData, int index)
        {
            List<FloatMenuOption> DropDownOptions = new List<FloatMenuOption>();
            foreach (KeyValuePair<string, int> Options in options)
            {
                DropDownOptions.Add(new FloatMenuOption(Options.Key, delegate () { itemData[index] = Options.Value; }));
                if (itemData[index] == Options.Value)
                {
                    optionDefault = Options.Key;
                }
            }

            if (Widgets.ButtonText(Rect(line, x, width, height), optionDefault))
            {
                FloatMenu floatMenu = new FloatMenu(DropDownOptions)
                {
                    vanishIfMouseDistant = true
                };
                Find.WindowStack.Add(floatMenu);
            }
        }

        public static void SwitchButton(float line, float x, float width, float height, string firstCase, string secondCase, List<bool> itemData, int index)
        {
            switch (itemData[index])
            {
                default:

                    if (Widgets.ButtonText(Rect(line, x, width, height), secondCase))
                    {
                        itemData[index] = true;
                    }
                    Widgets.DrawBoxSolid(Rect(line, x, width, height), new Color(0.60f, 0f, 0f, 0.35f));
                    break;
                case true:
                    if (Widgets.ButtonText(Rect(line, x, width, height), firstCase))
                    {
                        itemData[index] = false;
                    }
                    Widgets.DrawBoxSolid(Rect(line, x, width, height), new Color(0f, 0.55f, 0f, 0.35f));
                    break;
            }
        }

        public static void NumericField(float line, float width, float height, List<string> buffer, List<int> value, int index, int charCount, int valLimit)
        {
            //ToolHandle.SetIntBuffer(buffer, value, index);
            //value[index] = ToolHandle.SortToInt(Widgets.TextField(Rect(index + line, width, height), buffer[index]), charCount, valLimit);
        }
    }
}
