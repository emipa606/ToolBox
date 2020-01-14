using Verse;

namespace ToolBox.Components
{
    public class BlueprintCheckDef : Def
    {
        public bool BlueprintFences;
        public bool BlueprintStairs;
        public bool BlueprintSlopes;
        public bool BlueprintPlatfroms;
        
        public static BlueprintCheckDef Named(string defName)
        {

            return DefDatabase<BlueprintCheckDef>.GetNamed(defName, true);

        }
    }
}
