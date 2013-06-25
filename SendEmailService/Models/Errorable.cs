using System.Linq;
using Newtonsoft.Json;

namespace SendEmailService.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class Errorable
    {
        [JsonProperty(PropertyName = "error")]
        public virtual RestEndpointError Error { get; set; }

        public virtual bool IsSuccessful
        {
            get { return !Error.Details.Any(); }
        }

        public bool ShouldSerializeError()
        {
            return Error.Details.Any();
        }
    }
}