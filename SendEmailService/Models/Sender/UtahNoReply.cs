using SendEmailService.Attributes;
using SendEmailService.Models.Recipients;

namespace SendEmailService.Models.Sender
{
    [Recipient]
    public class UtahNoReply : IEmailable
    {
        public UtahNoReply()
        {
            Email = "noreply@utah.gov";
            EmailId = 2;
        }

        public UtahNoReply(string email, int emailId)
        {
            Email = email;
            EmailId = emailId;
        }

        public string Email { get; private set; }

        public int EmailId { get; private set; }
    }
}