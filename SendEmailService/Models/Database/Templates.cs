namespace SendEmailService.Models.Database
{
    public class Templates : IEmailTemplate
    {
        public Templates(int templateId, string subject, string body)
        {
            TemplateId = templateId;
            Subject = subject;
            Body = body;
        }

        public int TemplateId { get; set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
    }
}