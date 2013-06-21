using SendEmailService.Attributes;

namespace SendEmailService.Models.Recipients
{
    [Recipient]
    public class JimBlankenau : IEmailable
    {
        private const string IdNumber = "1";
        private const string EmailAddress = "jim.blankenau@parkcity.org";

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