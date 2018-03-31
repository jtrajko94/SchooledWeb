using SchooledSite.Models;
using SchooledSite.Services;
using System;
using System.Web.Mvc;

namespace SchooledSite.Controllers
{
    public class AdminServiceController : Controller
    {
        [HttpPost]
        public ActionResult Login()
        {
            try
            {
                AdminUserModel adminUser = null;
                var username = Request.Form["email"].NoNull();
                var password = Request.Form["password"].NoNull();
                var result = AdminUserService.IsValidLogin(username, password, out adminUser);
                if (result.IsValid && adminUser != null)
                {
                    AdminUserService.LogIn(adminUser);
                }
                return Json(result);
            }
            catch (Exception err)
            {
                return Json(err);
            }
        }
    }
}