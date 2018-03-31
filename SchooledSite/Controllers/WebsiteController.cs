using System.Web.Mvc;

namespace SchooledSite.Controllers
{
    public class WebsiteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}