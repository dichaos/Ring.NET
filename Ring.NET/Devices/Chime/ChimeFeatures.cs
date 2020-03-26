using Newtonsoft.Json;

namespace RingIntegration.Devices.Chime
{
    public class ChimeFeatures
    {
        [JsonProperty("ringtones_enabled")]
        public bool RingtonesEnabled { get; set; }
    }
}