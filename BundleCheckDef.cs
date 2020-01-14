using Verse;

namespace ToolBox.Components
{
    public class BundleCheckDef : Def
    {
        public bool BundleJapanTheme;
        public bool BundleRailings;

        public static BundleCheckDef Named(string defName)
        {

            return DefDatabase<BundleCheckDef>.GetNamed(defName, true);

        }
    }
}
