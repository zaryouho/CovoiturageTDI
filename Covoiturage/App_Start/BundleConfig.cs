using System.Web;
using System.Web.Optimization;

namespace Covoiturage
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/js/bootstrap.css",
                      "~/css/site.css"));

            #region Template Design

            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/css/custom-bs.css",
                      "~/css/jquery.fancybox.min.css",
                      "~/css/bootstrap-select.min.css",
                      "~/fonts/icomoon/style.css",
                      "~/fonts/line-icons/style.css",
                      "~/css/owl.carousel.min.css",
                      "~/css/style.css",
                      "~/css/animate.min.css")); ;

            bundles.Add(new ScriptBundle("~/template/js").Include(
                        "~/js/jquery.min.js",
                        "~/js/bootstrap.bundle.min.js",
                        "~/js/isotope.pkgd.min.js",
                        "~/js/stickyfill.min.js",
                        "~/js/jquery.fancybox.min.js",
                        "~/js/jquery.easing.1.3.js",
                        "~/js/jquery.animateNumber.min.js",
                        "~/js/owl.carousel.min.js",
                        "~/js/bootstrap-select.min.js",
                        "~/js/custom.js",
                        "~/js/quill.min.js",
                        "~/js/jquery.waypoints.min.js"));

            

            #endregion

        }
    }
}
