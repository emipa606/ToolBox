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
    private readonly Vector2 bottomHoriLine = new(168f, 623f);
    private readonly Color lineColor = new(105f, 105f, 105f, 0.5f);
    private readonly Listing_Standard listingCategory = new();
    private readonly Listing_Standard listingContent = new();
    private readonly ToolBoxSettings settings;

    private readonly IEnumerable<SettingsDef> settingsDefEnum =
        DefDatabase<SettingsDef>.AllDefs.OrderBy(c => c.position);

    private readonly Vector2 topHoriLine = new(168f, 40f);
    private Vector2 categoryScroll = new(0f, 0f);
    private Vector2 contentScroll = new(0f, 0f);

    private string settingsDefFlag = "Default";

    public ToolBox(ModContentPack content) : base(content)
    {
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
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
        var hasTop = settingsDefEnum.Count(c => c.level.Equals(CategoryLevel.Top)) != 0;
        var hasMiddle = settingsDefEnum.Count(c => c.level.Equals(CategoryLevel.Middle)) != 0;
        var hasBottom = settingsDefEnum.Count(c => c.level.Equals(CategoryLevel.Bottom)) != 0;

        //This flags would matter once I make a ToolBox Home category.
        var drawContentScroll = true;
        var drawSeparator = true;

        //CategoryRect Resize
        var categoryRectHeight = 0f;
        if (hasTop)
        {
            categoryRectHeight += 10f;
        }

        if (hasMiddle)
        {
            categoryRectHeight += 10f;
        }

        if (hasBottom)
        {
            categoryRectHeight += 10f;
        }

        if (categoryRectHeight + (settingsDefEnum.Count() * 31.5f) > categoryRect.height)
        {
            drawSeparator = false;
            categoryView.height = categoryRectHeight + (settingsDefEnum.Count() * 31.5f);
            categoryRect.height = categoryRectHeight + (settingsDefEnum.Count() * 31.5f);
        }

        //Category Sect.
        //Note: Deciding on adding an option in hope to put a button that disables scrollbar on category.
        Widgets.BeginScrollView(categoryRectScroll, ref categoryScroll, categoryView);
        listingCategory.Begin(categoryRect);
        listingCategory.ColumnWidth = categoryRect.width - 15.5f;
        foreach (var topCategory in settingsDefEnum.Where(c => c.level.Equals(CategoryLevel.Top)))
        {
            if (listingCategory.ButtonText(topCategory.label))
            {
                settingsDefFlag = topCategory.defName;
            }
        }

        if (hasTop && (hasMiddle || hasBottom)) //Divider under Top level
        {
            listingCategory.GapLine(5f);
            listingCategory.Gap(5f);
        }

        foreach (var middleCategory in settingsDefEnum.Where(c => c.level.Equals(CategoryLevel.Middle)))
        {
            if (listingCategory.ButtonText(middleCategory.label))
            {
                settingsDefFlag = middleCategory.defName;
            }
        }

        if (hasMiddle && hasBottom) //Divider under Middle level
        {
            listingCategory.GapLine(5f);
            listingCategory.Gap(5f);
        }

        foreach (var bottomCategory in settingsDefEnum.Where(c => c.level.Equals(CategoryLevel.Bottom)))
        {
            if (listingCategory.ButtonText(bottomCategory.label))
            {
                settingsDefFlag = bottomCategory.defName;
            }
        }

        listingCategory.End();
        Widgets.EndScrollView();

        //Separator: Category and Content Divider
        if (drawSeparator)
        {
            Widgets.DrawLine(topHoriLine, bottomHoriLine, lineColor, 1f);
        }

        //ContentRect Resize
        foreach (var settingsDef in settingsDefEnum)
        {
            if (settingsDef.defName.Equals(settingsDefFlag))
            {
                settingsDef.AdaptSize(ref contentRect, ref contentView, ref drawContentScroll);
            }
        }

        //Content Sect.
        Widgets.BeginScrollView(contentRectScroll, ref contentScroll, contentView, drawContentScroll);
        listingContent.Begin(contentRect);
        foreach (var settingsDef in settingsDefEnum)
        {
            if (settingsDef.defName.Equals(settingsDefFlag))
            {
                settingsDef.Display();
            }
        }

        if (currentVersion != null)
        {
            listingContent.Gap();
            GUI.contentColor = Color.gray;
            listingContent.Label("Toolbox.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingContent.End();
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