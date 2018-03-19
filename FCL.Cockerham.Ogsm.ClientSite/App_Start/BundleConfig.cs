using System.Web.Optimization;

namespace FCL.Cockerham.Ogsm.ClientSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Script Bundles
            bundles.Add(new ScriptBundle("~/bundles/js/angularapp").Include(
                        "~/Scripts/App/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                        "~/Scripts/jquery-2.2.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/adminlte").Include(
                        "~/Themes/AdminLTE/dist/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/resources").Include(
                        "~/Scripts/SystemMessages.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/dataforms").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.tooltip.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/helpers").Include(
                        "~/Scripts/custom-form-elements.js",
                        "~/Scripts/jquery.dataTables.min.js",
                        "~/Scripts/jquery.inputmask.js",
                        "~/Scripts/jquery.inputmask.extensions.js",
                        "~/Scripts/jquery.inputmask.date.extensions.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                        "~/Scripts/application.common.js",
                        "~/Scripts/loading-bar.min.js",
                        "~/Scripts/angular-toastr.min.js",
                        "~/Scripts/angular-toastr.tpls.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/js/custom").Include(
                        "~/Scripts/custom.js"));            

            bundles.Add(new ScriptBundle("~/bundles/js/template-editor").Include(
                        "~/Scripts/summernote.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/angular-animate.js",
                        "~/Scripts/restangular.js",
                        "~/Scripts/underscore-min.js",
                        "~/Scripts/ng-table.js",
                        "~/Scripts/angular-flash.js",
                        "~/Scripts/ui-bootstrap-tpls-1.1.2.js"
                        ));

            #endregion

            #region Style Bundles
            bundles.Add(new StyleBundle("~/Content/adminltecss").Include(
                "~/Themes/AdminLTE/plugins/font-awesome/css/font-awesome.min.css",
                "~/Themes/AdminLTE/plugins/ionicons/css/ionicons.min.css",
                "~/Themes/AdminLTE/bootstrap/css/bootstrap.css",
                "~/Themes/AdminLTE/dist/css/AdminLTE.min.css",
                "~/Themes/AdminLTE/dist/css/skins/skin-blue.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/effect-light.min.css",
                      "~/Content/titip.min.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/loading-bar.css",
                      "~/Content/angular-flash.css",
                      "~/Content/angular-toastr.min.css",
                      "~/Content/custom.css"
                      ));

            #endregion

            BundleTable.EnableOptimizations = false;
        }
    }
}
