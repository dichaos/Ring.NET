using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class Zone4Class
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("vertex1")]
        public Vertex Vertex1 { get; set; }

        [JsonProperty("vertex2")]
        public Vertex Vertex2 { get; set; }
    }
}