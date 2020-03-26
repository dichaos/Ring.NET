using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class OfflineMotionEventSettings
    {
        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("max_upload_kb")]
        public long MaxUploadKb { get; set; }

        [JsonProperty("resolution_p")]
        public long ResolutionP { get; set; }

        [JsonProperty("frequency_after_secs")]
        public long FrequencyAfterSecs { get; set; }

        [JsonProperty("period_after_secs")]
        public long PeriodAfterSecs { get; set; }
    }
}