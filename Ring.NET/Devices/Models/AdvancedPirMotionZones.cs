using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class AdvancedPirMotionZones
    {
        [JsonProperty("zone1_sensitivity")]
        public long Zone1Sensitivity { get; set; }

        [JsonProperty("zone2_sensitivity")]
        public long Zone2Sensitivity { get; set; }

        [JsonProperty("zone3_sensitivity")]
        public long Zone3Sensitivity { get; set; }

        [JsonProperty("zone4_sensitivity")]
        public long Zone4Sensitivity { get; set; }

        [JsonProperty("zone5_sensitivity")]
        public long Zone5Sensitivity { get; set; }

        [JsonProperty("zone6_sensitivity")]
        public long Zone6Sensitivity { get; set; }
    }
}