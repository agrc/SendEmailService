namespace SendEmailService.Models.Parameters
{
    /// <summary>
    /// Information about the email text
    /// </summary>
    public class TemplateInformation
    {
        /// <summary>
        /// Gets or sets the template id.
        /// </summary>
        /// <value>
        /// The template id used to find the email in the database.
        /// </value>
        public int? TemplateId { get; set; }


        /// <summary>
        /// Gets or sets the template values.
        /// </summary>
        /// <value>
        /// The template values passed in as a json object from the client.
        /// </value>
        public dynamic TemplateValues { get; set; }
    }
}