using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchooledSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Website Routing
            routes.MapRoute("Index", "", new { controller = "Website", action = "Index" });
            routes.MapRoute("About", "about", new { controller = "Website", action = "About" });
            routes.MapRoute("Contact", "contact", new { controller = "Website", action = "Contact" });

            //Admin Routing
            routes.MapRoute("Admin", "admin", new { controller = "Admin", action = "Index" });
            routes.MapRoute("AdminBlog", "admin/blog", new { controller = "Admin", action = "Blog" });
            routes.MapRoute("AdminBootstrapElements", "admin/bootstrap-elements", new { controller = "Admin", action = "BootstrapElements" });
            routes.MapRoute("AdminBootstrapGrid", "admin/bootstrap-grid", new { controller = "Admin", action = "BootstrapGrid" });
            routes.MapRoute("AdminForms", "admin/forms", new { controller = "Admin", action = "Forms" });
            routes.MapRoute("AdminPortfolio", "admin/portfolio", new { controller = "Admin", action = "Portfolio" });
            routes.MapRoute("AdminTypography", "admin/typography", new { controller = "Admin", action = "Typography" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
