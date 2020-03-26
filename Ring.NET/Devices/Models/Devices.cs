using Newtonsoft.Json;
using RingIntegration.Devices.Doorbell;

namespace RingIntegration.Devices.Models
{
    public partial class Devices
    {
        [JsonProperty("doorbots")]
        public Doorbot[] Doorbots { get; set; }

        [JsonProperty("authorized_doorbots")]
        public object[] AuthorizedDoorbots { get; set; }

        [JsonProperty("chimes")]
        public Chime.Chime[] Chimes { get; set; }

        [JsonProperty("stickup_cams")]
        public object[] StickupCams { get; set; }

        [JsonProperty("base_stations")]
        public object[] BaseStations { get; set; }

        [JsonProperty("beams_bridges")]
        public object[] BeamsBridges { get; set; }

        [JsonProperty("beams")]
        public object[] Beams { get; set; }

        [JsonProperty("other")]
        public object[] Other { get; set; }
    }
}