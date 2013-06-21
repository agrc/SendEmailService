using System.Collections.Generic;

namespace SendEmailService.Models.Parameters
{
    public class EmailInformation
    {
        public List<string> ToIds { get; set; }
        public string FromId { get; set; }
    }
}