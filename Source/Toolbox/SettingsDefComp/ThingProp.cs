using System;
using System.Text;
using Verse;

namespace ToolBox.SettingsDefComp;

/// <summary>
///     A collection of modifiable properties of a Thing that is connected to a specific Widget
///     that allows value change.
/// </summary>
public class ThingProp : IExposable
{
    public readonly ThingProp_BaseHP baseHPProp = new();
    public readonly ThingProp_Beauty beautyProp = new();

    private readonly StringBuilder
        configBuilder = new("00000000000"); //Increase the 0s for every new Prop.

    public readonly ThingProp_Cost costProp = new();
    public readonly ThingProp_Fill fillProp = new();
    public readonly ThingProp_Flammability flammabilityProp = new();

    //Input type ThingProps
    public readonly ThingProp_Label labelProp = new();
    public readonly ThingProp_Link linkProp = new();

    //Select type ThingProps
    public readonly ThingProp_Passability passabilityProp = new();
    public readonly ThingProp_Path pathProp = new();
    public readonly int pos = 0;

    //Button type ThingProps
    public readonly ThingProp_Roof roofProp = new();
    public readonly ThingProp_Terrain terrainProp = new();
    public readonly ThingProp_WorkToBuild workProp = new();
    public bool config;
    public string configID;
    public string defName;
    public string label;
    public bool live = true;

    public void ExposeData()
    {
        Scribe_Values.Look(ref defName, "defName");
        Scribe_Values.Look(ref configID, "configID");
        costProp.ExposeData();
        baseHPProp.ExposeData();
        beautyProp.ExposeData();
        fillProp.ExposeData();
        pathProp.ExposeData();
        workProp.ExposeData();
        flammabilityProp.ExposeData();
        passabilityProp.ExposeData();
        linkProp.ExposeData();
        roofProp.ExposeData();
        terrainProp.ExposeData();
    }

    public void LiveCheck()
    {
        try
        {
            if (live)
            {
                _ = ThingDef.Named(defName).defName;
            }
        }
        catch (NullReferenceException)
        {
            live = false;
        }
    }

    public void CheckConfig()
    {
        configBuilder[0] = costProp.config;
        configBuilder[1] = baseHPProp.config;
        configBuilder[2] = beautyProp.config;
        configBuilder[3] = fillProp.config;
        configBuilder[4] = pathProp.config;
        configBuilder[5] = workProp.config;
        configBuilder[6] = flammabilityProp.config;
        configBuilder[7] = passabilityProp.config;
        configBuilder[8] = linkProp.config;
        configBuilder[9] = roofProp.config;
        configBuilder[10] = terrainProp.config;
        configID = configBuilder.ToString();
        config = configID.Contains("1");
    }

    public void CheckSaved()
    {
        if (costProp.numIntDefault.Count > 1 && costProp.load)
        {
            costProp.Preset(defName);
        }

        if (baseHPProp.numIntDefault.Count > 1 && baseHPProp.load)
        {
            baseHPProp.Preset(defName);
        }

        if (beautyProp.numIntDefault.Count > 1 && beautyProp.load)
        {
            beautyProp.Preset(defName);
        }

        if (fillProp.numIntDefault.Count > 1 && fillProp.load)
        {
            fillProp.Preset(defName);
        }

        if (pathProp.numIntDefault.Count > 1 && pathProp.load)
        {
            pathProp.Preset(defName);
        }

        if (workProp.numIntDefault.Count > 1 && workProp.load)
        {
            workProp.Preset(defName);
        }

        if (flammabilityProp.numIntDefault.Count > 1 && flammabilityProp.load)
        {
            flammabilityProp.Preset(defName);
        }

        if (passabilityProp.optionDefault.Count > 1 && passabilityProp.load)
        {
            passabilityProp.Preset(defName);
        }

        if (linkProp.optionDefault.Count > 1 && linkProp.load)
        {
            linkProp.Preset(defName);
        }

        if (roofProp.optionDefault.Count > 1 && roofProp.load)
        {
            roofProp.Preset(defName);
        }

        if (terrainProp.optionDefault.Count > 1 && terrainProp.load)
        {
            terrainProp.Preset(defName);
        }

        CheckConfig();
    }
}