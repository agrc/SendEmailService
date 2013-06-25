using System.Collections.Generic;

namespace SendEmailService.Models.Parameters
{
    /// <summary>
    /// Information about email senders and recipients
    /// </summary>
    public class EmailInformation
    {
        /// <summary>
        /// Gets or sets to ids.
        /// </summary>
        /// <value>
        /// To ids. The ids used to find the users in the database for which the
        /// email will be sent to.
        /// </value>
        public List<int> ToIds { get; set; }

        /// <summary>
        /// Gets or sets from id.
        /// </summary>
        /// <value>
        /// From id. The id of the person sending the email.
        /// </value>
        public int? FromId { get; set; }
    }
}