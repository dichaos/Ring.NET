using System.Threading.Tasks;
using Newtonsoft.Json;
using RingIntegration.Authentication;

namespace RingIntegration.Devices.Doorbell
{
    public class Doorbell : RingHttpClient
    {
        private readonly IAuthenticator _authenticator;
        private readonly Doorbot _doorbot;
        private readonly string _devicesURL = "https://api.ring.com/clients_api/ring_devices";
        private readonly string _dingURL = "https://api.ring.com/clients_api/dings/active";
        private readonly string _dingHistoryURL = "https://api.ring.com/clients_api/doorbots/history";
        
        public Doorbell(IAuthenticator authenticator, Doorbot doorbot)
        {
            _authenticator = authenticator;
            _doorbot = doorbot;
        }

        public override string AccessToken => _authenticator.AccessToken;

        public async Task GetHistory(int limit )
        {
            var httpResponse = await base.MakeGetRequest(_dingHistoryURL + $"limit={limit}");

            var result = await httpResponse.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<Models.Devices>();
        }
    }
}