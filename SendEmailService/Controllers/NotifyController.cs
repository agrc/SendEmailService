using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Raven.Client;
using Raven.Client.Linq;
using SendEmailService.Models;

namespace SendEmailService.Controllers
{
    public class NotifyController : RavenApiController
    {
        public NotifyController(IDocumentStore store) : base(store)
        {
        }

        [GET("Notify"), HttpGet]
        public HttpResponseMessage CreateResource([FromUri] EmailInformation email,
                                                  [FromUri] TemplateInformation template)
        {

            using (var session = DocumentStore.OpenSession())
            {
                var from = session.Load<Emails>(email.FromId).Email;
                var to = session.Query<Emails>().Where(x => email.ToIds.Contains(x.Id));
            }

            // Simple parameters are assumed to come from the URL by default. So use [FromBody]
            return Request.CreateResponse(HttpStatusCode.OK, new Reponse
                {
                    Message = "Email Sent Successfully",
                    Status = (int) HttpStatusCode.OK
                });
        }
    }
}