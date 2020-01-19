using System.Collections.Generic;
using System.Linq;
using ToolBox.ThingDefComp;
using Verse;

namespace ToolBox.ExceptionHandle
{
    [StaticConstructorOnStartup]
    class StartUpCheck
    {
        private static IEnumerable<CategoryDef> categoryDefs = DefDatabase<CategoryDef>.AllDefs;
        private static IEnumerable<ThingDef> thingDefs = DefDatabase<ThingDef>.AllDefs
            .Where(t => t.HasComp(typeof(ToolBoxComp)));

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
            //ThingDef check
            foreach (ThingDef thingDef in thingDefs)
            {
                string defTypeCall = "ThingDef named";
                if (!thingDef.GetCompProperties<ToolBoxCompProperties>().HasList)
                {
                    Log.Error($"{Error} {defTypeCall} \"{thingDef.defName}\" does not contain <defList> inside <comps>.");
                    
                }
            }

            //CategoryDef check
            foreach (CategoryDef categoryDef in categoryDefs) 
            {
                try
                {
                    categoryDef.CheckMissing();
                }
                catch (HasMissingException e)
                {
                    if (e.GetMissingProp.Length > 0)
                    {
                        Log.Error($"{Error} ThingDef named \"{categoryDef.defName}\" does not contain: {e.GetMissingProp}.");
                    }
                    if (e.MissingIDCount > 0)
                    {
                        Log.Error($"{Error} ThingDef named \"{categoryDef.defName}\" " +
                            $"does not contain: listID in {e.MissingIDCount} of its Container(s).");
                    }
                }
            }

            //ListID check
            foreach (string listID in listIDs)
            {
                Log.Error($"{Error} ListID named \"{listID}\" has duplicate(s). " + "Please do not open the settings!");
            }
        }
    }
}