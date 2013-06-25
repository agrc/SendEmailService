using Newtonsoft.Json;

namespace SendEmailService.Models
{
    public sealed class Reponse : Errorable
    {
        public Reponse()
        {
            Status = 200;
            Error = new RestEndpointError();
        }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}