using SendEmailService.Models.Recipients;

namespace SendEmailService.Models.Database
{
    public class Emails : IEmailable
    {
        public Emails(string email)
        {
            Email = email;
        }

        public string Id { get; set; }
        public string Email { get; set; }
    }
}