using System.Web;
using System.Web.Optimization;

namespace web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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


            #region angular
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                         "~/Scripts/angular.js",
                         "~/Scripts/angular-ui/ui-bootstrap.js",
                         "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                         "~/Scripts/angular-ui/sortable.js",
                         "~/Scripts/angular-animate.js",
                         "~/Scripts/angular-aria.js",
                         "~/Scripts/angular-cookies.js",
                         "~/Scripts/angular-loader.js",
                         "~/Scripts/angular-local-storage.js",
                         "~/Scripts/angular-message-format.js",
                         "~/Scripts/angular-messages.js",
                         //"~/Scripts/angular-mocks.js",
                         //"~/Scripts/angular-parse-ext.js",
                         //"~/Scripts/angular-resource.js",
                         "~/Scripts/angular-route.js",
                         "~/Scripts/angular-sanitize.js",
                         "~/Scripts/spin.js",
                         "~/Scripts/angular-spinner.js",
                         //"~/Scripts/angular-scenario.js",
                         //"~/Scripts/angular-touch.js",
                         "~/Scripts/angular-signalr-hub.js",
                         "~/Scripts/angular-translate.js",
                         "~/Scripts/angular-translate-loader-partial.js",
                         "~/Scripts/angular-translate-loader-static-files.js",
                         "~/Scripts/angular-translate-loader-url.js",
                         "~/Scripts/ng-table.js"));


            #endregion


            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                        "~/Scripts/angular-multiple-file-upload.js",
                        "~/Scripts/angular-file-upload.min.js"));

            #region App angular
            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                    "~/App/App.js",
                    "~/App/AppConfig.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Controllers").IncludeDirectory(
                "~/App/Controllers", "*.js", true
            ));

            bundles.Add(new ScriptBundle("~/bundles/Services").IncludeDirectory(
                "~/App/Services", "*.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Directives").IncludeDirectory(
                "~/App/Directives", "*.js"
            ));
            #endregion

            //BundleTable.EnableOptimizations = false;
        }
    }
}
