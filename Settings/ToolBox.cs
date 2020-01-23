using System.Collections.Generic;
using System.Linq;
using ToolBox.CategoryDefComp;
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
        private IEnumerable<CategoryDef> categoryList = DefDatabase<CategoryDef>.AllDefs.OrderBy(c => c.position);
        private string categoryFlag = "Home";
        
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
            bool hasTop = categoryList.Where(c => c.level.Equals(CategoryLevel.Top)).Count() != 0;
            bool hasMiddle = categoryList.Where(c => c.level.Equals(CategoryLevel.Middle)).Count() != 0;
            bool hasBottom = categoryList.Where(c => c.level.Equals(CategoryLevel.Bottom)).Count() != 0;

            //Category Sect.
            Widgets.BeginScrollView(categoryRect, ref categoryScroll, categoryView, true);
            listing_Category.Begin(categoryRect);
            listing_Category.ColumnWidth = categoryRect.width - 15.5f;
            foreach (CategoryDef topCategory in categoryList.Where(c => c.level.Equals(CategoryLevel.Top)))
            {
                if (listing_Category.ButtonText(topCategory.label))
                {
                    categoryFlag = topCategory.defName;
                }
            }
            if(hasTop && (hasMiddle || hasBottom)) //Divider under Top level
            {
                listing_Category.GapLine(5f);
                listing_Category.Gap(5f);
            }
            foreach (CategoryDef middleCategory in categoryList.Where(c => c.level.Equals(CategoryLevel.Middle))) 
            {
                if (listing_Category.ButtonText(middleCategory.label))
                {
                    categoryFlag = middleCategory.defName;
                }
            }
            if (hasMiddle && hasBottom) //Divider under Middle level
            {
                listing_Category.GapLine(5f);
                listing_Category.Gap(5f);
            }
            foreach (CategoryDef bottomCategory in categoryList.Where(c => c.level.Equals(CategoryLevel.Bottom)))
            {
                if (listing_Category.ButtonText(bottomCategory.label))
                {
                    categoryFlag = bottomCategory.defName;
                }
            }
            listing_Category.End();
            Widgets.EndScrollView();

            // Category and Content Divider
            Widgets.DrawLine(topHoriLine, bottomHoriLine, lineColor, 1f);

            //Content Sect.
            Widgets.BeginScrollView(contentRect, ref contentScroll, contentView, true);
            listing_Content.Begin(contentRect);
            foreach (CategoryDef category in categoryList) 
            {
                category.Reload();
                if (categoryFlag.Equals(category.defName)) 
                {
                    category.Display(contentRect, contentView);
                }
            }
            listing_Content.End();
            Widgets.EndScrollView();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            PostLoadData();
        }

        public void PostLoadData()
        {
        }
    }
}