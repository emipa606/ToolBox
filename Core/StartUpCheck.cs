using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class StartUpCheck
    {
        private static IEnumerable<string> IDs = DefDatabase<ListingDef>.AllDefs
            .GroupBy(i => i.ID)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

        /*
        private static IEnumerable<string> ListIDs = DefDatabase<CategoryDef>.AllDefs
            .SelectMany(d => d.drawContent)
            .GroupBy(l => l.listID)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);
        */
        static StartUpCheck() 
        {
            //ListingDef: ID duplicate check.
            foreach (string ID in IDs)
            {
                Log.Error($"Config error in ListingDef.ID: \"{ID}\" has duplicate(s). Please do not open the settings!");
            }
            /*

            //CategoryDef: listID duplicate check.
            foreach (string listID in ListIDs)
            {
                Log.Error($"Config error in CategoryDef.drawContent.listID: \"{listID}\" has duplicate(s). Please do not open the settings!");
            }*/
        }
    }
}