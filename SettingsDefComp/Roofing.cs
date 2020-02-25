using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Roofing
    {
        public bool HoldsRoof { get; set; }
        public bool AutoRoof { get; set; }
        public bool IsDoor { get; set; }
        public bool IsImpassable { get; set; }
        public RoofMode Mode { get; set; }

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
                if (HoldsRoof && !AutoRoof)
                {
                    Mode = RoofMode.Manual;
                }
                if (!HoldsRoof)
                {
                    Mode = RoofMode.None;
                }
            }
            else
            {
                if (HoldsRoof && AutoRoof)
                {
                    if (IsImpassable)
                    {
                        Mode = RoofMode.Auto;
                    }
                    else
                    {
                        Mode = RoofMode.Manual;
                    }
                    
                }
                if (HoldsRoof && !AutoRoof)
                {
                    Mode = RoofMode.Manual;
                }
                if (!HoldsRoof)
                {
                    Mode = RoofMode.None;
                }
            }
        }
    }
}
