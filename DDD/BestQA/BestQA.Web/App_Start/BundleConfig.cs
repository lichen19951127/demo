using System.Web;
using System.Web.Optimization;
namespace BestQA.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterJsBundles(bundles);
            RegisterCssBundles(bundles);
            BundleTable.EnableOptimizations = false;
        }
        private static void RegisterJsBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/baseJavascriptBundle").Include(
            "~/Scripts/jquery/jquery-1.11.1.js",
            "~/Scripts/angular/angular.js",
            "~/Scripts/angular/bootstrap/ui-bootstrap-tpls-0.11.0.js",
            "~/Scripts/bootstrap/bootstrap.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/angularPlugins").Include(
            "~/Scripts/angular/block-ui/angular-block-ui.js",
            "~/Scripts/angular/ng-table/ng-table.js"));
            bundles.Add(new ScriptBundle("~/bundles/jQueryPlugins").Include(
            "~/Scripts/jquery/timeago/jquery.timeago.js",
            "~/Scripts/markdown/Markdown.Converter.js",
            "~/Scripts/markdown/Markdown.Sanitizer.js",
            "~/Scripts/markdown/Markdown.Editor.js"
            ));
        }
        private static void RegisterCssBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bestQACss").Include(
            "~/Content/bootstrap-3.2.0-dist/css/bootstrap.css",
            "~/Content/block-ui/angular-block-ui.css",
            "~/Content/markdown/markdown.css",
            "~/Content/site.css",
            "~/Content/css/select2.css"
            ));
        }
    }
}
