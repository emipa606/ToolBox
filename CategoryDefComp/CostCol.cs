using System.Collections.Generic;
using ToolBox.Tools;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class CostCol : BaseCol
    {
        public new string header = "Cost";
        public new float headerPos = 20f;
        public new float width = 80f;
        public Dictionary<string, int> saveData; //You have to do the same thing you did with cost
        public IList<string> defName;
        public List<int> cost;
        public List<string> buffer = new List<string>();

        public override void ExposeData()
        {
            Scribe_Collections.Look(ref saveData, "cost", LookMode.Value);
        }

        public void Base(List<string> defName, List<int> index)
        {
            this.defName = defName;
            if (linked)
            {
                if (saveData.Count <= 0)
                {
                    saveData = new Dictionary<string, int>();
                    foreach (int i in index)
                    {
                        saveData.Add(defName[i], cost[i]);
                    }
                }
                if (cost.NullOrEmpty())
                {
                    cost = new List<int>(index);
                }
                if (!cost.NullOrEmpty() && cost.Count != index.Count)
                {
                    foreach (int i in index)
                    {
                        cost[i] = ThingDef.Named(defName[i]).costStuffCount;
                        buffer.Add(cost[i].ToString());
                    }
                }
                /*
                foreach (string name in defName)
                {
                    cost.Add(ThingDef.Named(name).costStuffCount);
                    buffer.Add(ThingDef.Named(name).costStuffCount.ToString());
                }*/
                /*
                if (!cost.NullOrEmpty())
                {
                    foreach (int x in cost)
                    {
                        buffer.Add(x.ToString());
                    }
                }*/
            }
        }

        public void Data(IList<int> indexer) 
        {
            if (!cost.NullOrEmpty() && !defName.NullOrEmpty())
            {
                foreach (int i in indexer)
                {
                    //saveData.
                }
            }
            if (saveData.Count > 0)//Do a check if this produces an exception due to being null.
            {

            }
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
                Construct.InputField(x, vertLine, width, cost, buffer, 4, 10000, index);
                vertLine += 24f;
            }
        }
    }
}
