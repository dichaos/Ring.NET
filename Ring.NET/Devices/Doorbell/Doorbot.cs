using System;
using Newtonsoft.Json;
using RingIntegration.Devices.Models;

namespace RingIntegration.Devices.Doorbell
{
    public class Doorbot
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("subscribed_motions")]
        public bool SubscribedMotions { get; set; }

        [JsonProperty("battery_life")]
        public long BatteryLife { get; set; }

        [JsonProperty("external_connection")]
        public bool ExternalConnection { get; set; }

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
        public DoorbotSettings Settings { get; set; }

        [JsonProperty("features")]
        public DoorbotFeatures Features { get; set; }

        [JsonProperty("owned")]
        public bool Owned { get; set; }

        [JsonProperty("alerts")]
        public DoorbotAlerts Alerts { get; set; }

        [JsonProperty("motion_snooze")]
        public object MotionSnooze { get; set; }

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