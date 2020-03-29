using Newtonsoft.Json;

namespace RingIntegration.Authentication
{
    public class AuthResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken;

        public string Scope;
        public string token_type;
    }
}