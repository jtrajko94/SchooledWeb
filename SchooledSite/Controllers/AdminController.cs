using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchooledSite.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            //if user is logged in
            //return View("login");

            //if user is not logged in
            return View("dashboard");
        }

        public ActionResult Blog()
        {
            return View("blog");
        }

        public ActionResult BootstrapElements()
        {
            return View("bootstrap-elements");
        }

        public ActionResult BootstrapGrid()
        {
            return View("bootstrap-grid");
        }

        public ActionResult Forms()
        {
            return View("forms");
        }

        public ActionResult Portfolio()
        {
            return View("portfolio");
        }

        public ActionResult Typography()
        {
            return View("typography");
        }
    }
}