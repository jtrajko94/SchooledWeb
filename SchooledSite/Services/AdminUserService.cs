using Newtonsoft.Json;
using SchooledSite.Models;
using SchooledSite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static ValidatorResponseModel IsValid(AdminUserModel adminuser)
        {
            var isValid = true;
            var errFields = new Dictionary<string, string>();

            if (!ValidatorUtility.Item(ValidatorType.AnyValue, adminuser.Email))
            {
                isValid = false;
                errFields.Add("email", "Email is required.");
            }
            if (!ValidatorUtility.IsValidPassword(adminuser.Password))
            {
                isValid = false;
                errFields.Add("password", "Password is required.");
            }
            if (!ValidatorUtility.Item(ValidatorType.AnyValue, adminuser.FirstName))
            {
                isValid = false;
                errFields.Add("firstname", "First Name is required.");
            }
            if (!ValidatorUtility.Item(ValidatorType.AnyValue, adminuser.LastName))
            {
                isValid = false;
                errFields.Add("lastname", "Last Name is required.");
            }

            var result = new ValidatorResponseModel();
            result.IsValid = isValid;
            result.ErrFields = errFields;
            return result;
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
            if (!ValidatorUtility.Item(ValidatorType.AnyValue, password))
            {
                isValid = false;
                errFields.Add("password", "Password is invalid.");
            }

            if (isValid)
            {
                returnUser = GetAdminUserByLogin(email, password, APIService.CreateApiKey());
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
            catch (Exception)
            {
                return null;
            }
        }

        public static List<AdminUserModel> GetAllAdminUsers(string apikey)
        {
            try
            {
                string myParameters = "id=";
                string URI = APIService.GenerateApiUrl("adminuser/get/?" + myParameters);

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers["ApiKey"] = apikey;
                    string responseString = client.UploadString(URI, myParameters);

                    APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                    if (APIService.IsSuccess(responseModel))
                    {
                        return JsonConvert.DeserializeObject<List<AdminUserModel>>(responseModel.description);
                    }
                    return null;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MergeAdminUser(AdminUserModel adminuser, string apikey)
        {
            try
            {
                string myParameters = "adminuserjson=" + JsonConvert.SerializeObject(adminuser);
                string URI = APIService.GenerateApiUrl("adminuser/merge/?" + myParameters);

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers["ApiKey"] = apikey;
                    string responseString = client.UploadString(URI, myParameters);

                    APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                    if (APIService.IsSuccess(responseModel))
                    {
                        return responseModel.description;
                    }
                    return null;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static AdminUserModel GetAdminUser(string apikey, string id)
        {
            try
            {
                string myParameters = "id=" + id;
                string URI = APIService.GenerateApiUrl("adminuser/get/?" + myParameters);

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    client.Headers["ApiKey"] = apikey;
                    string responseString = client.UploadString(URI, myParameters);

                    APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                    if (APIService.IsSuccess(responseModel))
                    {
                        return JsonConvert.DeserializeObject<List<AdminUserModel>>(responseModel.description).FirstOrDefault();
                    }
                    return null;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}