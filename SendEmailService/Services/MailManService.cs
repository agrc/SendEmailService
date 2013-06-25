using System.Collections.Generic;
using System.Net.Mail;
using MarkdownMailer;
using Ninject;

namespace SendEmailService.Services
{
    public class MailManService
    {
        public MailManService(List<string> to, string @from, string subject, string body)
        {
            To = to;
            From = @from;
            Subject = subject;
            Body = body;
        }

        private List<string> To { get; set; }
        private string From { get; set; }
        private string Subject { get; set; }
        private string Body { get; set; }

        [Inject]
        public MailSenderConfiguration SenderConfiguration { get; set; }

        public void Send()
        {
            var mailMessage = new MailMessage
                {
                    From = new MailAddress(From),
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                };

            To.ForEach(mailMessage.To.Add);

            var mailSender = new MailSender(SenderConfiguration);
            mailSender.Send(mailMessage);
        }
    }
}