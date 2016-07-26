using System;
using System.Web;
using System.Web.Optimization;

namespace CustomerUI
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
                     "~/Scripts/bootstrap.min.cs",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                "~/Scripts/angularjs.js"));

         
            bundles.Add(new StyleBundle("~/bundles/Content").Include(
                "~/Content/vendors/font-awesome/css/font-awesome.min.css",
                "~/Content/vendors/nprogress/nprogress.css",
                "~/Content/vendors/iCheck/skins/flat/green.css",
                "~/Content/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                "~/Content/vendors/jqvmap/dist/jqvmap.min.css",
                "~/Content/build/css/custom.min.css",
                "~/Content/Slider/css/slider.css",

                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Content").Include(
             "~/Content/Slider/js/slider.js",
             "~/Content/vendors/jquery/dist/jquery.min.js",
             "~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
             "~/Content/vendors/fastclick/lib/fastclick.js",
             "~/Content/vendors/nprogress/nprogress.js",
             "~/Content/vendors/Chart.js/dist/Chart.min.js",
             "~/Content/vendors/gauge.js/dist/gauge.min.js",
             "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
             "~/Content/vendors/iCheck/icheck.min.js",
             "~/Content/vendors/skycons/skycons.js",
             "~/Content/vendors/Flot/jquery.flot.js",
             "~/Content/vendors/Flot/jquery.flot.pie.js",
             "~/Content/vendors/Flot/jquery.flot.time.js",
             "~/Content/vendors/Flot/jquery.flot.stack.js",
             "~/Content/vendors/Flot/jquery.flot.resize.js",
             "~/Content/js/flot/jquery.flot.orderBars.js",
             "~/Content/js/flot/date.js",
             "~/Content/js/flot/jquery.flot.spline.js",
             "~/Content/js/flot/curvedLines.js",
             "~/Content/js/moment/moment.min.js",
             "~/Content/js/datepicker/daterangepicker.js",
             "~/Content/build/js/custom.min.js"

             ));
        }

        private static void BuildScriptBundles(BundleCollection bundles)
        {
            //TODO: Refactor into a libs bundle

            var angularCdnUrl = "http://ajax.googleapis.com/ajax/libs/angularjs/1.0.6/angular.min.js";
            bundles.Add(new ScriptBundle("~/jsbundle/angular", angularCdnUrl).Include(
                        "~/public/js/lib/angular/angular.js"));
                  


        }
    }

 }
