using System.Web.Optimization;

namespace FCL.Cockerham.Ogsm.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Script Bundles
            bundles.Add(new ScriptBundle("~/bundles/js/base").Include(
                        "~/Scripts/jquery-2.2.0.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery-ui-1.10.3.custom.min.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/jquery-common.js"));


            bundles.Add(new ScriptBundle("~/bundles/js/dataforms").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.tooltip.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/template-editor").Include(
                        "~/Scripts/summernote.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalform").Include(
            "~/Scripts/modalform.js"));

            #endregion

            #region Style Bundles
            bundles.Add(new StyleBundle("~/bundles/base").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/summernote.css",
                      "~/Content/font-awesome.css",
                      "~/Content/themes/ui-lightness/jquery-ui-1.10.3.min.css"));

            #endregion
        }
    }
}
