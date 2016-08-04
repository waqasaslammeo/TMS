using System.Web;
using System.Web.Optimization;

namespace TMStesting
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admin").Include(
                "~/Content/charisma-master/css/bootstrap-cerulean.min.css",
                "~/Content/charisma-master/css/charisma-app.css",
                "~/Content/charisma-master/bower_components/fullcalendar/dist/fullcalendar.css",
                "~/Content/charisma-master/bower_components/fullcalendar/dist/fullcalendar.print.css",
                "~/Content/charisma-master/bower_components/chosen/chosen.min.css",
                "~/Content/charisma-master/bower_components/colorbox/example3/colorbox.css",
                "~/Content/charisma-master/bower_components/responsive-tables/responsive-tables.css",
                "~/Content/charisma-master/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css",
                "~/Content/charisma-master/css/jquery.noty.css",
                "~/Content/charisma-master/css/noty_theme_default.css",
                "~/Content/charisma-master/css/elfinder.min.css",
                "~/Content/charisma-master/css/elfinder.theme.css",
                "~/Content/charisma-master/css/jquery.iphone.toggle.css",
                "~/Content/charisma-master/css/uploadify.css",
                "~/Content/charisma-master/css/animate.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Admin").Include(
                "~/Content/charisma-master/bower_components/jquery/jquery.min.js",
                "~/Content/charisma-master/bower_components/bootstrap/dist/js/bootstrap.min.js",
                "~/Content/charisma-master/js/jquery.cookie.js",
                "~/Content/charisma-master/bower_components/moment/min/moment.min.js",
                "~/Content/charisma-master/bower_components/fullcalendar/dist/fullcalendar.min.js",
                "~/Content/charisma-master/js/jquery.dataTables.min.js",
                "~/Content/charisma-master/bower_components/chosen/chosen.jquery.min.js",
                "~/Content/charisma-master/bower_components/colorbox/jquery.colorbox-min.js",
                "~/Content/charisma-master/js/jquery.noty.js",
                "~/Content/charisma-master/bower_components/responsive-tables/responsive-tables.js",
                "~/Content/charisma-master/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js",
                "~/Content/charisma-master/js/jquery.raty.min.js",
                "~/Content/charisma-master/js/jquery.iphone.toggle.js",
                "~/Content/charisma-master/js/jquery.autogrow-textarea.js",
                "~/Content/charisma-master/js/jquery.uploadify-3.1.min.js",
                "~/Content/charisma-master/js/jquery.history.js",
                "~/Content/charisma-master/js/charisma.js"));
        }
    }
}
