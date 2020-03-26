using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RingIntegration.Authentication
{
    public class Authenticator : RingHttpClient, IAuthenticator
    {
        
        private TwoWayAuthResponse TwoWayAuthResponse { get; set; }
        private AuthResponse AuthResponse { get; set; }
        
        private readonly string _loginUrl = "https://oauth.ring.com/oauth/token";
        private string _username;
        private string _password;

        public override string AccessToken => AuthResponse == null ? string.Empty : AuthResponse.AccessToken;

        //override string AccessToken => AuthResponse.AccessToken;

        public async Task<bool> Authenticate(string username, string password)
        {
            this._username = username;
            this._password = password;
            var json = AuthRequest.GetRequest(username, password);


            var httpResponse = await MakePostRequest(_loginUrl,json);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return false;
            }

            TwoWayAuthResponse = JsonConvert.DeserializeObject<TwoWayAuthResponse>(await httpResponse.Content.ReadAsStringAsync());
            return true;
        }

        public async Task<bool> TwoFactorAuthentication(string code)
        {
            var json = AuthRequest.GetRequest(_username, _password);

            var httpResponse = await MakePostRequest(_loginUrl,json, new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("2fa-code", code),
                new Tuple<string, string>("2fa-support", "true"),
            });
            
            if (!httpResponse.IsSuccessStatusCode)
            {
                return false;
            }

            AuthResponse = JsonConvert.DeserializeObject<AuthResponse>(await httpResponse.Content.ReadAsStringAsync());
            
            return true;
        }
    }
}