using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolBox.ExceptionHandle
{
    [StaticConstructorOnStartup]
    class StartUpCheck
    {
        private static IEnumerable<CategoryDef> categoryDefs = DefDatabase<CategoryDef>.AllDefs;

        private static IEnumerable<string> listIDs = DefDatabase<CategoryDef>.AllDefs
            .SelectMany(x => x.drawContent)
            .GroupBy(c => c.listID)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key);
        private static string Error = "[ToolBox : ERROR]";
        //private static string Info = "[ToolBox : TIP]";
        //private static string Warning = "[ToolBox : WARNING]";

        static StartUpCheck() 
        {
            //ListingDef ID check

            //ListID dup. check
            foreach (string listID in listIDs)
            {
                Log.Error($"{Error} ListID named \"{listID}\" has duplicate(s). " + "Please do not open the settings!");
            }
        }
    }
}