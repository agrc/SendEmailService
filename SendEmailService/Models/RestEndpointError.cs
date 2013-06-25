using System.Collections.Generic;
using Newtonsoft.Json;

namespace SendEmailService.Models
{
    public class RestEndpointError
    {
        public RestEndpointError()
        {
            Details = new List<object>();
        }

        [JsonProperty(PropertyName = "details")]
        public List<object> Details { get; set; }
    }
}