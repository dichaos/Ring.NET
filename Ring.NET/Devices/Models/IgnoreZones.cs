using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class IgnoreZones
    {
        [JsonProperty("zone1")]
        public Zone4Class Zone1 { get; set; }

        [JsonProperty("zone2")]
        public Zone4Class Zone2 { get; set; }

        [JsonProperty("zone3")]
        public Zone4Class Zone3 { get; set; }

        [JsonProperty("zone4")]
        public Zone4Class Zone4 { get; set; }
    }
}