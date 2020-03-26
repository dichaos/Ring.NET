using Newtonsoft.Json;

namespace RingIntegration.Devices.Chime
{
    public partial class ChimeSettingsClass
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }
}