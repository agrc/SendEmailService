using System.Web.Http;
using Raven.Client;

namespace SendEmailService.Controllers
{
    public abstract class RavenApiController : ApiController
    {
        protected RavenApiController(IDocumentStore store)
        {
            DocumentStore = store;
        }

        public IDocumentStore DocumentStore { get; set; }
    }
}