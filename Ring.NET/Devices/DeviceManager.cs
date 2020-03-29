using System.Threading.Tasks;
using Newtonsoft.Json;
using RingIntegration.Authentication;

namespace RingIntegration.Devices
{
    public class DeviceManager : RingHttpClient
    {
        private readonly IAuthenticator _authenticator;
        private readonly string _devicesURL = "https://api.ring.com/clients_api/ring_devices";

        public DeviceManager(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public override string AccessToken => _authenticator.AccessToken;

        public async Task<Models.Devices> GetDevices()
        {
            var httpResponse = await MakeGetRequest(_devicesURL);
            return JsonConvert.DeserializeObject<Models.Devices>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}