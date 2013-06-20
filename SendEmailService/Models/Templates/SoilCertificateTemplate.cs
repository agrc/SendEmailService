using SendEmailService.Attributes;
using SendEmailService.Models.Database;

namespace SendEmailService.Models.Templates
{
    [Template]
    public class SoilCertificateTemplate : IEmailTemplate
    {
        private string _body =
            @"There was a request sent from {{url}} for a **copy** of a Soil Certificate of Compliance.

Name: {{name}}  
Address: {{address}}  
Phone: {{phone}}  
Email: {{email}}";

        private string _subject = "Request for new Soil Certificate of Compliance";

        private string[] _variableNames = new[]
            {
                "url", "name", "address", "phone", "email"
            };

        public int Id { get; set; }

        public string Subject
        {
            get { return _subject; }
            private set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            private set { _body = value; }
        }

        public string[] VariableNames
        {
            get { return _variableNames; }
            private set { _variableNames = value; }
        }
    }
}