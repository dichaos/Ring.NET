using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class Lite24X7
    {
        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("frequency_secs")]
        public long FrequencySecs { get; set; }

        [JsonProperty("resolution_p")]
        public long ResolutionP { get; set; }
    }
}