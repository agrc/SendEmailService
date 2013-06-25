using SendEmailService.Attributes;
using SendEmailService.Models.Database;

namespace SendEmailService.Models.EmailTemplates
{
    [Template]
    public class SoilCertificateNewTemplate : IEmailTemplate
    {
        public SoilCertificateNewTemplate()
        {
            TemplateId = 2;
            Body = @"There was a request sent from {{url}} for a new Soil Certificate of Compliance.

Name: {{name}}
Address: {{address}}
Phone: {{phone}}
Email: {{email}}";

            Subject = "Request for new Soil Certificate of Compliance";
        }

        public SoilCertificateNewTemplate(string body, int templateId, string subject)
        {
            Body = body;

            TemplateId = templateId;
            Subject = subject;
        }

        public int TemplateId { get; set; }

        public string Subject { get; private set; }

        public string Body { get; private set; }
    }
}