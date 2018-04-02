using SchooledSite.Models;
using SchooledSite.Services;
using SchooledSite.Utilities;
using System.Collections.Generic;
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

        //Non-Test Code
        public ActionResult Users()
        {
            List<AdminUserModel> users = AdminUserService.GetAllAdminUsers(APIService.CreateApiKey()); 

            return View("users/index", users);
        }

        public ActionResult AddEditUser(string addOrEdit, string id)
        {
            var model = new AdminUserModel();
            if (addOrEdit == "add")
            {
                model = new AdminUserModel();
                ViewBag.Action = "Add";
            }
            else
            {
                model = AdminUserService.GetAdminUser(APIService.CreateApiKey(), id);
                ViewBag.Action = "Edit";
            }
            return View("users/add-edit", model);
        }
    }
}