using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MeriMudra.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/Script/HomeJs").Include(
                                      "~/js/bootstrap.min.js",
                                      "~/js/menumaker.js",
                                      "~/js/jquery.sticky.js",
                                      "~/js/sticky-header.js",
                                      "~/js/owl.carousel.min.js",
                                      "~/js/slider-carousel.js",
                                      "~/js/service-carousel.js",
                                      "~/js/back-to-top.js"
                                      ));
            //CSS
            bundles.Add(new ScriptBundle("~/style/HomeCss").Include(
                        "~/css/bootstrap.min.css",
                        "~/css/style.css",
                        "~/css/font-awesome.min.css",
                        "~/css/fontello.css",
                        "~/css/flaticon.css"
                        ));
        }
    }
}
