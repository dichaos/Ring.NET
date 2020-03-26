using Newtonsoft.Json;

namespace RingIntegration.Devices.Doorbell
{
    public partial class DoorbotFeatures
    {
        [JsonProperty("motions_enabled")]
        public bool MotionsEnabled { get; set; }

        [JsonProperty("show_recordings")]
        public bool ShowRecordings { get; set; }

        [JsonProperty("show_vod_settings")]
        public bool ShowVodSettings { get; set; }

        [JsonProperty("rich_notifications_eligible")]
        public bool RichNotificationsEligible { get; set; }

        [JsonProperty("show_24x7_lite")]
        public bool Show24X7Lite { get; set; }

        [JsonProperty("show_offline_motion_events")]
        public bool ShowOfflineMotionEvents { get; set; }
    }
}