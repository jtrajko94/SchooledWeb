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

            //Testing
            routes.MapRoute("AdminBlog", "admin/blog", new { controller = "Admin", action = "Blog" });
            routes.MapRoute("AdminBootstrapElements", "admin/bootstrap-elements", new { controller = "Admin", action = "BootstrapElements" });
            routes.MapRoute("AdminBootstrapGrid", "admin/bootstrap-grid", new { controller = "Admin", action = "BootstrapGrid" });
            routes.MapRoute("AdminForms", "admin/forms", new { controller = "Admin", action = "Forms" });
            routes.MapRoute("AdminPortfolio", "admin/portfolio", new { controller = "Admin", action = "Portfolio" });
            routes.MapRoute("AdminTypography", "admin/typography", new { controller = "Admin", action = "Typography" });

            //Admin Routing
            routes.MapRoute("Admin", "admin", new { controller = "Admin", action = "Index" });
            routes.MapRoute("AdminUsers", "admin/users", new { controller = "Admin", action = "Users" });
            routes.MapRoute("AdminAddEditUser", "admin/users/{addoredit}", new { controller = "Admin", action = "AddEditUser" });

            //Admin Service Routing
            routes.MapRoute("AdminLoginService", "ws/admin/login", new { controller = "AdminService", action = "Login" });
            routes.MapRoute("AdminLogoutService", "ws/admin/logout", new { controller = "AdminService", action = "Logout" });
            routes.MapRoute("AdminUsersAddEditService", "ws/admin/users/add-edit", new { controller = "AdminService", action = "AddEditUser" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
