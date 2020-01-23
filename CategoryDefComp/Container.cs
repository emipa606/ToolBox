using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class Container : IExposable
    {
        public float x = 0;
        public float y = 0;
        public List<string> thingList = new List<string>();
        public LabelCol labelCol = new LabelCol();
        public CostCol costCol = new CostCol();
        public IList<int> indexer;

        public virtual void ExposeData()
        {
            Scribe_Deep.Look(ref costCol, "costCol");
        }

        /*
        public bool HasListID
        {
            get
            {
                if (labelCol != null || costCol != null)
                {
                    if (listID != null)
                    {
                        return listID.Length != 0;
                    }
                    return false;
                }
                else
                {
                    if (listID != null)
                    {
                        return listID.Length != 0;
                    }
                    return true;
                }
            }
        }
        */

        public virtual void LoadBase() 
        {
            indexer = ToolHandle.SetCount(thingList.Count());
            labelCol.Base(thingList);
            costCol.Base(thingList, this.indexer.ToList());
        }

        public virtual void LoadData()
        {
            costCol.Data(indexer);
        }
        
        public virtual void LoadWidgets()
        {
            float labeLine = labelCol.y;
            float costLine = costCol.y;
            labelCol.Header(ref labeLine);
            costCol.Header(ref costLine);
            foreach (int index in indexer)
            {
                labelCol.Body(ref labeLine, index);
                costCol.Body(ref costLine, index);
            }
        }
    }
}
