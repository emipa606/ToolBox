using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace ToolBox
{
    public class ListingDef : Def
    {
        public string ID;
        public List<string> list;

        public static ListingDef Named(string defName)
        {
            return DefDatabase<ListingDef>.GetNamed(defName, true);
        }

        public override IEnumerable<string> ConfigErrors()
        {
            if (ID == null)
            {
                yield return "ListingDef is missing an ID.";
            }
            else
            {
                if (ID.Length.Equals(0))
                {
                    yield return "ListingDef is missing an ID.";
                }
            }
            yield break;
        }

    }
}
