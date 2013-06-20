using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;

namespace SendEmailService.Controllers
{
    public class NotifyController : ApiController
    {
        [GET("Notify"), HttpGet]
        public HttpResponseMessage CreateResource([FromUri] string[] ids)
        {
            // Simple parameters are assumed to come from the URL by default. So use [FromBody]
            return Request.CreateResponse(HttpStatusCode.OK, string.Join(",", ids));
        }
    }
}