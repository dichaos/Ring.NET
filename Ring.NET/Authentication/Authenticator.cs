using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RingIntegration.Authentication
{
    public class Authenticator : RingHttpClient, IAuthenticator
    {
        private readonly string _loginUrl = "https://oauth.ring.com/oauth/token";
        private string _password;
        private string _username;
        private TwoWayAuthResponse TwoWayAuthResponse { get; set; }
        private AuthResponse AuthResponse { get; set; }

        public Authenticator( string username, string password, string token = "")
        {
            _username = username;
            _password = password;
            
            if (!string.IsNullOrEmpty(token))
            {
                AuthResponse = new AuthResponse()
                {
                    AccessToken = token
                };
            }
        }
        
        public override string AccessToken => AuthResponse == null ? string.Empty : AuthResponse.AccessToken;

        public async Task<bool> Authenticate(bool twofactor = false)
        {

            var json = AuthRequest.GetRequest(_username, _password);


            var httpResponse = await MakePostRequest(_loginUrl, json);

            if (!httpResponse.IsSuccessStatusCode && httpResponse.StatusCode != HttpStatusCode.PreconditionFailed) return false;

            if (twofactor)    
                TwoWayAuthResponse =
                    JsonConvert.DeserializeObject<TwoWayAuthResponse>(await httpResponse.Content.ReadAsStringAsync());
            else
                AuthResponse =
                    JsonConvert.DeserializeObject<AuthResponse>(await httpResponse.Content.ReadAsStringAsync());

            return true;
        }

        public async Task<bool> TwoFactorAuthentication(string code)
        {
            var json = AuthRequest.GetRequest(_username, _password);

            var httpResponse = await MakePostRequest(_loginUrl, json, new List<Tuple<string, string>>
            {
                new Tuple<string, string>("2fa-code", code),
                new Tuple<string, string>("2fa-support", "true")
            });

            if (!httpResponse.IsSuccessStatusCode) return false;

            AuthResponse = JsonConvert.DeserializeObject<AuthResponse>(await httpResponse.Content.ReadAsStringAsync());

            return true;
        }
    }
}