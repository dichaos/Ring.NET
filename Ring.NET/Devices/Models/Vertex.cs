using Newtonsoft.Json;

namespace RingIntegration.Devices.Models
{
    public partial class Vertex
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}