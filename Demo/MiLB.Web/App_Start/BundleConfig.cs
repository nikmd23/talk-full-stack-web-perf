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
                .Include("~/Content/Images/MascotSmall/texas/Texas.css")
                .Include("~/Content/Images/MascotSmall/Southern/Southern.css")
                .Include("~/Content/Images/MascotSmall/South-Atlantic/South-Atlantic.css")
                .Include("~/Content/Images/MascotSmall/Pioneer/Pioneer.css")
                .Include("~/Content/Images/MascotSmall/Pacific-Coast/Pacific-Coast.css")
                .Include("~/Content/Images/MascotSmall/northwest/Northwest.css")
                .Include("~/Content/Images/MascotSmall/New-York-Penn/New-York-Penn.css")
                .Include("~/Content/Images/MascotSmall/Midwest/Midwest.css")
                .Include("~/Content/Images/MascotSmall/International/International.css")
                .Include("~/Content/Images/MascotSmall/Florida-State/Florida-State.css")
                .Include("~/Content/Images/MascotSmall/Eastern/Eastern.css")
                .Include("~/Content/Images/MascotSmall/Carolina/Carolina.css")
                .Include("~/Content/Images/MascotSmall/California/California.css")
                .Include("~/Content/Images/MascotSmall/Appalachian/Appalachian.css"));

            bundles.Add(new ScriptBundle("~/Scripts/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/timing.js")
                .Include("~/Scripts/rum.js"));
        }
    }
}
