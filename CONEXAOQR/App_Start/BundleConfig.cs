﻿using System.Web;
using System.Web.Optimization;

namespace CONEXAOQR
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datePicker").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                        "~/Content/bootstrap-datetimepicker.css"));
            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Scripts/jquery.toast.js",
                      "~/Scripts/sweetalert.min.js",
                      "~/Scripts/my-scripts.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/sweetalert.css",
                      "~/Content/jquery.toast.css",
                      "~/Content/site.css"));


        }
    }
}
