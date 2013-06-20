using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Newtonsoft.Json.Linq;
using SendEmailService.Models;

namespace SendEmailService.Controllers
{
    public class NotifyController : ApiController
    {
        [GET("Notify"), HttpGet]
        public HttpResponseMessage CreateResource([FromUri] EmailInformation email, [FromUri] TemplateInformation template)
        {
            // Simple parameters are assumed to come from the URL by default. So use [FromBody]
            return Request.CreateResponse(HttpStatusCode.OK, new Reponse
                {
                    Message = "Email Sent Successfully",
                    Status = (int)HttpStatusCode.OK
                });
        }
    }
}