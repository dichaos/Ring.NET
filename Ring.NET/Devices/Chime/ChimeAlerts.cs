using Newtonsoft.Json;

namespace RingIntegration.Devices.Chime
{
    public class ChimeAlerts
    {
        [JsonProperty("connection")]
        public string Connection { get; set; }
    }
}