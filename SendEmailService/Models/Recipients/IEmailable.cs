namespace SendEmailService.Models.Recipients
{
    /// <summary>
    /// Stuff to be able to be a recipient or sender
    /// </summary>
    public interface IEmailable
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        string Email { get; }

        /// <summary>
        /// Gets the email id.
        /// </summary>
        /// <value>
        /// The email id.
        /// </value>
        int EmailId { get; }
    }
}