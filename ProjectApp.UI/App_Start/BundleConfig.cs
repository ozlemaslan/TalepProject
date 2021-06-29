using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ProjectApp.UI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/adminLayout").Include("~/Content/css/*.css"));

            bundles.Add(new ScriptBundle("~/js/adminLayout").Include("~/Content/js/jquery.min.js", "~/Content/js/bootstrap.bundle.min.js", "~/Content/js/jquery.easing.min.js", "~/Content/js/sb-admin-2.min.js", "~/Content/js/Chart.min.js", "~/Content/js/chart-area-demo.js", "~/Content/js/chart-pie-demo.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}