using System.Net.Mail;
using MarkdownMailer;

namespace SendEmailService.Configuration
{
    /// <summary>
    /// Specifies a pickup directory
    /// </summary>
    public class LocalMailer : IMailable
    {
        /// <summary>
        /// Gets the mail settings for local.
        /// </summary>
        /// <returns></returns>
        public MailSenderConfiguration GetSettings()
        {
            return new MailSenderConfiguration
                {
                    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                    PickupDirectoryLocation = @"C:\Projects\TestData\EmailPickup",
                    Host = "send.state.ut.us",
                    Port = 25,
                    UseDefaultCredentials = true
                };
        }
    }
}