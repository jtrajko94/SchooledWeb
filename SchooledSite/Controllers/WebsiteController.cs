using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchooledSite.Controllers
{
    public class WebsiteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View("about");
        }

        public ActionResult Contact()
        {
            return View("contact");
        }
    }
}