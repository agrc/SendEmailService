using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Raven.Client;
using SendEmailService.Models;
using SendEmailService.Models.Database;
using SendEmailService.Models.Parameters;

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

                var to = new Collection<string>();

                foreach (var id in email.ToIds)
                {
                    to.Add(session.Load<Emails>(id).Email);
                }


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