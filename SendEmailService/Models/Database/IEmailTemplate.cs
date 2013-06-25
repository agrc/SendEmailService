namespace SendEmailService.Models.Database
{
    /// <summary>
    /// Interface defining what an email template needs
    /// </summary>
    public interface IEmailTemplate
    {
        /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        /// <value>
        /// The template id.
        /// </value>
        int TemplateId { get; set; }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        /// <value>
        /// The subject of the email.
        /// </value>
        string Subject { get; }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <value>
        /// The body of the email.
        /// </value>
        string Body { get; }
    }
}