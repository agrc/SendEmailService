using System.Net.Mail;
using MarkdownMailer;

namespace SendEmailService.Configuration
{
    /// <summary>
    /// Specifies the network
    /// </summary>
    public class SmtpMailer : IMailable
    {
        /// <summary>
        /// Gets the mail settings for smtp.
        /// </summary>
        /// <returns></returns>
        public MailSenderConfiguration GetSettings()
        {
            return new MailSenderConfiguration
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = "send.state.ut.us",
                    Port = 25,
                    UseDefaultCredentials = true
                };
        }
    }
}