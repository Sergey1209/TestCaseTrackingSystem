using System.Web.Optimization;

namespace TestCaseStorage
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery-ui-{version}.js")
                .Include("~/Scripts/jquery.tablesorter.js"));

            bundles.Add(new ScriptBundle("~/bundles/main")
                .Include("~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/charts")
                .Include("~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/main.css")
                .Include("~/Content/themes/base/jquery-ui.css")
                .Include("~/Content/themes/blue/style.css"));
        }
    }
}
