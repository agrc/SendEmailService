using MarkdownMailer;

namespace SendEmailService.Configuration
{
    public interface IMailable
    {
        /// <summary>
        /// Gets the mail settings for smtp or local.
        /// </summary>
        /// <returns></returns>
        MailSenderConfiguration GetSettings();
    }
}