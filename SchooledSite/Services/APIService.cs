using Newtonsoft.Json;
using SchooledSite.Models;
using SchooledSite.Utilities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SchooledSite.Services
{
    public static class APIService
    {
        public static bool IsSuccess(APIResponseModel response)
        {
            if(response.status == "Success" && response.description != "" && response.description != "[]" && response.description != "null")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GenerateApiUrl(string path)
        {
            return Settings.ApiUrl + path;
        }

        public static string CreateApiKey()
        {
            try
            {
                string URI = GenerateApiUrl("apikey/create/");
                string myParameters = "";

                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string responseString = client.UploadString(URI, myParameters);

                    APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                    if (IsSuccess(responseModel))
                    {
                        return responseModel.description;
                    }
                    return null;
                }
            }catch (Exception)
            {
                return null;
            }
            
        }

        public static ApiKeyModel GetApiKey(string id)
        {
            using (var client = new WebClient())
            {
                var url = GenerateApiUrl("apikey/");

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("id", id);

                var response = client.UploadValues(url, null);
                var responseString = Encoding.Default.GetString(response);

                APIResponseModel responseModel = JsonConvert.DeserializeObject<APIResponseModel>(responseString);

                if (IsSuccess(responseModel))
                {
                    return JsonConvert.DeserializeObject<ApiKeyModel>(responseModel.description);
                }
                return null;
            }
        }

        public static bool IsActiveApiKey(ApiKeyModel apikey)
        {
            if(apikey.ExpiredDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}