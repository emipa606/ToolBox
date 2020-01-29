using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsDefComp;
using UnityEngine;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBox : Mod
    {
        public ToolBoxSettings settings;
        private Vector2 categoryScroll = new Vector2(0f, 0f);
        private Vector2 contentScroll = new Vector2(0f, 0f);
        private Vector2 topHoriLine = new Vector2(168f, 40f);
        private Vector2 bottomHoriLine = new Vector2(168f, 600f);
        private Color lineColor = new Color(105f, 105f, 105f, 0.5f);
        private Listing_Standard listing_Category = new Listing_Standard();
        private Listing_Standard listing_Content = new Listing_Standard();
        private IEnumerable<SettingsDef> settingsDef_Enum = DefDatabase<SettingsDef>.AllDefs.OrderBy(c => c.position);
        private string settingsDef_Flag = "Home";
        
        public override string SettingsCategory() => "ToolBox";

        public ToolBox(ModContentPack content) : base(content)
        {
            settings = GetSettings<ToolBoxSettings>();
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            float contentViewHeight = rect.height;
            //if (categoryFlag.Equals("Fences")){ contentViewHeight = 600f; }
            Rect categoryRect = new Rect(rect.x, rect.y, rect.width / 5f, rect.height);//172.8 width
            Rect categoryView = new Rect(rect.x, rect.y, categoryRect.width - 25f, rect.height);
            Rect contentRect = new Rect(categoryRect.width + 5f, rect.y, (rect.width - categoryRect.width) - 5f, rect.height);
            Rect contentView = new Rect(contentRect.x, rect.y, contentRect.width - 25f, contentViewHeight);
            bool hasTop = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Top)).Count() != 0;
            bool hasMiddle = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Middle)).Count() != 0;
            bool hasBottom = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Bottom)).Count() != 0;
            bool drawSeparator = true;

            /* Note:
             * -Resizing category rect goes out of bounds. Try removing listing_Content and see if
             * ScrollView has its own rect. If it doesn't find a way to fix rect resize to fit new
             * UI objects.
             * 
             * To Do:
             * -Make the drawContent adjustable.
             * -Do the other inputs.
             */

            //CategoryRect Resize
            float categorRectHeight = 0f;
            if (hasTop) { categorRectHeight += 10f; }
            if (hasMiddle) { categorRectHeight += 10f; }
            if (hasBottom) { categorRectHeight += 10f; }
            if (categorRectHeight + (settingsDef_Enum.Count() * 32f) > categoryRect.height) 
            {
                drawSeparator = false;
                categoryView.height = categorRectHeight + (settingsDef_Enum.Count() * 32f);
                categoryRect.height = categorRectHeight + (settingsDef_Enum.Count() * 32f) - 1f;
            }

            //Category Sect.
            Widgets.BeginScrollView(categoryRect, ref categoryScroll, categoryView, true);
            listing_Category.Begin(categoryRect);
            listing_Category.ColumnWidth = categoryRect.width - 15.5f;
            foreach (SettingsDef topCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Top)))
            {
                if (listing_Category.ButtonText(topCategory.label))
                {
                    settingsDef_Flag = topCategory.defName;
                }
            }
            if(hasTop && (hasMiddle || hasBottom)) //Divider under Top level
            {
                listing_Category.GapLine(5f);
                listing_Category.Gap(5f);
            }
            foreach (SettingsDef middleCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Middle))) 
            {
                if (listing_Category.ButtonText(middleCategory.label))
                {
                    settingsDef_Flag = middleCategory.defName;
                }
            }
            if (hasMiddle && hasBottom) //Divider under Middle level
            {
                listing_Category.GapLine(5f);
                listing_Category.Gap(5f);
            }
            foreach (SettingsDef bottomCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Bottom)))
            {
                if (listing_Category.ButtonText(bottomCategory.label))
                {
                    settingsDef_Flag = bottomCategory.defName;
                }
            }
            listing_Category.End();
            Widgets.EndScrollView();

            //Separator: Category and Content Divider
            if (drawSeparator)
            {
                Widgets.DrawLine(topHoriLine, bottomHoriLine, lineColor, 1f);
            }

            //Content Sect.
            Widgets.BeginScrollView(contentRect, ref contentScroll, contentView, true);
            listing_Content.Begin(contentRect);
            foreach (SettingsDef settingsDef in settingsDef_Enum) 
            {
                if (settingsDef.defName.Equals(settingsDef_Flag)) 
                {
                    settingsDef.Display();
                }
            }
            listing_Content.End();
            Widgets.EndScrollView();
        }

        public override void WriteSettings()
        {
            IEnumerable<ThingList> thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList));

            foreach (ThingList thing in thingList)
            {
                thing.DataCheck();
                //thing.costBuffer = ThingDef.Named(thing.defName).costStuffCount.ToString();
            }

            settings.thingList = DefDatabase<SettingsDef>.AllDefs //Gets configured things
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList
                .Where(x => x.config)))
                .ToList();

            settings.thingList = settings.thingList //Groups the thingList by defName to remove copies.
                .GroupBy(s => s.defName)
                .Select(g => g.First())
                .ToList();

            foreach (ThingList savedThing in thingList)
            {
                ThingDef.Named(savedThing.defName).costStuffCount = savedThing.cost;
            }

            base.WriteSettings();
        }

    }
}