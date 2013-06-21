using SendEmailService.Attributes;
using SendEmailService.Models.Recipients;

namespace SendEmailService.Models.Sender
{
    [Recipient]
    public class UtahNoReply : IEmailable
    {
        private const string EmailAddress = "no-reply@utah.gov";
        private const string IdNumber = "2";

        public string Email
        {
            get { return EmailAddress; }
        }

        public string Id
        {
            get { return IdNumber; }
        }
    }
}