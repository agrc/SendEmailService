using System.Collections.Generic;

namespace SendEmailService.Models
{
    public class EmailInformation
    {
        public List<int> ToIds { get; set; }
        public int FromId { get; set; }
    }
}