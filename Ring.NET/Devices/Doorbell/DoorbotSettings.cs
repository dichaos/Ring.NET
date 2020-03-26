using Newtonsoft.Json;
using RingIntegration.Devices.Chime;
using RingIntegration.Devices.Models;

namespace RingIntegration.Devices.Doorbell
{
    public class DoorbotSettings
    {
        [JsonProperty("offline_motion_event_settings")]
        public OfflineMotionEventSettings OfflineMotionEventSettings { get; set; }

        [JsonProperty("lite_24x7")]
        public Lite24X7 Lite24X7 { get; set; }

        [JsonProperty("enable_vod")]
        public long EnableVod { get; set; }

        [JsonProperty("exposure_control")]
        public long ExposureControl { get; set; }

        [JsonProperty("motion_zones")]
        public long[] MotionZones { get; set; }

        [JsonProperty("motion_snooze_preset_profile")]
        public string MotionSnoozePresetProfile { get; set; }

        [JsonProperty("motion_snooze_presets")]
        public string[] MotionSnoozePresets { get; set; }

        [JsonProperty("live_view_preset_profile")]
        public string LiveViewPresetProfile { get; set; }

        [JsonProperty("live_view_presets")]
        public string[] LiveViewPresets { get; set; }

        [JsonProperty("pir_sensitivity_1")]
        public long PirSensitivity1 { get; set; }

        [JsonProperty("vod_suspended")]
        public long VodSuspended { get; set; }

        [JsonProperty("doorbell_volume")]
        public long DoorbellVolume { get; set; }

        [JsonProperty("vod_status")]
        public string VodStatus { get; set; }

        [JsonProperty("chime_settings")]
        public ChimeSettingsClass ChimeSettings { get; set; }

        [JsonProperty("advanced_motion_detection_enabled")]
        public bool AdvancedMotionDetectionEnabled { get; set; }

        [JsonProperty("advanced_motion_zones")]
        public AdvancedMotionZones AdvancedMotionZones { get; set; }

        [JsonProperty("advanced_motion_detection_human_only_mode")]
        public bool AdvancedMotionDetectionHumanOnlyMode { get; set; }

        [JsonProperty("enable_audio_recording")]
        public bool EnableAudioRecording { get; set; }

        [JsonProperty("people_detection_eligible")]
        public bool PeopleDetectionEligible { get; set; }

        [JsonProperty("live_view_disabled")]
        public bool LiveViewDisabled { get; set; }

        [JsonProperty("ignore_zones")]
        public IgnoreZones IgnoreZones { get; set; }

        [JsonProperty("enable_rich_notifications")]
        public bool EnableRichNotifications { get; set; }

        [JsonProperty("rich_notifications_billing_eligible")]
        public bool RichNotificationsBillingEligible { get; set; }

        [JsonProperty("rich_notifications_face_crop_enabled")]
        public bool RichNotificationsFaceCropEnabled { get; set; }

        [JsonProperty("loitering_threshold")]
        public long LoiteringThreshold { get; set; }

        [JsonProperty("advanced_motion_detection_types")]
        public object[] AdvancedMotionDetectionTypes { get; set; }

        [JsonProperty("motion_detection_enabled")]
        public bool MotionDetectionEnabled { get; set; }

        [JsonProperty("rich_notifications_scene_source")]
        public string RichNotificationsSceneSource { get; set; }

        [JsonProperty("recording_storage_type")]
        public string RecordingStorageType { get; set; }

        [JsonProperty("advanced_motion_zones_enabled")]
        public bool AdvancedMotionZonesEnabled { get; set; }

        [JsonProperty("advanced_motion_zones_type")]
        public string AdvancedMotionZonesType { get; set; }

        [JsonProperty("advanced_pir_motion_zones")]
        public AdvancedPirMotionZones AdvancedPirMotionZones { get; set; }

        [JsonProperty("knock_detection_enabled")]
        public bool KnockDetectionEnabled { get; set; }

        [JsonProperty("knock_sensitivity")]
        public long KnockSensitivity { get; set; }

        [JsonProperty("enable_ir_led")]
        public bool EnableIrLed { get; set; }
    }
}