using System.Web.Http;
using AttributeRouting.Web.Http;

namespace SendEmailService.Controllers
{
    public class NotifyController : ApiController
    {
        [POST("{id")]
        public string Get(int id)
        {
            return "value";
        }
    }
}