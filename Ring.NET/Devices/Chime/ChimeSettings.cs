using Newtonsoft.Json;

namespace RingIntegration.Devices.Chime
{
    public partial class ChimeSettings
    {
        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("ding_audio_user_id")]
        public string DingAudioUserId { get; set; }

        [JsonProperty("ding_audio_id")]
        public string DingAudioId { get; set; }

        [JsonProperty("motion_audio_user_id")]
        public string MotionAudioUserId { get; set; }

        [JsonProperty("motion_audio_id")]
        public string MotionAudioId { get; set; }
    }
}