using SendEmailService.Attributes;

namespace SendEmailService.Models.Recipients
{
    [Recipient]
    public class JimBlankenau : IEmailable
    {
        public JimBlankenau()
        {
            Email = "jim.blankenau@parkcity.org";
            EmailId = 1;
        }

        public JimBlankenau(string email, int emailId)
        {
            Email = email;
            EmailId = emailId;
        }

        public string Email { get; private set; }

        public int EmailId { get; private set; }
    }
}