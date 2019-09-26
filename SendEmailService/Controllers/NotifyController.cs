using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using AttributeRouting.Web.Http;
using MarkdownMailer;
using Ninject;
using Raven.Client;
using SendEmailService.Commands;
using SendEmailService.Commands.Infrastructure;
using SendEmailService.Indexes;
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

        [Inject]
        public IMailSender MailMain { get; set; }

        [HttpPost]
        [Route("notify")]
        public HttpResponseMessage SendMail(ParameterInformation parameters)
        {
            var email = parameters.Email;
            var template = parameters.Template;
            string fromAddress;
            Templates templateContent;
            var to = new List<string>();
            var response = new Reponse();

            #region validation

            if (email == null || !email.FromId.HasValue)
            {
                response.Error.Details.Add("From address cannot be empty.");
            }

            if (email == null || email.ToIds == null || !email.ToIds.Any())
            {
                response.Error.Details.Add("To addresses cannot be empty.");
            }

            if (template == null || !template.TemplateId.HasValue)
            {
                response.Error.Details.Add("Template cannot be empty.");
            }

            if (!response.IsSuccessful)
            {
                response.Status = (int)HttpStatusCode.BadRequest;
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

            #endregion

            using (var session = DocumentStore.OpenSession())
            {
                fromAddress = session.Query<Emails, EmailByIdIndex>()
                                     .Single(x => x.EmailId == email.FromId).Email;

                to = session.Advanced.DocumentQuery<Emails, EmailByIdIndex>()
                    .Where(string.Format("EmailId:({0})", string.Join(" OR ", email.ToIds)))
                    .Select(x => x.Email).ToList();

                templateContent = session.Query<Templates, TemplateByIdIndex>()
                                         .Single(x => x.TemplateId == template.TemplateId);
            }

            #region validation

            if (string.IsNullOrEmpty(fromAddress))
            {
                response.Error.Details.Add(string.Format("From address was not found. From id: {0}", email.FromId));
            }

            if (!to.Any())
            {
                response.Error.Details.Add(string.Format("To addresses was not found. To id: {0}.",
                                                         string.Join(",", email.ToIds)));
            }

            if (templateContent == null)
            {
                response.Error.Details.Add(string.Format("Template was not found. Template id: {0}.",
                                                         template.TemplateId));
            }

            if (!response.IsSuccessful)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Reponse
                    {
                        Status = (int) HttpStatusCode.BadRequest
                    });
            }

            #endregion

            var command = new RenderTemplateCommand(templateContent, template.TemplateValues);

            var content = CommandExecutor.ExecuteCommand(command);

            var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromAddress),
                    Subject = templateContent.Subject,
                    Body = content,
                    IsBodyHtml = true
                };

            to.ForEach(mailMessage.To.Add);

            MailMain.Send(mailMessage);

            return Request.CreateResponse(HttpStatusCode.OK, new Reponse
                {
                    Message = "Email Sent Successfully",
                    Status = (int) HttpStatusCode.OK
                });
        }
    }
}