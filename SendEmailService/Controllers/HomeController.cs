using System.Web.Mvc;
using AttributeRouting.Web.Http;

namespace SendEmailService.Controllers
{
    public class HomeController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
