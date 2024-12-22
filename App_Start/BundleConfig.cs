//using System.Web;
//using System.Web.Optimization;

//namespace StudentManagementSystem
//{
//    public class BundleConfig
//    {
//        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
//        public static void RegisterBundles(BundleCollection bundles)
//        {
//            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
//                        "~/Scripts/jquery-{version}.js"));

//            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
//                        "~/Scripts/jquery.validate*"));

//            // Use the development version of Modernizr to develop with and learn from. Then, when you're
//            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
//            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
//                        "~/Scripts/modernizr-*"));

//            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
//                      "~/Scripts/bootstrap.js"));

//            bundles.Add(new StyleBundle("~/Content/css").Include(
//                      "~/Content/bootstrap.css",
//                      "~/Content/site.css"));
//        }
//    }
//}

using System.Web;
using System.Web.Optimization;

namespace StudentManagementSystem
    {
    public class BundleConfig
        {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
            {     // jQuery bundle
    bundles.Add(new Bundle("~/bundles/jquery").Include(
        "~/Scripts/jquery-{version}.js"));

    // jQuery validation bundle
    bundles.Add(new Bundle("~/bundles/jqueryval").Include(
        "~/Scripts/jquery.validate*"));

    // Modernizr bundle
    bundles.Add(new Bundle("~/bundles/modernizr").Include(
        "~/Scripts/modernizr-*"));

    // Bootstrap bundle (JavaScript)
    bundles.Add(new Bundle("~/bundles/bootstrap").Include(
        "~/Scripts/bootstrap.bundle.min.js")); // Includes Popper.js for tooltips and dropdowns

    // Bootstrap and site CSS
    bundles.Add(new Bundle("~/Content/css").Include(
        "~/Content/bootstrap.min.css", // Use minified version
        "~/Content/site.css"));

    // Enable optimizations (set to false in debug mode)
    BundleTable.EnableOptimizations = false;
}
    }
    }

