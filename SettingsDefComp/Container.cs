using System.Collections.Generic;
using System.Linq;
using ToolBox.Tools;
using Verse;

namespace ToolBox.SettingsDefComp
{
    public class Container : IExposable
    {
        public float x = 0;
        public float y = 0;
        public string listID;
        public List<string> thingList = new List<string>();
        public LabelCol labelCol;
        public CostCol costCol;
        public IList<int> index;

        public virtual void ExposeData()
        {
            Scribe_Values.Look(ref listID, "listID");
            Scribe_Collections.Look(ref thingList, "thingList", LookMode.Value);
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
            index = ToolHandle.SetCount(thingList.Count());
            labelCol.Base(thingList);
            costCol.Base(thingList, listID);
        }

        public virtual void LoadData()
        {
            costCol.Data(index);
        }
        
        public virtual void LoadWidgets()
        {
            float labeLine = labelCol.y;
            float costLine = costCol.y;
            labelCol.Header(ref labeLine);
            costCol.Header(ref costLine);
            foreach (int i in index)
            {
                labelCol.Body(ref labeLine, i);
                costCol.Body(ref costLine, i);
            }
        }
    }
}
