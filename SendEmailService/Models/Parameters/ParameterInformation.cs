namespace SendEmailService.Models.Parameters
{
    /// <summary>
    /// Web api only lets you bind to one model
    /// </summary>
    public class ParameterInformation
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public EmailInformation Email { get; set; }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>
        /// The template.
        /// </value>
        public TemplateInformation Template { get; set; }
    }
}