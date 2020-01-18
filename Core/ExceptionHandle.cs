using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsComp;
using ToolBox.ThingDefComp;
using Verse;

namespace ToolBox.Core
{
    [StaticConstructorOnStartup]
    class ExceptionHandle
    {
        /// <summary>
        ///     Note: I didn't use try-catch since I'll be forced to create custom ones 
        ///     when I can just simply make an if-else here and have it log as an error.
        ///     If a situation occures that requires or has better reason to use try-catch,
        ///     I'll try and replace the ones here.
        /// </summary>

        private static IEnumerable<CategoryDef> categoryDefs = DefDatabase<CategoryDef>.AllDefs;
        private static IEnumerable<ThingDef> thingDefs = DefDatabase<ThingDef>.AllDefs.Where(t => t.HasComp(typeof(ToolBoxComp)));
        private static string Error = "[ToolBox : ERROR]";
        //private static string Info = "[ToolBox : TIP] Please refer to the following for more detail: (insert)";
        //private static string Warning = "[ToolBox : WARNING]";

        static ExceptionHandle() 
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
                //Does more than show missing, which is quite annoying.
                try
                {
                    categoryDef.Check();
                }
                catch (HasMissingException missing)
                {
                    Log.Error($"{Error} ThingDef named \"{categoryDef.defName} does not contain: {missing}.");
                }
                /*
                string defTypeCall = "CategoryDef named";
                if (categoryDef.HasMissing)
                {
                    string missingList = "";
                    if (categoryDef.GetMissingCount == 2)
                    {
                        missingList = categoryDef.GetMissing.Insert(categoryDef.GetMissing.LastIndexOf("<"), "and ").Replace(",", "");
                    }
                    else if (categoryDef.GetMissingCount >= 3)
                    {
                        missingList = categoryDef.GetMissing.Insert(categoryDef.GetMissing.LastIndexOf("<"), " and ");
                    }
                    else 
                    {
                        missingList = categoryDef.GetMissing.Remove(categoryDef.GetMissing.Length - 1, 0);
                    }
                    Log.Error($"{Error} {defTypeCall} \"{categoryDef.defName}\" does not contain: {missingList}.");
                }
                if (!categoryDef.HasListID)
                {
                    Log.Error($"{Error} {defTypeCall} \"{categoryDef.defName}\" is missing a <listID> in {categoryDef.MissingListID} of its <drawContent> Containers.");
                }*/
            }
        }
    }
}
