using Newtonsoft.Json;

namespace RingIntegration.Devices.Doorbell
{
    public class DoorbotAlerts
    {
        [JsonProperty("connection")]
        public string Connection { get; set; }

        [JsonProperty("outdoor_module_connected")]
        public bool OutdoorModuleConnected { get; set; }
    }
}