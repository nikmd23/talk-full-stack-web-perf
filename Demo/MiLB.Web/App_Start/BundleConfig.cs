using System.Web.Optimization;

namespace MiLB.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/normalize.css")
                //.Include("~/Content/validation.css")
                .Include("~/Content/screen.css")
                .Include("~/Content/Images/MascotSmall/texas/Texas.png.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/timing.js")
                .Include("~/Scripts/rum.js"));
        }
    }
}
