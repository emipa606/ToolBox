using System.Collections.Generic;
using ToolBox.Settings;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class CostCol : BaseCol
    {
        public new string header = "Cost";
        public new float headerPos = 16.8f;
        public new float width = 38f;
        public List<int> cost = new List<int>();
        public List<string> buffer;

        public override void ExposeData()
        {
            Scribe_Collections.Look(ref cost, "cost", LookMode.Value);
        }

        public void Base(List<string> thingList, string listID)//Loaded on startup
        {
            if (linked)
            {
                bool hasContainers = !LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers.NullOrEmpty();
                int sameCount = DefDatabase<SettingsDef>.AllDefsListForReading.Count;
                bool sameContainers = false;
                if (hasContainers)
                {
                    sameContainers = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers.Count == sameCount;
                }
                if (sameContainers)
                {
                    var containers = LoadedModManager.GetMod<Settings.ToolBox>().GetSettings<ToolBoxSettings>().containers;
                    foreach (var item in containers)
                    {
                        if (item.listID.Equals(listID))
                        {
                            cost = item.costCol.cost;
                            buffer = item.costCol.cost.ConvertAll(c => c.ToString());
                        }
                    }
                    if (!cost.NullOrEmpty())
                    {
                        Log.Error("---Container--");
                        foreach (int c in cost)
                        {
                            Log.Error(c.ToString());
                        }
                    }
                }
                else
                {
                    foreach (string thing in thingList)
                    {
                        cost.Add(ThingDef.Named(thing).costStuffCount);
                    }
                    if (!cost.NullOrEmpty())
                    {
                        buffer = cost.ConvertAll(c => c.ToString());
                    }
                }
            }
        }

        public void Data(IList<int> index)//Loaded after closing the settings
        {

        }

        public void Header(ref float vertLine)
        {
            if (linked && hasHeader)
            {
                Construct.UnderlinedLabel(x, vertLine, width, headerPos, header);
                vertLine += 24f;
            }
        }

        public void Body(ref float vertLine, int index)
        {
            if (linked)
            {
                Construct.InputField(x, vertLine, width, cost, buffer, 4, 9999, index);
                vertLine += 24f;
            }
        }
    }
}
