using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class AdvancedMotionZones
    {
        [JsonProperty("zone1")]
        public AdvancedMotionZonesZone1 Zone1 { get; set; }

        [JsonProperty("zone2")]
        public AdvancedMotionZonesZone1 Zone2 { get; set; }

        [JsonProperty("zone3")]
        public AdvancedMotionZonesZone1 Zone3 { get; set; }
    }
}