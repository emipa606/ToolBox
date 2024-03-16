using Verse;

namespace ToolBox.SettingsDefComp;

public class Roofing
{
    public Roofing(ThingDef thingDef)
    {
        HoldsRoof = thingDef.holdsRoof;
        AutoRoof = thingDef.building.allowAutoroof;
        IsDoor = thingDef.IsDoor;
        IsImpassable = thingDef.passability == Traversability.Impassable;
        if (IsDoor)
        {
            if (HoldsRoof && AutoRoof)
            {
                Mode = RoofMode.Auto;
            }

            switch (HoldsRoof)
            {
                case true when !AutoRoof:
                    Mode = RoofMode.Manual;
                    break;
                case false:
                    Mode = RoofMode.None;
                    break;
            }
        }
        else
        {
            if (HoldsRoof && AutoRoof)
            {
                Mode = IsImpassable ? RoofMode.Auto : RoofMode.Manual;
            }

            switch (HoldsRoof)
            {
                case true when !AutoRoof:
                    Mode = RoofMode.Manual;
                    break;
                case false:
                    Mode = RoofMode.None;
                    break;
            }
        }
    }

    public bool HoldsRoof { get; }
    public bool AutoRoof { get; }
    public bool IsDoor { get; }
    public bool IsImpassable { get; }
    public RoofMode Mode { get; }
}