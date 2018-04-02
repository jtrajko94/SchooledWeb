using SchooledSite.Models;
using SchooledSite.Services;
using SchooledSite.Utilities;
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
                    SessionUtility.Put("currentUser", adminUser);
                }
                return Json(result);
            }
            catch (Exception)
            {
            }

            return Json(null);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                SessionUtility.Remove("currentUser");
                return Json(true);
            }
            catch(Exception) {
            }
            return Json(false);
        }

        [HttpPost]
        public ActionResult AddEditUser()
        {
            try
            {
                AdminUserModel adminuser = new AdminUserModel();

                var action = Request.Form["action"].NoNull();

                if(action == "Edit")
                {
                    adminuser.AdminUserRowKey = Request.Form["rowkey"].NoNull();
                }

                adminuser.FirstName = Request.Form["firstname"].NoNull();
                adminuser.LastName = Request.Form["lastname"].NoNull();
                adminuser.Password = Request.Form["password"].NoNull();
                adminuser.Email = Request.Form["email"].NoNull();

                var result = AdminUserService.IsValid(adminuser);

                if (result.IsValid)
                {
                    AdminUserService.MergeAdminUser(adminuser, APIService.CreateApiKey());
                }
                return Json(result);
            }
            catch (Exception)
            {
            }

            return Json(null);
        }
    }
}