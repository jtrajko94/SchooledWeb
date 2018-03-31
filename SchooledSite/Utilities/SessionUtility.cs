using Newtonsoft.Json;
using System.Web;

namespace SchooledSite.Utilities
{
    public class SessionUtility
    {
        public static void Put(string name, object value)
        {
            if (HttpContext.Current == null)
                return;
            HttpContext.Current.Session[Settings.AppName + "_" + name] = JsonConvert.SerializeObject(value);
        }
        public static object Get<T>(string name)
        {
            if (HttpContext.Current == null)
                return null;
            var value = HttpContext.Current.Session[Settings.AppName + "_" + name];
            if (value == null)
                return null;
            return JsonConvert.DeserializeObject<T>(value.ToString());
        }
        public static void Remove(string name)
        {
            if (HttpContext.Current == null)
                return;
            HttpContext.Current.Session.Remove(Settings.AppName + "_" + name);
        }
    }
}