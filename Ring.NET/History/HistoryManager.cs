using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RingIntegration.Authentication;

namespace RingIntegration.Devices.History
{
    public class HistoryManager : RingHttpClient
    {
        private readonly IAuthenticator _authenticator;
        private readonly string _dingHistoryURL = "https://api.ring.com/clients_api/doorbots/history";
        private const string _dingRecordingURL = "https://api.ring.com/clients_api/dings/{0}/recording";
        
        public HistoryManager(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
        
        public async Task<History[]> GetHistory(int limit)
        {
            var data = new Dictionary<string, string> {{"limit", limit.ToString()}};

            var httpResponse = await MakeGetRequest(_dingHistoryURL, data);
            var json = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<History[]>(json);
        }

        public async Task<byte[]> GetRecording(History history)
        {
            if (!history.recording.status.Equals("ready", StringComparison.OrdinalIgnoreCase))
                return null;

            var url = string.Format(_dingRecordingURL, history.id);

            var httpResponse = await MakeGetRequest(url);
            
            //File.WriteAllBytes("test.mp4", await httpResponse.Content.ReadAsByteArrayAsync());
            return await httpResponse.Content.ReadAsByteArrayAsync();

        }
        
        public override string AccessToken => _authenticator.AccessToken;
    }
}