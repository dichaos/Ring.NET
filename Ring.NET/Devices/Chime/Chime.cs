using System;
using Newtonsoft.Json;
using RingIntegration.Devices.Models;

namespace RingIntegration.Devices.Chime
{
    public class Chime
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("firmware_version")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("settings")]
        public ChimeSettings Settings { get; set; }

        [JsonProperty("features")]
        public ChimeFeatures Features { get; set; }

        [JsonProperty("owned")]
        public bool Owned { get; set; }

        [JsonProperty("alerts")]
        public ChimeAlerts Alerts { get; set; }

        [JsonProperty("do_not_disturb")]
        public DoNotDisturb DoNotDisturb { get; set; }

        [JsonProperty("stolen")]
        public bool Stolen { get; set; }

        [JsonProperty("location_id")]
        public Guid LocationId { get; set; }

        [JsonProperty("ring_id")]
        public object RingId { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }
    }
}