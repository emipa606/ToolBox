using System.Collections.Generic;
using System.Linq;
using Mlie;
using ToolBox.SettingsDefComp;
using UnityEngine;
using Verse;

namespace ToolBox.Settings;

public class ToolBox : Mod
{
    private static string currentVersion;
    private readonly Vector2 bottomHoriLine = new Vector2(168f, 623f);
    private readonly Color lineColor = new Color(105f, 105f, 105f, 0.5f);
    private readonly Listing_Standard listing_Category = new Listing_Standard();
    private readonly Listing_Standard listing_Content = new Listing_Standard();

    private readonly IEnumerable<SettingsDef> settingsDef_Enum =
        DefDatabase<SettingsDef>.AllDefs.OrderBy(c => c.position);

    private readonly Vector2 topHoriLine = new Vector2(168f, 40f);
    private Vector2 categoryScroll = new Vector2(0f, 0f);
    private Vector2 contentScroll = new Vector2(0f, 0f);
    public ToolBoxSettings settings;

    private string settingsDef_Flag = "Default";

    public ToolBox(ModContentPack content) : base(content)
    {
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(ModLister.GetActiveModWithIdentifier("Mlie.Toolbox"));
        settings = GetSettings<ToolBoxSettings>();
    }

    public override string SettingsCategory()
    {
        return "ToolBox";
    }

    //Loads the settings window for ToolBox
    public override void DoSettingsWindowContents(Rect rect)
    {
        var categoryRect = new Rect(rect.x, rect.y, rect.width / 5f, rect.height); //172.8 width
        var categoryRectScroll = new Rect(rect.x, rect.y, rect.width / 5f, rect.height);
        var categoryView = new Rect(rect.x, rect.y, categoryRect.width - 25f, rect.height);
        var contentRect = new Rect(categoryRect.width + 5f, rect.y, rect.width - categoryRect.width - 5f,
            rect.height);
        var contentRectScroll = new Rect(categoryRect.width + 5f, rect.y, rect.width - categoryRect.width - 5f,
            rect.height);
        var contentView = new Rect(contentRect.x, rect.y, contentRect.width - 25f, rect.height);
        var hasTop = settingsDef_Enum.Count(c => c.level.Equals(CategoryLevel.Top)) != 0;
        var hasMiddle = settingsDef_Enum.Count(c => c.level.Equals(CategoryLevel.Middle)) != 0;
        var hasBottom = settingsDef_Enum.Count(c => c.level.Equals(CategoryLevel.Bottom)) != 0;

        //This flags would matter once I make a ToolBox Home category.
        var drawContentScroll = true;
        var drawSeparator = true;

        //CategoryRect Resize
        var categorRectHeight = 0f;
        if (hasTop)
        {
            categorRectHeight += 10f;
        }

        if (hasMiddle)
        {
            categorRectHeight += 10f;
        }

        if (hasBottom)
        {
            categorRectHeight += 10f;
        }

        if (categorRectHeight + (settingsDef_Enum.Count() * 31.5f) > categoryRect.height)
        {
            drawSeparator = false;
            categoryView.height = categorRectHeight + (settingsDef_Enum.Count() * 31.5f);
            categoryRect.height = categorRectHeight + (settingsDef_Enum.Count() * 31.5f);
        }

        //Category Sect.
        //Note: Deciding on adding an option in hope to put a button that disables scrollbar on category.
        Widgets.BeginScrollView(categoryRectScroll, ref categoryScroll, categoryView);
        listing_Category.Begin(categoryRect);
        listing_Category.ColumnWidth = categoryRect.width - 15.5f;
        foreach (var topCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Top)))
        {
            if (listing_Category.ButtonText(topCategory.label))
            {
                settingsDef_Flag = topCategory.defName;
            }
        }

        if (hasTop && (hasMiddle || hasBottom)) //Divider under Top level
        {
            listing_Category.GapLine(5f);
            listing_Category.Gap(5f);
        }

        foreach (var middleCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Middle)))
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

        foreach (var bottomCategory in settingsDef_Enum.Where(c => c.level.Equals(CategoryLevel.Bottom)))
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
        foreach (var settingsDef in settingsDef_Enum)
        {
            if (settingsDef.defName.Equals(settingsDef_Flag))
            {
                settingsDef.AdaptSize(ref contentRect, ref contentView, ref drawContentScroll);
            }
        }

        //Content Sect.
        Widgets.BeginScrollView(contentRectScroll, ref contentScroll, contentView, drawContentScroll);
        listing_Content.Begin(contentRect);
        foreach (var settingsDef in settingsDef_Enum)
        {
            if (settingsDef.defName.Equals(settingsDef_Flag))
            {
                settingsDef.Display();
            }
        }

        if (currentVersion != null)
        {
            listing_Content.Gap();
            GUI.contentColor = Color.gray;
            listing_Content.Label("Toolbox.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Content.End();
        Widgets.EndScrollView();
    }

    //Sets and checks the old saved values for saving/resaving.
    //settings.thingList is where it's all sent and saved.
    public override void WriteSettings()
    {
        //Loads the changed thing properties.
        var thingList = DefDatabase<SettingsDef>.AllDefs
            .SelectMany(s => s.configurator
                .SelectMany(d => d.thingList)
                .Where(t => t.live));
        foreach (var thing in thingList)
        {
            thing.CheckSaved();
        }

        //Gets configured things.
        settings.thingList = DefDatabase<SettingsDef>.AllDefs
            .SelectMany(s => s.configurator
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