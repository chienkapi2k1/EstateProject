using System.Web;
using System.Web.Optimization;

namespace EstateProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
         
            bundles.Add(new ScriptBundle("~/js/base").Include(
                      "~/Assets/Admin/js/ace-extra.min.js",
                      "~/Assets/Admin/js/jquery.min.js",
                      "~/Assets/Admin/js/sweetalert2.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/js/paging").Include(
                    "~/Assets/Admin/paging/jquery.twbsPagination.js",
                    "~/Assets/Admin/paging/jquery.twbsPagination.min.js"

                    ));

            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                  "~/Assets/Admin/js/jquery.validate.min.js",
                  "~/Assets/Admin/js/global_admin_script.js",
                  "~/Assets/Admin/js/bootstrap.min.js" ,
                  "~/Assets/Admin/js/jquery-ui.custom.min.js",
                  "~/Assets/Admin/js/jquery.ui.touch-punch.min.js",
                  "~/Assets/Admin/js/jquery.easypiechart.min.js",
                  "~/Assets/Admin/js/jquery.sparkline.min.js",
                  "~/Assets/Admin/js/jquery.flot.min.js",
                  "~/Assets/Admin/js/jquery.flot.pie.min.js",
                  "~/Assets/Admin/js/jquery.flot.resize.min.js",
                  "~/Assets/Admin/js/ace-elements.min.js",
                  "~/Assets/Admin/js/ace.min.js",
                  "~/Assets/Admin/js/jquery-ui.min.js"
                  ));


             bundles.Add(new StyleBundle("~/css/base").Include(
                      "~/Assets/Admin/css/bootstrap.min.css",
                      "~/Assets/Admin/css/ace.min.css",
                      "~/Assets/Admin/css/font-awesome.min.css",
                      "~/Assets/Admin/css/sweetalert2.min.css",
                      "~/Assets/Admin/css/style.css"
                      ));
        }
    }
}
