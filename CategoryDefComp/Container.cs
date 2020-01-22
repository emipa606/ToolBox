using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolBox.Tools;
using Verse;

namespace ToolBox.CategoryDefComp
{
    public class Container : IExposable
    {
        public string listID;
        public float x = 0;
        public float y = 0;
        public LabelCol labelCol = new LabelCol();
        public IEnumerable<ListingDef> thingList;

        public bool HasListID
        {
            get
            {
                if (labelCol != null /*|| costCol != null*/)
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

        public virtual void ExposeData()
        {

        }

        public virtual void LoadBase() 
        {
            thingList = DefDatabase<ListingDef>.AllDefs.Where(x => x.ID.Equals(this.listID));
            labelCol.Base();
            /*
            foreach (ListingDef lol in thingList)
            {
                Log.Error(lol.ID);
                foreach (string item in lol.list)
                {
                    Log.Error(item);
                }
            }*/
        }

        public virtual void LoadSubWidgets()
        {
            float vertLine = labelCol.y;
            if (labelCol != null)
            {
                labelCol.Header(ref vertLine);
            }
        }

        public virtual void LoadWidgets()
        {
            foreach (ListingDef thing in thingList)
            {
                if (labelCol != null)
                {
                    foreach (string defName in thing.list)
                    {
                        labelCol.Body(ThingDef.Named(defName).label);
                        Log.Error(ThingDef.Named(defName).label);
                    }
                }
            }
        }


    }
}
