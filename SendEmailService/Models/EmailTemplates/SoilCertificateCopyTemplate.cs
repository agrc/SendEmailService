using SendEmailService.Attributes;
using SendEmailService.Models.Database;

namespace SendEmailService.Models.EmailTemplates
{
    [Template]
    public class SoilCertificateCopyTemplate : IEmailTemplate
    {
        public SoilCertificateCopyTemplate()
        {
            TemplateId = 1;
            Subject = "Request for new Soil Certificate of Compliance";
            Body = @"There was a request sent from {{url}} for a **copy** of a Soil Certificate of Compliance.

Name: {{name}}  
Address: {{address}}  
Phone: {{phone}}  
Email: {{email}}";
        }

        public SoilCertificateCopyTemplate(string body, int templateId, string subject)
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