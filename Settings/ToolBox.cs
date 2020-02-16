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
        private Vector2 bottomHoriLine = new Vector2(168f, 623f);
        private Color lineColor = new Color(105f, 105f, 105f, 0.5f);
        private Listing_Standard listing_Category = new Listing_Standard();
        private Listing_Standard listing_Content = new Listing_Standard();
        private IEnumerable<SettingsDef> settingsDef_Enum = DefDatabase<SettingsDef>.AllDefs.OrderBy(c => c.position);
        private string settingsDef_Flag = "Default";
        
        public override string SettingsCategory() => "ToolBox";

        public ToolBox(ModContentPack content) : base(content)
        {
            settings = GetSettings<ToolBoxSettings>();
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            Rect categoryRect = new Rect(rect.x, rect.y, rect.width / 5f, rect.height);//172.8 width
            Rect categoryRectScroll = new Rect(rect.x, rect.y, rect.width / 5f, rect.height);
            Rect categoryView = new Rect(rect.x, rect.y, categoryRect.width - 25f, rect.height);
            Rect contentRect = new Rect(categoryRect.width + 5f, rect.y, (rect.width - categoryRect.width) - 5f, rect.height);
            Rect contentRectScroll = new Rect(categoryRect.width + 5f, rect.y, (rect.width - categoryRect.width) - 5f, rect.height);
            Rect contentView = new Rect(contentRect.x, rect.y, contentRect.width - 25f, rect.height);
            bool hasTop = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Top)).Count() != 0;
            bool hasMiddle = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Middle)).Count() != 0;
            bool hasBottom = settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Bottom)).Count() != 0;
            
            //This flags would matter once I make a ToolBox Home category.
            bool drawContentScroll = true;
            bool drawSeparator = true;

            /* 
             * To do:
             * -Do the other inputs.
             */

            //CategoryRect Resize
            float categorRectHeight = 0f;
            if (hasTop) { categorRectHeight += 10f; }
            if (hasMiddle) { categorRectHeight += 10f; }
            if (hasBottom) { categorRectHeight += 10f; }
            if (categorRectHeight + (settingsDef_Enum.Count() * 31.5f) > categoryRect.height) 
            {
                drawSeparator = false;
                categoryView.height = categorRectHeight + (settingsDef_Enum.Count() * 31.5f);
                categoryRect.height = categorRectHeight + (settingsDef_Enum.Count() * 31.5f);
            }

            //Category Sect.
            //Note: Deciding on adding an option in hope to put a button that disables scrollbar on category.
            Widgets.BeginScrollView(categoryRectScroll, ref categoryScroll, categoryView, true);
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

            //ContentRect Resize
            foreach (SettingsDef settingsDef in settingsDef_Enum)
            {
                if (settingsDef.defName.Equals(settingsDef_Flag))
                {
                    settingsDef.AdaptSize(ref contentRect, ref contentView, ref drawContentScroll);
                }
            }

            //Content Sect.
            Widgets.BeginScrollView(contentRectScroll, ref contentScroll, contentView, drawContentScroll);
            listing_Content.Begin(contentRect);
            foreach (SettingsDef settingsDef in settingsDef_Enum) 
            {
                settingsDef.LoadBaseValue();
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
            //Loads the changed thing properties.
            IEnumerable<ThingList> thingList = DefDatabase<SettingsDef>.AllDefs
                    .SelectMany(s => s.drawContent
                    .SelectMany(d => d.thingList)
                    .Where(t => t.live));
            foreach (ThingList thing in thingList)
            {
                thing.CheckSaved();
            }

            //Gets configured things.
            settings.thingList = DefDatabase<SettingsDef>.AllDefs
                .SelectMany(s => s.drawContent
                .SelectMany(d => d.thingList
                .Where(x => x.config && x.live)))
                .ToList();

            //Groups the thingList by defName to remove copies.
            settings.thingList = settings.thingList
                .GroupBy(s => s.defName)
                .Select(g => g.First())
                .ToList();

            base.WriteSettings();
        }

    }
}