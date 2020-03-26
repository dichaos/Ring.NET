using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public class DoNotDisturb
    {
        [JsonProperty("seconds_left")]
        public long SecondsLeft { get; set; }
    }
}