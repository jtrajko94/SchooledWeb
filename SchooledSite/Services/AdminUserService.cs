using Newtonsoft.Json;
using SchooledSite.Models;
using SchooledSite.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace SchooledSite.Services
{
    public static class AdminUserService
    {
        public static AdminUserModel GetCurrentUser()
        {
            var current = HttpContext.Current;
            var currentUser = SessionUtility.Get<AdminUserModel>("currentUser");
            if (currentUser != null)
            {
                var user = (AdminUserModel)currentUser;
                return user;
            }
            else
            {
                return null;
            }
        }
        public static void RemoveCurrentUser()
        {
            SessionUtility.Remove("currentUser");
        }

        public static void LogIn(AdminUserModel user)
        {
            SessionUtility.Put("currentUser", user);
        }

        public static ValidatorResponseModel IsValidLogin(string email, string password, out AdminUserModel user)
        {
            var isValid = true;
            var errFields = new Dictionary<string, string>();

            AdminUserModel returnUser = null;
            if (!ValidatorUtility.Item(ValidatorType.AnyValue, email))
            {
                isValid = false;
                errFields.Add("email", "Email is required.");
            }
            else if (!ValidatorUtility.Item(ValidatorType.AnyValue, password))
            {
                isValid = false;
                errFields.Add("password", "Password is invalid.");
            }

            //Check if User exists
            if (isValid)
            {

                string apiKey = APIService.CreateApiKey();
                returnUser = GetAdminUserByLogin(email, password, apiKey);
                if (returnUser == null)
                {
                    isValid = false;
                    errFields.Add("email", "Login Credentials are invalid.");
                }
            }
            user = returnUser;
            var result = new ValidatorResponseModel();
            result.IsValid = isValid;
            result.ErrFields = errFields;
            return result;
        }

        public static AdminUserModel GetAdminUserByLogin(string email, string password, string apikey)
        {
            try
            {
                string myParameters = "email=" + email + "&" + "password=" + password;
                string URI = APIService.GenerateApiUrl("adminuser/getbylogin/?" + myParameters);

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers["ApiKey"] = apikey;
                    string responseString = client.UploadString(URI, myParameters);

                    APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                    if (APIService.IsSuccess(responseModel))
                    {
                        return JsonConvert.DeserializeObject<AdminUserModel>(responseModel.description);
                    }
                    return null;

                }
            }
            catch (Exception err)
            {
                return null;
            }

        }
    }
}