using SchooledSite.Models;
using SchooledSite.Utilities;
using System.Web.Mvc;

namespace SchooledSite.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if(SessionUtility.Get<AdminUserModel>("currentUser") == null)
            {
                return View("login");
            }else
            {
                return View("dashboard");
            }
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