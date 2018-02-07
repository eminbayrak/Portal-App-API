using System.Web;
using System.Web.Optimization;

namespace ParentPortalAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-pages.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/api").Include(
                      "~/Scripts/knockout-{version}.js",
                      "~/Scripts/api-debug.js"));

            //set to false for debugging
            BundleTable.EnableOptimizations = true;
        }
    }
}
