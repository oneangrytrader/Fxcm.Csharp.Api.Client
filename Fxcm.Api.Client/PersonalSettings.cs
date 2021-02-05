using Fxcm.Api.Client.Rest.Enum;
using Newtonsoft.Json;

namespace Fxcm.Api.Client
{
    public class PersonalSettings
    {
        [JsonProperty("environment")]
        public Env Environment;

        [JsonProperty("token")]
        public string Token;
    }
}