using RingIntegration.Authentication;

namespace RingIntegration.Dings
{
    public class DingManager : RingHttpClient
    {
        public override string AccessToken => _authenticator.AccessToken;
        private const string _dingRecordingURL = "/clients_api/dings/{id}/recording";
        private readonly Authenticator _authenticator;

        public DingManager(Authenticator authenticator)
        {
            _authenticator = authenticator;
        }
        
        
    }
}