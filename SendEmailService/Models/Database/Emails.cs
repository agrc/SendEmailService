using SendEmailService.Models.Recipients;

namespace SendEmailService.Models.Database
{
    /// <summary>
    /// Db model for a users id and email address
    /// </summary>
    public class Emails : IEmailable
    {
        public Emails(string email, int emailId)
        {
            Email = email;
            EmailId = emailId;
        }

        /// <summary>
        /// Gets or sets the email id.
        /// </summary>
        /// <value>
        /// The email id.
        /// </value>
        public int EmailId { get; set; }
        
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
    }
}